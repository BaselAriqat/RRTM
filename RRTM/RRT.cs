using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Drawing;
using System.Threading;
using System.Timers;
/*
Algorithm BuildRRT
  Input: Initial configuration qinit, number of vertices in RRT K, incremental distance Δq)
  Output: RRT graph G
 
  G.init(qinit)❣
  for k = 1 to K❣
    qrand ← RAND_CONF()❣
    qnear ← NEAREST_VERTEX(qrand, G)❣
    qnew ← NEW_CONF(qnear, qrand, Δq)❣
    G.add_vertex(qnew)❣
    G.add_edge(qnear, qnew)❣
  return G❣
 * ❖❖❖❖❖❖❖❖❖❖❖❖❖❖❖❖

*/
namespace RRTM
{

    class RRT
    {
        //for Benchmarks
        public int NumberOfRejections;
        public int NearestNeighborComputations;
        public int BiasNodesCounts;
        protected State start;
        protected State goal;
        protected LinkedList<Node> allNodes;
        protected LinkedList<Node> Toppoints;
        protected LinkedList<Node> Botpoints;
        protected LinkedListNode<Node> node;
        protected int maxIterations;
        protected NearestNeighbor nn;
        protected Workspace ws;
        protected long time;
        protected bool solutionFound;
        protected float k;
        protected Node start_;
        protected int Heightofform, Widthofform;
        protected int biasmin;
        protected Random rand2 = new Random();
        protected Robot robot;
        protected float[] maxs;
        protected Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        protected bool robotDot;
        protected Robot RandomRobot;
        public double timer;
        float robot_height;
        public RRT(Workspace ws_, int h, int w, bool isLinear, bool robotdot_,int RobotHeight)
        {
            Botpoints = new LinkedList<Node>();
            Toppoints = new LinkedList<Node>();
            NearestNeighborComputations = 0;
            NumberOfRejections = 0;
            BiasNodesCounts = 0;
            if (isLinear)
            {
                nn = new NearestNeighborLinear();

            }
            else
            {
                nn = new KDTreeNN();
            }
            
            solutionFound = false;
            allNodes = new LinkedList<Node>();
            ws = ws_;
            k = 5;
            start = new State();
            goal = new State();
            start.Dimensions = ws.get_start();
            goal.Dimensions = ws.get_goal();
            robotDot = robotdot_;
            if (robotDot)
            {
                robot = new RobotDot();
            }
            else
            {
                float[] goals = new float[3];
                goals[0] = ws.Goal.Dimensions[0];
                goals[1] = ws.Goal.Dimensions[1];
                goals[2] = 0;

                float[] starts = new float[3];
                starts[0] = ws.Start.Dimensions[0];
                starts[1] = ws.Start.Dimensions[1];
                starts[2] = 0;
                start = new State(starts);
                goal = new State(goals);
                robot = new RobotStick();
                robot.RobotHieght = RobotHeight;
                robot_height = RobotHeight;
            }
            nn.setRoot(start);

                Heightofform = h;
            Widthofform = w;
        }
        protected void setGoal(State s)
        {
            goal = s;
        }
        protected void setStart(State s)
        {
            start = s;
        }

        public LinkedList<Node> get_top_points()
        {
            return Toppoints;
        }
        public LinkedList<Node> Get_Bot_points()
        {
            return Botpoints;
        }
        
        public int Bias 
        {
            set { biasmin = value; }
            get { return biasmin; }
        }

        public float K
        {
            set
            {
                if (value > 0)
                    k = value;
            }
            get { return k; }
        }

