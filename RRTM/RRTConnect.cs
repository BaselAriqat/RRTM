using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RRTM
{
    class RRTConnect : RRT
    {
        public RRTConnect(Workspace ws_, int h , int w, bool isLinear, bool robotdot_, int RobotHeight) : base(ws_, h,  w,isLinear,robotdot_,RobotHeight)
        {
            NearestNeighborComputations = 0;
            NumberOfRejections = 0;
            BiasNodesCounts = 0;
            if (isLinear)
                nn = new NearestNeighborLinear();
            else
                nn = new KDTreeNN();
            
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
                robot = new RobotDot();
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
            }
            nn.setRoot(start);

            Heightofform = h;
            Widthofform = w;
        }

        public override bool solve()
        {
            /*System.Drawing.SolidBrush Nodebrush = new System.Drawing.SolidBrush(Color.Blue);
            System.Drawing.SolidBrush randomNodebrush = new System.Drawing.SolidBrush(Color.Green);
            System.Drawing.Pen pen1 = new Pen(Nodebrush);
            System.Drawing.Pen pen2 = new Pen(randomNodebrush);
            System.Drawing.Point point1;
            System.Drawing.Point point2;
            */
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
                robot = new RobotStick();
                RandomRobot = new RobotStick();
            }
            while (!solutionFound)
            {
                bias = rand2.Next(1, 100);

                if (bias >= biasmin)
                    RandomRobot.robotBody = robot.GenerateRandomState(Widthofform,Heightofform);
                else
                {
                    BiasNodesCounts++;
                    RandomRobot.robotBody = goal;
                }
                //NearestNeighborComputations++;
                Node nearestneighbor = nn.nearest(allNodes, RandomRobot.robotBody);
                while (true)
                {
                    Node node = new Node();
                    float[] x0 = nearestneighbor.State_.Dimensions;
                    float[] statenew = new float[RandomRobot.robotBody.Dimensions.Length];
                    float Length = 0;
                    //*** draw random points
                    // formgraphics.DrawRectangle(pen1,new Rectangle((int) RandomState.Dimensions[0],(int) RandomState.Dimensions[1],3,3));

                    calculate_inpterpolation(ref statenew, ref Length, nearestneighbor, RandomRobot.robotBody, x0);
                    robot.robotBody.Dimensions = statenew;

                    if (ws.is_valid((int)statenew[0], (int)statenew[1]) != -1 || Length < k)  // if the new node itersectcs with an obstacle, make a new random point.
                    {
                        NumberOfRejections++;
                        break;
                    }
                    if (!robotDot)
                    {
                        State toppoint = robot.GetTopPoint();
                        State BotPoint = robot.GetBotPoint();
                        if (ws.is_valid((int)toppoint.Dimensions[0], (int)toppoint.Dimensions[1]) != -1)
                        {
                            // formgraphics.FillEllipse(new SolidBrush(Color.Red), toppoint.Dimensions[0], toppoint.Dimensions[1], 4, 4);
                            NumberOfRejections++;
                            break;
                        }
                        if (ws.is_valid((int)BotPoint.Dimensions[0], (int)BotPoint.Dimensions[1]) != -1)
                        {
                            //formgraphics.FillEllipse(new SolidBrush(Color.Red), BotPoint.Dimensions[0], BotPoint.Dimensions[1], 4, 4);

                            NumberOfRejections++;
                            break;
                        }

                    }
                    node = new Node(nearestneighbor,new State(robot.robotBody.Dimensions));
                    // point1 = new Point((int)nearestneighbor.State_.Dimensions[0],(int)nearestneighbor.State_.Dimensions[1]);
                    // point2 = new Point((int) statenew[0],(int)statenew[1]);
                    // formgraphics.DrawLine(pen2, point1, point2);
                    float distance_to_randomPoint;
                    distance_to_randomPoint = calculate_distance(out distance_to_randomPoint, node, RandomRobot.robotBody);
                    
                    allNodes.AddLast(node);
                    nn.addNode(node);

                    //if (!robotDot)
                    //{

                    //    State toppoint2 = robot.GetTopPoint();

                    //    State BotPoint2 = robot.GetBotPoint();

                    //    formgraphics.DrawLine(new Pen(Color.Green), toppoint2.Dimensions[0], toppoint2.Dimensions[1], BotPoint2.Dimensions[0], BotPoint2.Dimensions[1]);

                    //}
                    //State toppoint2 = robot.GetTopPoint();

                    //State BotPoint2 = robot.GetBotPoint();

                    //fromgraphics.DrawLine(new Pen(Color.Red), toppoint2.Dimensions[0], toppoint2.Dimensions[1], BotPoint2.Dimensions[0], BotPoint2.Dimensions[1]);
               
                    float distance_to_goal;

                    distance_to_goal = calculate_distance(out distance_to_goal, node, goal);

                    if (distance_to_goal <= k) // solution is possibly found will consider it found for now. didnt check for obstacles between the state and the goal.
                    {
                        Node finalnode = new Node(node, goal);
                        allNodes.AddLast(finalnode);
                        solutionFound = true;
                    }

                    if (distance_to_randomPoint <= k)
                        break;

                    nearestneighbor = node;

                }
                //formgraphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), new Rectangle((int)RandomState.Dimensions[0], (int)RandomState.Dimensions[1], 3, 3));
                //Thread.Sleep(100);
            }
            DateTime timerStop = DateTime.Now;
            timer = (timerStop - timerStart).TotalMilliseconds;
            NearestNeighborComputations = nn.NumberofComputaions;

            return solutionFound;
        }
    }
}
