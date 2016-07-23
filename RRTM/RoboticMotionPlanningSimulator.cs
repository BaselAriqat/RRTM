using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace RRTM
{
    public partial class Form1 : Form
    {

        int deltax, deltay, deltax2, deltay2, firstx, firsty, x2, y2;
        Rectangle chosen_rectangle;
        Workspace ws;
        bool stillDown, select_cancel;
        bool check1, check2;
        int k, maxn, bias;
        int animateTime;
        int itemClickedContextMenu;
        Thread AnimationThread;
        Thread RobotThread;
        Stopwatch timer;
        LinkedList<Node> allnodes;
        List<Node> solutionPath;
        List<Node> smoothedSolutionPath;
        LinkedList<Node> Toppoints2;
        LinkedList<Node> Botpoints2;

        bool Move_obstacle_state;
        int clicked_item;
        Thread Pogress_bar_thread;
        int originalX, originalY;
        RRT rrt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Robotic Motion Planning Simulator";

            pictureBox2.Hide();
            pictureBox2.Location = new Point((pictureBox1.Width / 2), pictureBox1.Height / 2);

            select_cancel = false;
            Move_obstacle_state = false;
            timer = new Stopwatch();
            contextMenuStrip1.Items.Add("Set Start");
            contextMenuStrip1.Items.Add("Set Goal");
            contextMenuStrip1.Items.Add("Move Obstacle");
            contextMenuStrip1.Items.Add("Delete Obstacle");
            itemClickedContextMenu = 0;
            check1 = false;
            check2 = false;
            ws = new Workspace();
            stillDown = false;
            deltax = 0;
            deltay = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            solutionPath = new List<Node>();
            smoothedSolutionPath = new List<Node>();
            DrawRectangleradioButton.Select();
            RRTRadioButton.Select();
            ShowAllNodesCheckBox.Checked = true;
            ShowSolutionspathCheckBox.Checked = true;
            ws.SetHeightAndWidth(pictureBox1.Height,pictureBox1.Width);
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // create cube ?!
            // Pen myPen = new Pen(Color.Black);
            // myPen.Width = 3;

            if (pictureBox1.Height > e.Y && pictureBox1.Width > e.X && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (itemClickedContextMenu == 1)
                {
                    System.Drawing.Brush b = new SolidBrush(Color.Red);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = pictureBox1.CreateGraphics();
                    formGraphics.FillEllipse(b, new Rectangle(e.X, e.Y, 10, 10));

                    float[] dimension = new float[2];
                    dimension[0] = (float)e.X;
                    dimension[1] = (float)e.Y;
                    State start = new State(dimension);
                    b = new SolidBrush(Color.White);
                    formGraphics.FillEllipse(b, new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));

                    ws.Start = start;
                    itemClickedContextMenu = 0;
                    return;
                }
                if (itemClickedContextMenu == 2)
                {
                    System.Drawing.Graphics formGraphics;
                    formGraphics = pictureBox1.CreateGraphics();
                    formGraphics.FillEllipse(new SolidBrush(Color.Purple), new Rectangle(e.X, e.Y, 10, 10));
                    float[] dimension = new float[2];
                    dimension[0] = (float)e.X;
                    dimension[1] = (float)e.Y;
                    State goal = new State(dimension);
                    formGraphics.FillEllipse(new SolidBrush(Color.White), new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));
                    ws.Goal = goal;
                    itemClickedContextMenu = 0;
                    return;
                }
                if (itemClickedContextMenu == 3)
                {
                    clicked_item = ws.is_valid(e.X, e.Y);
                    if (clicked_item != -1)
                    {
                        Move_obstacle_state = true;
                    }
                    itemClickedContextMenu = 0;
                }
                if (itemClickedContextMenu == 4)
                {
                    // goal and start redraw

                    int x1 = e.X;
                    int y1 = e.Y;
                    int isvalid = ws.is_valid(x1, y1);
                    if (isvalid != -1)
                    {
                        ws.get_obs[isvalid].delete_obstacle();
                        Graphics g = pictureBox1.CreateGraphics();
                        g.Clear(Color.White);
                        for (int i = 0; i < ws.get_obs.Count; i++)
                        {
                            var pair = ws.get_obs_at_index(i);
                            if (pair.Key)
                            {
                                g.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                            }
                            else
                            {
                                g.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                            }
                        }
                        g.Dispose();
                    }
                    itemClickedContextMenu = 0;
                }



                if (!stillDown) // if the mouse still down, ignore this. stillDown will be changed after mouseup is called.
                {
                    firstx = e.X;
                    firsty = e.Y;
                    x2 = firstx;
                    y2 = firsty;
                    stillDown = true;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
                    
            if (e.Button == MouseButtons.Left && stillDown) // mouse movement may not be drawing a mouse.
            {
                if (Move_obstacle_state)
                {
                    PaintEventArgs e2 = new PaintEventArgs(pictureBox1.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
                    e2.Graphics.Clear(Color.White);

                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.Graphics formGraphics;

                    formGraphics = pictureBox1.CreateGraphics();

                    System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    brush.Color = System.Drawing.Color.Red;
                    System.Drawing.Pen pen = new Pen(brush);
                    formGraphics.FillEllipse(brush, new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));
                    brush = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
                    pen = new Pen(brush);
                    formGraphics.FillEllipse(brush, new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));

                    for (int i = 0; i < ws.get_obs.Count; i++)
                    {
                        var pair = ws.get_obs_at_index(i);
                        if (pair.Key)
                        {
                            formGraphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                        }
                        else
                        {
                            formGraphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                        }
                    }
                    ws.get_obs[clicked_item].OBS_MOVE(e.X, e.Y);
                    

                }
                else
                {
                    PaintEventArgs e2 = new PaintEventArgs(pictureBox1.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
                    e2.Graphics.Clear(Color.White);

                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = pictureBox1.CreateGraphics();

                    for (int i = 0; i < ws.get_obs.Count; i++)
                    {
                        var pair = ws.get_obs_at_index(i);
                        if (pair.Key)
                        {
                            formGraphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                        }
                        else
                        {
                            formGraphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                        }
                    }

                    int newx = e.X;
                    int newy = e.Y;
                    deltax2 = x2 - firstx;
                    deltay2 = y2 - firsty;

                    deltax = newx - firstx;
                    deltay = newy - firsty;


                    if (DrawRectangleradioButton.Checked == true)
                    {
                        if (deltay <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx, firsty + deltay2, deltax2, deltay2 * -1);
                            formGraphics.FillRectangle(myBrush, new Rectangle(firstx, firsty + deltay, deltax, deltay * -1));
                        }
                        if (deltax <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx + deltax2, firsty, deltax2 * -1, deltay2);
                            formGraphics.FillRectangle(myBrush, new Rectangle(firstx + deltax, firsty, deltax * -1, deltay));
                        }
                        if (deltax <= 0 && deltay <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx + deltax2, firsty + deltay2, deltax2 * -1, deltay2 * -1);
                            formGraphics.FillRectangle(myBrush, new Rectangle(firstx + deltax, firsty + deltay, deltax * -1, deltay * -1));
                        }
                        if (deltax >= 0 && deltay >= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx, firsty, deltax2, deltay2);
                            formGraphics.FillRectangle(myBrush, new Rectangle(firstx, firsty, deltax, deltay));
                        }
                    }
                    else
                    {
                        if (deltay <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx, firsty + deltay2, deltax2, deltay2 * -1);
                            formGraphics.FillEllipse(myBrush, new Rectangle(firstx, firsty + deltay, deltax, deltay * -1));
                        } 
                        if (deltax <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx + deltax2, firsty, deltax2 * -1, deltay2);
                            formGraphics.FillEllipse(myBrush, new Rectangle(firstx + deltax, firsty, deltax * -1, deltay));
                        }
                        if (deltax <= 0 && deltay <= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx + deltax2, firsty + deltay2, deltax2 * -1, deltay2 * -1);
                            formGraphics.FillEllipse(myBrush, new Rectangle(firstx + deltax, firsty + deltay, deltax * -1, deltay * -1));
                        }
                        if (deltax >= 0 && deltay >= 0)
                        {
                            chosen_rectangle = new Rectangle(firstx, firsty, deltax2, deltay2);
                            formGraphics.FillEllipse(myBrush, new Rectangle(firstx, firsty, deltax, deltay));
                        }
                    }
                    x2 = newx;
                    y2 = newy;

                    System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    brush.Color = System.Drawing.Color.Red;
                    formGraphics.FillEllipse(brush, new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));
                    brush = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
                    formGraphics.FillEllipse(brush, new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));
                    myBrush.Dispose();
                    formGraphics.Dispose();
                }

            }


        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            stillDown = false;
            Move_obstacle_state = false;
            if (chosen_rectangle.Width > 7 && chosen_rectangle.Height > 7) // if the rectangle wasn't just a click, add it to the obstacles in workspace.
            {
                if (DrawRectangleradioButton.Checked)
                    ws.add_new_obstacle(new Obstacle(chosen_rectangle), true);
                else
                    ws.add_new_obstacle(new ObstacleCircle(chosen_rectangle), false);
            }
            firstx = 0;
            firsty = 0;
            chosen_rectangle = new Rectangle(0, 0, 0, 0); //reset the rectangle.
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (AnimationThread != null && AnimationThread.IsAlive)
                AnimationThread.Abort();
            if (RobotThread != null && RobotThread.IsAlive)
                RobotThread.Abort();
            if (Pogress_bar_thread != null && Pogress_bar_thread.IsAlive)
                Pogress_bar_thread.Abort();

            Application.Exit();
        }




        int steps;
        private void button1_Click(object sender, EventArgs e)
        {
            ClearNodesButton.PerformClick();
            smoothedSolutionPath = new List<Node>();
            steps = 0;
            button1.Enabled = false;
            SmoothingButton.Enabled = false;
            ClearNodesButton.Enabled = false;
            button2.Enabled = false;
            DotRobotRadioButton.Enabled = false;
            StickRobotRadioButton.Enabled = false;
            AnimateCheckBox.Enabled = false;

            ShowAllNodesCheckBox.Enabled = false;
            ShowSolutionspathCheckBox.Enabled = false;
                    
            SmoothingButton.Enabled = false;
            ClearNodesButton.PerformClick();
            k = int.Parse(kTextBox.Text);
            maxn = int.Parse(MaxNTextBox.Text);
            bias = int.Parse(BiasTextBox.Text);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            //rrt = new RRT(ws, pictureBox1.Height, pictureBox1.Width,NearestNeighborKDtreeNNradioButton.Checked);

            if (RRTRadioButton.Checked == true)
                rrt = new RRT(ws, pictureBox1.Height, pictureBox1.Width, NearestNeighborLinearradioButton.Checked, DotRobotRadioButton.Checked, int.Parse(RobotHeightTextBox.Text));
            else if (RRTConnectRadioButton.Checked == true)
                rrt = new RRTConnect(ws, pictureBox1.Height, pictureBox1.Width, NearestNeighborLinearradioButton.Checked, DotRobotRadioButton.Checked, int.Parse(RobotHeightTextBox.Text));

            //RRTConnect rrt = new RRTConnect(ws, Form1.ActiveForm.ClientSize.Height, Form1.ActiveForm.ClientSize.Width);
            rrt.Bias = bias;
            rrt.K = k;
            rrt.MaxN = maxn;  
            // add max iterations, max number of nodes.

            System.Drawing.Graphics formGraphics;
            formGraphics = pictureBox1.CreateGraphics();
            timer.Start();
            progressBar1.Step = 1;



            Pogress_bar_thread = new Thread((() =>Solve()));
            Pogress_bar_thread.SetApartmentState(ApartmentState.STA);
            Pogress_bar_thread.IsBackground = false;
            Pogress_bar_thread.Start();
             

            //  Pogress_bar_thread.Abort();

            //  rrt.solve(formGraphics);
            // label1.Text = "SOLUTION FOUND";

            pictureBox2.Show();
            pictureBox2.BringToFront();
            
            pictureBox2.Refresh();
            AnimationThread = new Thread((() => DrawAllNodes(rrt,formGraphics)));
            AnimationThread.SetApartmentState(ApartmentState.STA);
            AnimationThread.IsBackground = false;
            AnimationThread.Start();
            //pictureBox2.Hide();
            


            

        }
        bool solutionfoud;
        void Solve()
        {
             solutionfoud = rrt.solve();
            if (!solutionfoud)
            {
                if (MessageBox.Show("Maximum number of nodes reached! ") == DialogResult.OK)
                {
                    button1.Enabled = true;
                    SmoothingButton.Enabled = true;
                    ClearNodesButton.Enabled = true;
                    button2.Enabled = true;
                    DotRobotRadioButton.Enabled = true;
                    StickRobotRadioButton.Enabled = true;
                    AnimateCheckBox.Enabled = true;
                    ShowAllNodesCheckBox.Enabled = true;
                    ShowSolutionspathCheckBox.Enabled = true;
                    pictureBox2.Hide();
                }

                
            }
        }


        void DrawAllNodes(RRT rrt, System.Drawing.Graphics formGraphics)
        {
            while (true)
            {
                if (!Pogress_bar_thread.IsAlive)
                {

                    SmoothingButton.Enabled = true;
                    ClearNodesButton.Enabled = true;
                    button2.Enabled = true;
                    DotRobotRadioButton.Enabled = true;
                    StickRobotRadioButton.Enabled = true;
                    AnimateCheckBox.Enabled = true;

                    ShowAllNodesCheckBox.Enabled = true;
                    ShowSolutionspathCheckBox.Enabled = true;

                    pictureBox2.Hide();
                    if (solutionfoud)
                    {
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                        System.Drawing.Pen pen = new Pen(myBrush);

                        allnodes = rrt.getpath();
                        if (allnodes.Count == 0)
                            return;
                        drawAllNodes();
                        DrawSolutionPath();
                        float spaceDensity = 0;
                        for (int i = 0; i < ws.get_obs.Count; i++) //fix for ellipses 
                        {
                            spaceDensity += ws.get_obs[i].getObstacle().Width * ws.get_obs[i].getObstacle().Height;
                        }
                        if (spaceDensity != 0)
                            spaceDensity = (float)((float)spaceDensity / ((float)pictureBox1.Height * (float)pictureBox1.Width));


                        //Rejections = 0 ;
                        if (RRTRadioButton.Checked)
                            textBox1.AppendText("Planner: RRT" + Environment.NewLine);
                        else
                            textBox1.AppendText("Planner: RRTConnect" + Environment.NewLine);

                        if (NearestNeighborLinearradioButton.Checked)
                            textBox1.AppendText("NearestNeighbor: Linear" + Environment.NewLine);
                        else
                            textBox1.AppendText("NearestNeighbor: KDTreeNN" + Environment.NewLine);

                        if (DotRobotRadioButton.Checked)
                            textBox1.AppendText("Robot: Dot robot" + Environment.NewLine);
                        else
                            textBox1.AppendText("Robot: Stick robot" + Environment.NewLine);

                        float rejectionRate = (float)rrt.NumberOfRejections / (float)(allnodes.Count + rrt.NumberOfRejections);

                        textBox1.AppendText("Time Taken : " + rrt.timer + "ms" + Environment.NewLine);
                        textBox1.AppendText("Number of nodes: " + allnodes.Count + Environment.NewLine);
                        textBox1.AppendText("Number of NN computations: " + rrt.NearestNeighborComputations + Environment.NewLine);
                        textBox1.AppendText("Number of rejections: " + rrt.NumberOfRejections + Environment.NewLine);
                        textBox1.AppendText("Enviroment Density : " + spaceDensity + Environment.NewLine);
                        textBox1.AppendText("Bias Nodes Count : " + rrt.BiasNodesCounts + Environment.NewLine);
                        textBox1.AppendText("Rejection Rate : " + rejectionRate + Environment.NewLine);
                        textBox1.AppendText("***************************************" + Environment.NewLine);

                        timer.Reset();
                        button1.Enabled = true;
                        
                    }
                    if (AnimationThread != null && AnimationThread.IsAlive)
                        AnimationThread.Abort();
                }
                else
                {
                    pictureBox2.Refresh();
                }
            }
        }

        bool check = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Move_obstacle_state = false;
        }
        private void AnimateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            animateTime = trackBar1.Value;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            animateTime = trackBar1.Value;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Set Start":
                    itemClickedContextMenu = 1;
                    break;
                case "Set Goal":
                    itemClickedContextMenu = 2;
                    break;
                case "Move Obstacle":
                    itemClickedContextMenu = 3;
                    break;
                case "Delete Obstacle":
                    itemClickedContextMenu = 4;
                    break;
            }
        }

        private void ShowAllNodesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allnodes != null && allnodes.Count != 0)
            {
                drawAllNodes();
            }

        }

        private void ShowSolutionspathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allnodes != null && allnodes.Count != 0)
            {
                DrawSolutionPath();
            }
            Graphics formGraphics = pictureBox1.CreateGraphics();
            for (int i = 0; i < ws.get_obs.Count; i++)
            {
                var pair = ws.get_obs_at_index(i);
                if (pair.Key)
                {
                    formGraphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                }
                else
                {
                    formGraphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                }
            }
        }



        private void drawAllNodes()
        {
            if (allnodes != null && allnodes.Count != 0)
            {
                LinkedList<Node>.Enumerator e_ = allnodes.GetEnumerator();
                Node[] solutionPath = allnodes.ToArray<Node>();
                Node prevNode = solutionPath[solutionPath.Length - 1].Parent;
                Node temp = solutionPath[solutionPath.Length - 1];
                Graphics formGraphics = pictureBox1.CreateGraphics();

                if (ShowAllNodesCheckBox.Checked == false)
                {
                    Pen pen = new Pen(Color.White, 1);
                    while (e_.MoveNext())
                    {

                        float[] p1 = e_.Current.State_.Dimensions;
                        if (e_.Current.Parent == null)
                            continue;
                        float[] p2 = e_.Current.Parent.State_.Dimensions;
                        PointF point1 = new PointF(p1[0], p1[1]);

                        PointF point2 = new PointF(p2[0], p2[1]);
                        lock (formGraphics)
                            formGraphics.DrawLine(pen, point1, point2);

                    }
                    if (ShowSolutionspathCheckBox.Checked == true)
                    {
                        System.Drawing.Pen pen2 = new Pen(Color.Red, 3);
                        //            
                        while (temp.Parent != null)
                        {
                            Point point = new Point((int)temp.State_.Dimensions[0], (int)temp.State_.Dimensions[1]);
                            Point point2 = new Point((int)temp.Parent.State_.Dimensions[0], (int)temp.Parent.State_.Dimensions[1]);

                            formGraphics.DrawLine(pen2, point, point2);
                            temp = temp.Parent;
                        }
                    }

                }
                else
                {
                    Pen pen = new Pen(Color.Blue, 1);
                    while (e_.MoveNext())
                    {

                        float[] p1 = e_.Current.State_.Dimensions;
                        if (e_.Current.Parent == null)
                            continue;
                        float[] p2 = e_.Current.Parent.State_.Dimensions;
                        PointF point1 = new PointF(p1[0], p1[1]);

                        PointF point2 = new PointF(p2[0], p2[1]);
                        lock (formGraphics)
                            formGraphics.DrawLine(pen, point1, point2);

                    }


                }
                for (int i = 0; i < ws.get_obs.Count; i++)
                {
                    var pair = ws.get_obs_at_index(i);
                    if (pair.Key)
                    {
                        formGraphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                    }
                    else
                    {
                        formGraphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                    }
                }
                formGraphics.Dispose();
            }
        }
    

        private void DrawSolutionPath()
        {
            if (allnodes != null && allnodes.Count != 0)
            {
                LinkedList<Node>.Enumerator e_ = allnodes.GetEnumerator();
                Node[] solutionPath = allnodes.ToArray<Node>();
                Node prevNode = solutionPath[solutionPath.Length - 1].Parent;
                Node temp = solutionPath[solutionPath.Length - 1];
                Graphics formGraphics = pictureBox1.CreateGraphics();
                if (ShowSolutionspathCheckBox.Checked == false)
                {

                    System.Drawing.Pen pen2 = new Pen(Color.White, 3);
                    //            
                    while (temp.Parent != null)
                    {
                        Point point = new Point((int)temp.State_.Dimensions[0], (int)temp.State_.Dimensions[1]);
                        Point point2 = new Point((int)temp.Parent.State_.Dimensions[0], (int)temp.Parent.State_.Dimensions[1]);
                        formGraphics.DrawLine(pen2, point, point2);
                        temp = temp.Parent;
                    }
                    if (ShowAllNodesCheckBox.Checked)
                    {
                        Pen pen = new Pen(Color.Blue, 1);
                        while (e_.MoveNext())
                        {
                            float[] p1 = e_.Current.State_.Dimensions;
                            if (e_.Current.Parent == null)
                                continue;
                            float[] p2 = e_.Current.Parent.State_.Dimensions;
                            PointF point1 = new PointF(p1[0], p1[1]);

                            PointF point2 = new PointF(p2[0], p2[1]);
                            lock (formGraphics) // for mutual-exclusion cuz threads
                            {

                                formGraphics.DrawLine(pen, point1, point2);
                            }
                        }
                    }
                }
                else
                {
                    System.Drawing.Pen pen2 = new Pen(Color.Red, 3);
                    while (temp.Parent != null)
                    {
                        if (StickRobotRadioButton.Checked) // PROBLEM IN THE DRAWING HERE !!!
                        {
                            //Robot robot = new RobotStick();
                            //textBox1.Text += temp.State_.Dimensions.Length + " , ";

                            //robot.robotBody = temp.State_;
                            //State toppoint2 = robot.GetTopPoint();

                            //State BotPoint2 = robot.GetBotPoint();

                            //formGraphics.DrawLine(new Pen(Color.Red), toppoint2.Dimensions[0], toppoint2.Dimensions[1], BotPoint2.Dimensions[0], BotPoint2.Dimensions[1]);
                            ////formGraphics.FillEllipse(new SolidBrush(Color.DarkRed), new Rectangle((int)top[0], (int)top[1], 5, 5));
                            //if (AnimateCheckBox.Checked)
                            //    Thread.Sleep(animateTime);
                        }
                        else
                        {
                            Point point = new Point((int)temp.State_.Dimensions[0], (int)temp.State_.Dimensions[1]);
                            Point point2 = new Point((int)temp.Parent.State_.Dimensions[0], (int)temp.Parent.State_.Dimensions[1]);
                            formGraphics.DrawLine(new Pen(Color.Red, 3), point, point2);
                            if (AnimateCheckBox.Checked)
                                Thread.Sleep(animateTime);
                        }

                        temp = temp.Parent;
                    }
                }
                for (int i = 0; i < ws.get_obs.Count; i++)
                {
                    var pair = ws.get_obs_at_index(i);
                    if (pair.Key)
                    {
                        formGraphics.DrawRectangle(new Pen(Color.Black), pair.Value);
                    }
                    else
                    {
                        formGraphics.DrawEllipse(new Pen(Color.Black), pair.Value);
                    }
                }
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                brush.Color = System.Drawing.Color.Red;
                formGraphics.FillEllipse(brush, new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));
                brush = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
                formGraphics.FillEllipse(brush, new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));

                formGraphics.Dispose();
            }
        }
        private void drawRobot()
        {
            if (StickRobotRadioButton.Checked)
            {
                if (allnodes != null && allnodes.Count != 0)
                {
                    Node node = allnodes.Last.Value;

                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics G = pictureBox1.CreateGraphics();
                    Graphics g = Graphics.FromImage(bmp);

                    Robot robo = new RobotStick();
                    robo.RobotHieght = int.Parse(RobotHeightTextBox.Text);
                    while (node.Parent != null)
                    {
                        robo.robotBody = node.State_;
                        State top = robo.GetTopPoint();
                        State buttom = robo.GetBotPoint();
                        Point p1 = new Point((int)top.Dimensions[0], (int)top.Dimensions[1]);
                        Point p2 = new Point((int)buttom.Dimensions[0], (int)buttom.Dimensions[1]);

                        g.DrawLine(new Pen(Color.Red, 2), p1, p2);
                        for (int i = 0; i < ws.get_obs.Count; i++)
                        {
                            var pair = ws.get_obs_at_index(i);
                            if (pair.Key)
                            {
                                g.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                            }
                            else
                            {
                                g.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                            }
                        }

                        g.FillEllipse(new SolidBrush(Color.Red), ws.Start.Dimensions[0], ws.Start.Dimensions[1], 5, 5);
                        g.FillEllipse(new SolidBrush(Color.Purple), ws.Goal.Dimensions[0], ws.Goal.Dimensions[1], 5, 5);

                        G.DrawImage(bmp, 0, 0);
                        Thread.Sleep(animateTime);
                        g.Clear(Color.White);
                        node = node.Parent;
                    }
                    g.Dispose();
                }
            }
        }
        private void ClearNodesButton_Click(object sender, EventArgs e)
        {
            Graphics formGraphics = pictureBox1.CreateGraphics();
            formGraphics.Clear(Color.White);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            brush.Color = System.Drawing.Color.Red;
            formGraphics.FillEllipse(brush, new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
            formGraphics.FillEllipse(brush, new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));

            for (int i = 0; i < ws.get_obs.Count; i++)
            {
                var pair = ws.get_obs_at_index(i);
                if (pair.Key)
                {
                    formGraphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                }
                else
                {
                    formGraphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                }
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //Pogress_bar_thread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear workspace? ", "Clear workspace", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ws.Remove_everything();
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                select_cancel = false;
            }
            else
                select_cancel = true;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void NearestNeighborLinearradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        void SaveWorkSpace()
        {
            SaveFileDialog savedialog = new SaveFileDialog();

            string startupPath;
            savedialog.InitialDirectory = startupPath = System.IO.Directory.GetCurrentDirectory();
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(savedialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, ws);
                stream.Close();
            }
        }
        void LoadWorkSpace()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            string startupPath;
            openfile.InitialDirectory = startupPath = System.IO.Directory.GetCurrentDirectory();

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openfile.FileName) != "") //files dont have an extension.
                {
                    MessageBox.Show("please select a propre file format");
                }
                else
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Workspace ws1 = (Workspace)formatter.Deserialize(stream);
                    stream.Close();
                    ws = ws1;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveWorkSpace();
        }

        private void loadWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            if (!select_cancel)
            {
                LoadWorkSpace();
                drawWorkSpace();
                select_cancel = false;
            }
        }
        public void drawWorkSpace()
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            for (int i = 0; i < ws.get_obs.Count; i++)
            {
                var pair = ws.get_obs_at_index(i);
                if (pair.Key)
                {
                    graphics.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                }
                else
                {
                    graphics.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                }
            }

            graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle((int)ws.Start.Dimensions[0], (int)ws.Start.Dimensions[1], 10, 10));
            graphics.FillEllipse(new SolidBrush(Color.Purple), new Rectangle((int)ws.Goal.Dimensions[0], (int)ws.Goal.Dimensions[1], 10, 10));
            graphics.Dispose();
        }

        private void clearWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void drawRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawRectangleradioButton.Checked = true;
        }

        private void DrawRectangleradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void drawCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawCircleradioButton.Checked = true;
        }

        private void setStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rRTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RRTRadioButton.Checked = true;
        }

        private void rRTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RRTConnectRadioButton.Checked = true;
        }

        private void setBiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(savefile.FileName);
                sw.Write(textBox1.Text);
                sw.WriteLine("*********************************************");
                sw.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DrawCircleradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Pogress_bar_thread.IsAlive)
            {
                Pogress_bar_thread = new Thread((() => drawRobot()));
                Pogress_bar_thread.SetApartmentState(ApartmentState.STA);
                Pogress_bar_thread.IsBackground = false;
                Pogress_bar_thread.Start();
            }
        }

        bool check5 = false;
        private void StopButton_Click(object sender, EventArgs e)
        {
            SmoothingButton.Enabled = true;
            ClearNodesButton.Enabled = true;
            button2.Enabled = true;
            DotRobotRadioButton.Enabled = true;
            StickRobotRadioButton.Enabled = true;
            AnimateCheckBox.Enabled = true;
            ShowAllNodesCheckBox.Enabled = true;
            ShowSolutionspathCheckBox.Enabled = true;
            pictureBox2.Hide();
            if (Pogress_bar_thread != null)
            {
                if (Pogress_bar_thread.IsAlive)
                {
                    Pogress_bar_thread.Abort();
                }
            }
            if (AnimationThread != null)
            {
                if (AnimationThread.IsAlive)
                {
                    AnimationThread.Abort();
                }
            }
            if(RobotThread != null)
            {
                if (RobotThread.IsAlive)
                {
                    RobotThread.Abort();
                }
            }
            button1.Enabled = true;
        }



        private void SmoothingButton_Click(object sender, EventArgs e)
        {
            Pogress_bar_thread = new Thread((() => Smooth()));
            Pogress_bar_thread.SetApartmentState(ApartmentState.STA);
            Pogress_bar_thread.IsBackground = false;
            Pogress_bar_thread.Start();
             

            
        }

        public void Smooth()
        {
            if (allnodes != null && allnodes.Count != 0)
            {


                List<Node> smoothingalldayerryday = new List<Node>();
                ClearNodesButton.PerformClick();
                Node current;
                Node it;
                bool hasSucceded = false;
                Node current2;
                bool firstime = true;
                Graphics drawing = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Color.Green, 3);

                LinkedList<Node> DummyPath = new LinkedList<Node>();

                List<Node> solutionPath = new List<Node>();
                Node goal2;
                Node movingnode;
                Node start2;
                int counter;
                //if (first)
                //{
                current = allnodes.Last.Value;
                it = allnodes.First.Value;
                hasSucceded = false;
                firstime = true;
                current2 = current;
                // first = false;

                while (current != null)
                {
                    solutionPath.Add(current);
                    current = current.Parent;
                }
                goal2 = solutionPath[0];
                movingnode = solutionPath[0];
                start2 = solutionPath[solutionPath.Count - 1];

                counter = 0;
                //}
                //else
                //{
                //    current = smoothedSolutionPath[1];
                //    drawing.FillEllipse(new SolidBrush(Color.Aqua), new Rectangle((int)smoothedSolutionPath[1].State_.Dimensions[0], (int)smoothedSolutionPath[1].State_.Dimensions[1], 20, 20));
                //    drawing.FillEllipse(new SolidBrush(Color.Brown), new Rectangle((int)smoothedSolutionPath[smoothedSolutionPath.Count - 1].State_.Dimensions[0], (int)smoothedSolutionPath[smoothedSolutionPath.Count - 1].State_.Dimensions[1], 20, 20));
                //    it = smoothedSolutionPath[0];
                //    hasSucceded = false;
                //    firstime = true;
                //    current2 = current;
                //    first = !first;

                //    //while (current != null)
                //    //{
                //    //    solutionPath.Add(current);
                //    //    current = current.Parent;
                //    //}

                //    for (int i = 0; i < smoothedSolutionPath.Count; i++)
                //    {
                //        solutionPath.Add(smoothedSolutionPath[i]);
                //    }

                //    goal2 = solutionPath[solutionPath.Count - 1];
                //    movingnode = solutionPath[1];
                //    start2 = allnodes.First.Value;
                //    counter = 0;
                //}


                //while (current != null)
                //{
                //    solutionPath.Add(current);
                //    current = current.Parent;
                //}
                //Node goal2 = solutionPath[0];
                //Node movingnode = solutionPath[0];
                //Node start2 = solutionPath[solutionPath.Count-1];
                //int counter = 0;

                List<Node> dummySolPath = new List<Node>();
                //smoothedSolutionPath.Add(start2);
                Robot robot;
                if (DotRobotRadioButton.Checked)
                {
                    robot = new RobotDot();
                }
                else
                {
                    robot = new RobotStick();
                    robot.RobotHieght = int.Parse(RobotHeightTextBox.Text);
                }
                while (start2 != goal2)
                {
                    movingnode = solutionPath[counter];
                    // drawing.DrawEllipse(new Pen(Color.Red, 3), new Rectangle((int)movingnode.State_.Dimensions[0], (int)movingnode.State_.Dimensions[1], 5, 5));

                    while (true)
                    {
                        Node node = new Node();
                        float[] x0 = movingnode.State_.Dimensions;
                        float[] statenew = new float[movingnode.State_.Dimensions.Length];
                        float length = 0;
                        calculate_inpterpolation(ref statenew, ref length, movingnode, start2.State_, x0);
                        robot.robotBody.Dimensions = statenew;

                        if (ws.is_valid((int)statenew[0], (int)statenew[1]) != -1)
                        {
                            counter++;
                            hasSucceded = false;
                            dummySolPath.Clear();
                            break;
                        }
                        if (StickRobotRadioButton.Checked)
                        {
                            State toppoint = robot.GetTopPoint();
                            State BotPoint = robot.GetBotPoint();
                            if (ws.is_valid((int)toppoint.Dimensions[0], (int)toppoint.Dimensions[1]) != -1)
                            {
                                counter++;
                                hasSucceded = false;
                                dummySolPath = new List<Node>();
                                break;
                            }
                            if (ws.is_valid((int)BotPoint.Dimensions[0], (int)BotPoint.Dimensions[1]) != -1)
                            {
                                counter++;
                                dummySolPath = new List<Node>();
                                hasSucceded = false;
                                break;
                            }
                        }
                        node = new Node(current2, new State(robot.robotBody.Dimensions));
                        float distance_to_randompoint;
                        distance_to_randompoint = calculate_distance(out distance_to_randompoint, node, start2.State_);
                        dummySolPath.Add(node);

                        if (distance_to_randompoint <= k)
                        {
                            //smoothedSolutionPath.Add(solutionPath[counter]);
                            //drawing.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle((int)solutionPath[counter].State_.Dimensions[0], (int)solutionPath[counter].State_.Dimensions[1], 5, 5));

                            hasSucceded = true;
                            //dummySolPath.Add(start2);
                            start2 = solutionPath[counter++];
                            //start2 = movingnode;
                            //drawing.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle((int)dummySolPath[dummySolPath.Count - 1].State_.Dimensions[0], (int)dummySolPath[dummySolPath.Count - 1].State_.Dimensions[1], 5, 5));

                            for (int i = dummySolPath.Count - 1; i >= 0; i--)
                            {
                                smoothedSolutionPath.Add(dummySolPath[i]);
                                // drawing.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle((int)dummySolPath[i].State_.Dimensions[0], (int)dummySolPath[i].State_.Dimensions[1], 5, 5));
                                //   Thread.Sleep(50);
                            }

                            //movingnode = smoothedSolutionPath[smoothedSolutionPath.Count - 1];
                            counter = 0;

                            dummySolPath = new List<Node>();
                            break;
                        }
                        //if (!first)
                        //    drawing.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle((int)node.State_.Dimensions[0], (int)node.State_.Dimensions[1], 5, 5));

                        movingnode = node;

                    }
                }

                Robot robo = new RobotStick();
                robo.RobotHieght = int.Parse(RobotHeightTextBox.Text);
                for (int i = 1; i < smoothedSolutionPath.Count - 1; i++)
                {
                    if (StickRobotRadioButton.Checked)
                    {
                        robo.robotBody = smoothedSolutionPath[i].State_;
                        State top = robo.GetTopPoint();
                        State buttom = robo.GetBotPoint();
                        Point p1 = new Point((int)top.Dimensions[0], (int)top.Dimensions[1]);
                        Point p2 = new Point((int)buttom.Dimensions[0], (int)buttom.Dimensions[1]);
                        drawing.DrawLine(new Pen(Color.Purple, 2), p1, p2);
                    }


                    drawing.DrawLine(new Pen(Color.Orange, 2), (int)smoothedSolutionPath[i].State_.Dimensions[0], (int)smoothedSolutionPath[i].State_.Dimensions[1], (int)smoothedSolutionPath[i - 1].State_.Dimensions[0], (int)smoothedSolutionPath[i - 1].State_.Dimensions[1]);
                    //Thread.Sleep(50);
                }
                //drawing.FillEllipse(new SolidBrush(Color.Aqua), new Rectangle((int)smoothedSolutionPath[1].State_.Dimensions[0], (int)smoothedSolutionPath[1].State_.Dimensions[1], 20, 20));
                //drawing.FillEllipse(new SolidBrush(Color.Brown), new Rectangle((int)smoothedSolutionPath[smoothedSolutionPath.Count - 1].State_.Dimensions[0], (int)smoothedSolutionPath[smoothedSolutionPath.Count - 1].State_.Dimensions[1], 20, 20));

                drawing.Dispose();
            }

        }
        
                    
 
        private float calculate_distance(out float distance_to_goal, Node node, State goal)
        {
            distance_to_goal = 0;
            for (int i = 0; i < 2; i++) // node.State_.Dimensions.Length
            {
                distance_to_goal += (float)Math.Pow((node.State_.Dimensions[i]) - (goal.Dimensions[i]), 2);
            }
            distance_to_goal = (float)Math.Sqrt(distance_to_goal);
            return distance_to_goal;
        }

        private void calculate_inpterpolation(ref float[] statenew_, ref float Length_, Node nearestneighbor_, State RandomState_, float[] x0_)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter_1(object sender, EventArgs e)
        {

        }

        private void showSolutionPathOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearNodesButton.PerformClick();
            drawAllNodes();
            DrawSolutionPath();
            //Graphics g = pictureBox1.CreateGraphics();
            //Node node = allnodes.Last.Value;
            //while (node.Parent != null)
            //{
            //    g.DrawLine(new Pen(Color.Red,3), (int)node.State_.Dimensions[0], (int)node.State_.Dimensions[1], (int)node.State_.Dimensions[0], (int)node.State_.Dimensions[1]);
            //    node = node.Parent;
            //}
            //g.Dispose();
        }

        private void showSequenceOfActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RobotThread = new Thread((() => robotAnimationwithhistory()));
            RobotThread.SetApartmentState(ApartmentState.STA);
            RobotThread.IsBackground = true;
            RobotThread.Start();

        }

        void robotAnimationwithhistory()
        {
            if (allnodes != null && allnodes.Count != 0)
            {
                Node node = allnodes.Last.Value;

                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics G = pictureBox1.CreateGraphics();
                Graphics g = Graphics.FromImage(bmp);
                Robot robo = new RobotStick();
                robo.RobotHieght = float.Parse(RobotHeightTextBox.Text);
                if (DotRobotRadioButton.Checked)
                {
                    robo = new RobotDot();
                }
                while (node.Parent != null)
                {
                    robo.robotBody = node.State_;
                    State top = robo.GetTopPoint();
                    State buttom = robo.GetBotPoint();
                    Point p1 = new Point((int)top.Dimensions[0], (int)top.Dimensions[1]);
                    Point p2 = new Point((int)buttom.Dimensions[0], (int)buttom.Dimensions[1]);

                    g.DrawLine(new Pen(Color.Red, 2), p1, p2);
                    for (int i = 0; i < ws.get_obs.Count; i++)
                    {
                        var pair = ws.get_obs_at_index(i);
                        if (pair.Key)
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), pair.Value);
                        }
                        else
                        {
                            g.FillEllipse(new SolidBrush(Color.Black), pair.Value);
                        }
                    }

                    g.FillEllipse(new SolidBrush(Color.Red), ws.Start.Dimensions[0], ws.Start.Dimensions[1], 5, 5);
                    g.FillEllipse(new SolidBrush(Color.Purple), ws.Goal.Dimensions[0], ws.Goal.Dimensions[1], 5, 5);

                    G.DrawImage(bmp, 0, 0);
                    node = node.Parent;
                }
                g.Dispose();

            }
        }

        private void RobotHeightTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