        public int MaxN
        {
            set { maxIterations = value; }
            get { return maxIterations; }
        }
        public LinkedList<Node> getpath()
        {
            return allNodes;
        }
        protected int bias;
        public virtual bool solve()
        {
            DateTime timerStart = DateTime.Now;
            start_ = new Node();
            start_.State_ = start;
            start_.Parent = null;
            allNodes.AddFirst(start_);

            if (robotDot)
            {
                RandomRobot = new RobotDot();
                robot = new RobotDot();
            }
            else
            {
                RandomRobot = new RobotStick();
                robot = new RobotStick();
                robot.RobotHieght = robot_height;
                RandomRobot.RobotHieght = robot_height;
            }
            while (!solutionFound && maxIterations > allNodes.Count)
            {
                bias = rand2.Next(1, 100);


                if (bias >= biasmin)
                {
                    RandomRobot.robotBody = robot.GenerateRandomState(Widthofform,Heightofform);
                }
                else
                {
                    BiasNodesCounts++;
                    RandomRobot.robotBody = goal;
                }
                
                Node nearestneighbor = nn.nearest(allNodes, RandomRobot.robotBody);
                Node node = new Node();
                float[] x0 = nearestneighbor.State_.Dimensions;
                float[] statenew = new float[RandomRobot.robotBody.Dimensions.Length];
                float Length = 0;
                //*** draw random points
               // formgraphics.DrawRectangle(pen1,new Rectangle((int) RandomState.Dimensions[0],(int) RandomState.Dimensions[1],3,3));

                calculate_inpterpolation(ref statenew,ref Length, nearestneighbor, RandomRobot.robotBody, x0);
                robot.robotBody.Dimensions = statenew;
                if (ws.is_valid((int)statenew[0], (int)statenew[1]) != -1 || Length < k)  // if the new node itersectcs with an obstacle, make a new random point.
                {
                    NumberOfRejections++;
                    continue;
                }
                if (!robotDot)
                {
                    State toppoint = robot.GetTopPoint();
                    State BotPoint =  robot.GetBotPoint();
                    if (ws.is_valid((int)toppoint.Dimensions[0], (int)toppoint.Dimensions[1]) != -1 )
                    {
                       // formgraphics.FillEllipse(new SolidBrush(Color.Red), toppoint.Dimensions[0], toppoint.Dimensions[1], 4, 4);
                        NumberOfRejections++;
                        continue;
                    }
                    if (ws.is_valid((int)BotPoint.Dimensions[0], (int)BotPoint.Dimensions[1]) != -1)
                    {
                        //formgraphics.FillEllipse(new SolidBrush(Color.Red), BotPoint.Dimensions[0], BotPoint.Dimensions[1], 4, 4);

                        NumberOfRejections++;
                        continue;
                    }
                    
                }
               // if (robot.robotBody.Dimensions.Length == 3)
                 //   statenew[2] = robot.robotBody.Dimensions[2];



                node = new Node(nearestneighbor, new State(robot.robotBody.Dimensions));
                allNodes.AddLast(node);
                //if (!robotDot)
                //{
                //    Robot r = new RobotStick();
                //    r.robotBody = allNodes.Last.Value.State_;
                //    State toppoint2 = r.GetTopPoint();

                //    State BotPoint2 = r.GetBotPoint();

                //    formgraphics.DrawLine(new Pen(Color.Green), toppoint2.Dimensions[0], toppoint2.Dimensions[1], BotPoint2.Dimensions[0], BotPoint2.Dimensions[1]);

                //}
                nn.addNode(node);
                float distance_to_goal;

                distance_to_goal = calculate_distance(out distance_to_goal, node, goal);

                if (distance_to_goal <= k) // solution is possibly found will consider it found for now. didnt check for obstacles between the state and the goal.
                {
                    Node finalnode = new Node(node, goal);
                    allNodes.AddLast(finalnode);
                    solutionFound = true;
                }
               

                //formgraphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), new Rectangle((int)RandomState.Dimensions[0], (int)RandomState.Dimensions[1], 3, 3));
                //Thread.Sleep(100);
            }
            
            NearestNeighborComputations = nn.NumberOfComputations;
            DateTime timerStop = DateTime.Now;
            timer = (timerStop - timerStart).TotalMilliseconds;
            return solutionFound;

        }

        // public void SolveRRTConnect()
        // {
        //   /*System.Drawing.SolidBrush Nodebrush = new System.Drawing.SolidBrush(Color.Blue);
        //    System.Drawing.SolidBrush randomNodebrush = new System.Drawing.SolidBrush(Color.Green);
        //    System.Drawing.Pen pen1 = new Pen(Nodebrush);
        //    System.Drawing.Pen pen2 = new Pen(randomNodebrush);
        //    System.Drawing.Point point1;
        //    System.Drawing.Point point2;
        //    */
        //    start_ = new Node();

        //    start_.State_ = ws.Start;
        //    start_.Parent = null;
        //    allNodes.AddFirst(start_);
        //    while (!solutionFound)
        //    {
        //        bias = rand2.Next(1, 100);

        //        State RandomState;
        //        if (bias >= biasmin)
        //            RandomState = robot.GenerateRandomState();
        //        else
        //        {
        //            BiasNodesCounts++;
        //            RandomState = goal;
        //        }
        //        //NearestNeighborComputations++;
        //        Node nearestneighbor = nn.nearest(allNodes, RandomState);
        //        while (true)
        //        {
        //            Node node = new Node();
        //            float[] x0 = nearestneighbor.State_.Dimensions;
        //            float[] statenew = new float[2];
        //            float Length = 0;
        //            //*** draw random points
        //            // formgraphics.DrawRectangle(pen1,new Rectangle((int) RandomState.Dimensions[0],(int) RandomState.Dimensions[1],3,3));

        //            calculate_inpterpolation(ref statenew, ref Length, nearestneighbor, RandomState, x0);
                    
        //            if (ws.is_valid((int)statenew[0], (int)statenew[1]) != -1 || Length < k)  // if the new node itersectcs with an obstacle, make a new random point.
        //            {
        //                NumberOfRejections++;
        //                break;
        //            }
                    
        //            node = new Node(nearestneighbor, new State(statenew));
        //            // point1 = new Point((int)nearestneighbor.State_.Dimensions[0],(int)nearestneighbor.State_.Dimensions[1]);
        //            // point2 = new Point((int) statenew[0],(int)statenew[1]);
        //            // formgraphics.DrawLine(pen2, point1, point2);
        //            float distance_to_randomPoint;
        //            distance_to_randomPoint = calculate_distance(out distance_to_randomPoint, node, RandomState);
                    
        //            allNodes.AddLast(node);
        //            nn.addNode(node);
                    
        //            float distance_to_goal;

        //            distance_to_goal = calculate_distance(out distance_to_goal, node, goal);

        //            if (distance_to_goal <= k) // solution is possibly found will consider it found for now. didnt check for obstacles between the state and the goal.
        //            {
        //                Node finalnode = new Node(node, goal);
        //                allNodes.AddLast(finalnode);
        //                solutionFound = true;
        //                break;
        //            }
        //            if (distance_to_randomPoint <= k)
        //                break;
        //            nearestneighbor = node;

        //        }
        //        //formgraphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), new Rectangle((int)RandomState.Dimensions[0], (int)RandomState.Dimensions[1], 3, 3));
        //        //Thread.Sleep(100);
        //    }
        //    NearestNeighborComputations = nn.NumberofComputaions;

        //    return;
        //}


        protected float calculate_distance(out float distance_to_goal, Node node, State goal)
        {
            distance_to_goal = 0;
            for (int i = 0; i <2 ; i++) // node.State_.Dimensions.Length
            {
                distance_to_goal += (float)Math.Pow((node.State_.Dimensions[i]) - (goal.Dimensions[i]), 2);
            }
            distance_to_goal = (float)Math.Sqrt(distance_to_goal);
            return distance_to_goal;
        }

        protected void calculate_inpterpolation(ref float[] statenew_, ref float Length_, Node nearestneighbor_, State RandomState_, float[] x0_)
        {
            for (int i = 0; i < RandomState_.Dimensions.Length; i++) // statenew_.length
            {
                statenew_[i] = RandomState_.Dimensions[i] - x0_[i];
                Length_ += (float)Math.Pow(RandomState_.Dimensions[i] - x0_[i], 2);
            }
            Length_ = (float)Math.Sqrt(Length_);
            for (int i = 0; i < RandomState_.Dimensions.Length; i++) //statenew_.length
            {
                statenew_[i] = (statenew_[i] * k) / Length_;
                statenew_[i] = statenew_[i] + nearestneighbor_.State_.Dimensions[i];
            }
            //if (statenew_.Length == 3) // get the avg of two angles
            //{
            //    if(nearestneighbor_.State_.Dimensions.Length == 3)
            //        statenew_[2] = Math.Min(Math.Abs(nearestneighbor_.State_.Dimensions[2] - statenew_[2]), Math.Abs(360 - (Math.Abs(nearestneighbor_.State_.Dimensions[2] - statenew_[2]))));

            //}
        }

        protected bool CheckForIntersections()
        {

            return false;
        }
        protected State generate_random_state() // needs improvment on 3 dimensions
        {
            
            float[] random = new float[2];
            random[0] = (float)rand.Next(0, Widthofform);
            random[1] = (float)rand.Next(0, Heightofform);
            
            return new State(random);
        }
        
    }
}
