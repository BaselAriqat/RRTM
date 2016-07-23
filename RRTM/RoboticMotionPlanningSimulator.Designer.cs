namespace RRTM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SmoothingButton = new System.Windows.Forms.Button();
            this.RobotHeightTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.StickRobotRadioButton = new System.Windows.Forms.RadioButton();
            this.DotRobotRadioButton = new System.Windows.Forms.RadioButton();
            this.Planner = new System.Windows.Forms.GroupBox();
            this.RRTRadioButton = new System.Windows.Forms.RadioButton();
            this.RRTConnectRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.NearestNeighborKDtreeNNradioButton = new System.Windows.Forms.RadioButton();
            this.NearestNeighborLinearradioButton = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DrawRectangleradioButton = new System.Windows.Forms.RadioButton();
            this.DrawCircleradioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClearNodesButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.AnimateCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowSolutionspathCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowAllNodesCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxNTextBox = new System.Windows.Forms.MaskedTextBox();
            this.BiasTextBox = new System.Windows.Forms.MaskedTextBox();
            this.kTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGoalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseSolverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rRTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rRTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setBiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMaxnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benchmarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSequenceOfActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSolutionPathOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leComeLeGoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.Planner.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(16, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "find solution";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SmoothingButton);
            this.groupBox1.Controls.Add(this.RobotHeightTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.Planner);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ClearNodesButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.AnimateCheckBox);
            this.groupBox1.Controls.Add(this.ShowSolutionspathCheckBox);
            this.groupBox1.Controls.Add(this.ShowAllNodesCheckBox);
            this.groupBox1.Controls.Add(this.MaxNTextBox);
            this.groupBox1.Controls.Add(this.BiasTextBox);
            this.groupBox1.Controls.Add(this.kTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(781, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 742);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SmoothingButton
            // 
            this.SmoothingButton.Location = new System.Drawing.Point(16, 76);
            this.SmoothingButton.Name = "SmoothingButton";
            this.SmoothingButton.Size = new System.Drawing.Size(198, 23);
            this.SmoothingButton.TabIndex = 31;
            this.SmoothingButton.Text = "Smooth path";
            this.SmoothingButton.UseVisualStyleBackColor = true;
            this.SmoothingButton.Click += new System.EventHandler(this.SmoothingButton_Click);
            // 
            // RobotHeightTextBox
            // 
            this.RobotHeightTextBox.Location = new System.Drawing.Point(114, 380);
            this.RobotHeightTextBox.Mask = "00000";
            this.RobotHeightTextBox.Name = "RobotHeightTextBox";
            this.RobotHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.RobotHeightTextBox.TabIndex = 30;
            this.RobotHeightTextBox.Text = "10";
            this.RobotHeightTextBox.ValidatingType = typeof(int);
            this.RobotHeightTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.RobotHeightTextBox_MaskInputRejected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Set Robot Height";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(119, 19);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(98, 23);
            this.StopButton.TabIndex = 28;
            this.StopButton.Text = "Stop ";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.StickRobotRadioButton);
            this.groupBox6.Controls.Add(this.DotRobotRadioButton);
            this.groupBox6.Location = new System.Drawing.Point(8, 207);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(100, 80);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Robot";
            // 
            // StickRobotRadioButton
            // 
            this.StickRobotRadioButton.AutoSize = true;
            this.StickRobotRadioButton.Location = new System.Drawing.Point(4, 43);
            this.StickRobotRadioButton.Name = "StickRobotRadioButton";
            this.StickRobotRadioButton.Size = new System.Drawing.Size(81, 17);
            this.StickRobotRadioButton.TabIndex = 1;
            this.StickRobotRadioButton.TabStop = true;
            this.StickRobotRadioButton.Text = "Stick Robot";
            this.StickRobotRadioButton.UseVisualStyleBackColor = true;
            this.StickRobotRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // DotRobotRadioButton
            // 
            this.DotRobotRadioButton.AutoSize = true;
            this.DotRobotRadioButton.Checked = true;
            this.DotRobotRadioButton.Location = new System.Drawing.Point(4, 19);
            this.DotRobotRadioButton.Name = "DotRobotRadioButton";
            this.DotRobotRadioButton.Size = new System.Drawing.Size(72, 17);
            this.DotRobotRadioButton.TabIndex = 0;
            this.DotRobotRadioButton.TabStop = true;
            this.DotRobotRadioButton.Text = "dot Robot";
            this.DotRobotRadioButton.UseVisualStyleBackColor = true;
            this.DotRobotRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Planner
            // 
            this.Planner.Controls.Add(this.RRTRadioButton);
            this.Planner.Controls.Add(this.RRTConnectRadioButton);
            this.Planner.Location = new System.Drawing.Point(7, 121);
            this.Planner.Name = "Planner";
            this.Planner.Size = new System.Drawing.Size(101, 80);
            this.Planner.TabIndex = 26;
            this.Planner.TabStop = false;
            this.Planner.Text = "Planner";
            // 
            // RRTRadioButton
            // 
            this.RRTRadioButton.AutoSize = true;
            this.RRTRadioButton.Checked = true;
            this.RRTRadioButton.Location = new System.Drawing.Point(8, 19);
            this.RRTRadioButton.Name = "RRTRadioButton";
            this.RRTRadioButton.Size = new System.Drawing.Size(48, 17);
            this.RRTRadioButton.TabIndex = 17;
            this.RRTRadioButton.TabStop = true;
            this.RRTRadioButton.Text = "RRT";
            this.RRTRadioButton.UseVisualStyleBackColor = true;
            // 
            // RRTConnectRadioButton
            // 
            this.RRTConnectRadioButton.AutoSize = true;
            this.RRTConnectRadioButton.Location = new System.Drawing.Point(8, 42);
            this.RRTConnectRadioButton.Name = "RRTConnectRadioButton";
            this.RRTConnectRadioButton.Size = new System.Drawing.Size(88, 17);
            this.RRTConnectRadioButton.TabIndex = 18;
            this.RRTConnectRadioButton.TabStop = true;
            this.RRTConnectRadioButton.Text = "RRTConnect";
            this.RRTConnectRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.NearestNeighborKDtreeNNradioButton);
            this.groupBox5.Controls.Add(this.NearestNeighborLinearradioButton);
            this.groupBox5.Location = new System.Drawing.Point(114, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(119, 80);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nearest Neighbor ";
            // 
            // NearestNeighborKDtreeNNradioButton
            // 
            this.NearestNeighborKDtreeNNradioButton.AutoSize = true;
            this.NearestNeighborKDtreeNNradioButton.Location = new System.Drawing.Point(7, 38);
            this.NearestNeighborKDtreeNNradioButton.Name = "NearestNeighborKDtreeNNradioButton";
            this.NearestNeighborKDtreeNNradioButton.Size = new System.Drawing.Size(78, 17);
            this.NearestNeighborKDtreeNNradioButton.TabIndex = 1;
            this.NearestNeighborKDtreeNNradioButton.Text = "KDTreeNN";
            this.NearestNeighborKDtreeNNradioButton.UseVisualStyleBackColor = true;
            // 
            // NearestNeighborLinearradioButton
            // 
            this.NearestNeighborLinearradioButton.AutoSize = true;
            this.NearestNeighborLinearradioButton.Checked = true;
            this.NearestNeighborLinearradioButton.Location = new System.Drawing.Point(7, 20);
            this.NearestNeighborLinearradioButton.Name = "NearestNeighborLinearradioButton";
            this.NearestNeighborLinearradioButton.Size = new System.Drawing.Size(70, 17);
            this.NearestNeighborLinearradioButton.TabIndex = 0;
            this.NearestNeighborLinearradioButton.TabStop = true;
            this.NearestNeighborLinearradioButton.Text = "NNLinear";
            this.NearestNeighborLinearradioButton.UseVisualStyleBackColor = true;
            this.NearestNeighborLinearradioButton.CheckedChanged += new System.EventHandler(this.NearestNeighborLinearradioButton_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(140, 429);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(99, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Clear Workspace";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DrawRectangleradioButton);
            this.groupBox3.Controls.Add(this.DrawCircleradioButton);
            this.groupBox3.Location = new System.Drawing.Point(114, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 80);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drawing";
            // 
            // DrawRectangleradioButton
            // 
            this.DrawRectangleradioButton.AutoSize = true;
            this.DrawRectangleradioButton.Checked = true;
            this.DrawRectangleradioButton.Location = new System.Drawing.Point(6, 19);
            this.DrawRectangleradioButton.Name = "DrawRectangleradioButton";
            this.DrawRectangleradioButton.Size = new System.Drawing.Size(102, 17);
            this.DrawRectangleradioButton.TabIndex = 21;
            this.DrawRectangleradioButton.TabStop = true;
            this.DrawRectangleradioButton.Text = "Draw Recatngle";
            this.DrawRectangleradioButton.UseVisualStyleBackColor = true;
            this.DrawRectangleradioButton.CheckedChanged += new System.EventHandler(this.DrawRectangleradioButton_CheckedChanged);
            // 
            // DrawCircleradioButton
            // 
            this.DrawCircleradioButton.AutoSize = true;
            this.DrawCircleradioButton.Location = new System.Drawing.Point(6, 43);
            this.DrawCircleradioButton.Name = "DrawCircleradioButton";
            this.DrawCircleradioButton.Size = new System.Drawing.Size(79, 17);
            this.DrawCircleradioButton.TabIndex = 22;
            this.DrawCircleradioButton.TabStop = true;
            this.DrawCircleradioButton.Text = "Draw Circle";
            this.DrawCircleradioButton.UseVisualStyleBackColor = true;
            this.DrawCircleradioButton.CheckedChanged += new System.EventHandler(this.DrawCircleradioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-110, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(65, 44);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // ClearNodesButton
            // 
            this.ClearNodesButton.Location = new System.Drawing.Point(119, 47);
            this.ClearNodesButton.Name = "ClearNodesButton";
            this.ClearNodesButton.Size = new System.Drawing.Size(98, 23);
            this.ClearNodesButton.TabIndex = 19;
            this.ClearNodesButton.Text = "clear nodes";
            this.ClearNodesButton.UseVisualStyleBackColor = true;
            this.ClearNodesButton.Click += new System.EventHandler(this.ClearNodesButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 546);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(211, 106);
            this.textBox1.TabIndex = 16;
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 482);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(211, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // AnimateCheckBox
            // 
            this.AnimateCheckBox.AutoSize = true;
            this.AnimateCheckBox.Location = new System.Drawing.Point(15, 459);
            this.AnimateCheckBox.Name = "AnimateCheckBox";
            this.AnimateCheckBox.Size = new System.Drawing.Size(64, 17);
            this.AnimateCheckBox.TabIndex = 14;
            this.AnimateCheckBox.Text = "Animate";
            this.AnimateCheckBox.UseVisualStyleBackColor = true;
            this.AnimateCheckBox.CheckedChanged += new System.EventHandler(this.AnimateCheckBox_CheckedChanged);
            // 
            // ShowSolutionspathCheckBox
            // 
            this.ShowSolutionspathCheckBox.AutoSize = true;
            this.ShowSolutionspathCheckBox.Location = new System.Drawing.Point(15, 435);
            this.ShowSolutionspathCheckBox.Name = "ShowSolutionspathCheckBox";
            this.ShowSolutionspathCheckBox.Size = new System.Drawing.Size(119, 17);
            this.ShowSolutionspathCheckBox.TabIndex = 13;
            this.ShowSolutionspathCheckBox.Text = "Show Solution Path";
            this.ShowSolutionspathCheckBox.UseVisualStyleBackColor = true;
            this.ShowSolutionspathCheckBox.CheckedChanged += new System.EventHandler(this.ShowSolutionspathCheckBox_CheckedChanged);
            // 
            // ShowAllNodesCheckBox
            // 
            this.ShowAllNodesCheckBox.AutoSize = true;
            this.ShowAllNodesCheckBox.Location = new System.Drawing.Point(15, 411);
            this.ShowAllNodesCheckBox.Name = "ShowAllNodesCheckBox";
            this.ShowAllNodesCheckBox.Size = new System.Drawing.Size(101, 17);
            this.ShowAllNodesCheckBox.TabIndex = 12;
            this.ShowAllNodesCheckBox.Text = "Show All Nodes";
            this.ShowAllNodesCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllNodesCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllNodesCheckBox_CheckedChanged);
            // 
            // MaxNTextBox
            // 
            this.MaxNTextBox.Location = new System.Drawing.Point(114, 351);
            this.MaxNTextBox.Mask = "0000000";
            this.MaxNTextBox.Name = "MaxNTextBox";
            this.MaxNTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxNTextBox.TabIndex = 11;
            this.MaxNTextBox.Text = "99999";
            this.MaxNTextBox.ValidatingType = typeof(int);
            // 
            // BiasTextBox
            // 
            this.BiasTextBox.Location = new System.Drawing.Point(114, 325);
            this.BiasTextBox.Mask = "000";
            this.BiasTextBox.Name = "BiasTextBox";
            this.BiasTextBox.Size = new System.Drawing.Size(100, 20);
            this.BiasTextBox.TabIndex = 10;
            this.BiasTextBox.Text = "2";
            this.BiasTextBox.ValidatingType = typeof(int);
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(114, 300);
            this.kTextBox.Mask = "00000";
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 20);
            this.kTextBox.TabIndex = 9;
            this.kTextBox.Text = "5";
            this.kTextBox.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Set MaxN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "set Bias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "set K";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Benchmarks:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.solverToolStripMenuItem,
            this.benchmarkingToolStripMenuItem,
            this.halpToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.loadWorkspaceToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "Save Workspace";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // loadWorkspaceToolStripMenuItem
            // 
            this.loadWorkspaceToolStripMenuItem.Name = "loadWorkspaceToolStripMenuItem";
            this.loadWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.loadWorkspaceToolStripMenuItem.Text = "Load Workspace";
            this.loadWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.loadWorkspaceToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearWorkspaceToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.setStartToolStripMenuItem,
            this.setGoalToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearWorkspaceToolStripMenuItem
            // 
            this.clearWorkspaceToolStripMenuItem.Name = "clearWorkspaceToolStripMenuItem";
            this.clearWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.clearWorkspaceToolStripMenuItem.Text = "Clear Workspace";
            this.clearWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.clearWorkspaceToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleToolStripMenuItem,
            this.drawCircleToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawRectangleToolStripMenuItem
            // 
            this.drawRectangleToolStripMenuItem.Name = "drawRectangleToolStripMenuItem";
            this.drawRectangleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.drawRectangleToolStripMenuItem.Text = "Draw Rectangle";
            this.drawRectangleToolStripMenuItem.Click += new System.EventHandler(this.drawRectangleToolStripMenuItem_Click);
            // 
            // drawCircleToolStripMenuItem
            // 
            this.drawCircleToolStripMenuItem.Name = "drawCircleToolStripMenuItem";
            this.drawCircleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.drawCircleToolStripMenuItem.Text = "Draw Circle";
            this.drawCircleToolStripMenuItem.Click += new System.EventHandler(this.drawCircleToolStripMenuItem_Click);
            // 
            // setStartToolStripMenuItem
            // 
            this.setStartToolStripMenuItem.Name = "setStartToolStripMenuItem";
            this.setStartToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setStartToolStripMenuItem.Text = "Set Start";
            this.setStartToolStripMenuItem.Click += new System.EventHandler(this.setStartToolStripMenuItem_Click);
            // 
            // setGoalToolStripMenuItem
            // 
            this.setGoalToolStripMenuItem.Name = "setGoalToolStripMenuItem";
            this.setGoalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setGoalToolStripMenuItem.Text = "Set Goal";
            // 
            // solverToolStripMenuItem
            // 
            this.solverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseSolverToolStripMenuItem,
            this.setBiasToolStripMenuItem,
            this.setMaxnToolStripMenuItem,
            this.setKToolStripMenuItem});
            this.solverToolStripMenuItem.Name = "solverToolStripMenuItem";
            this.solverToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.solverToolStripMenuItem.Text = "Planner";
            // 
            // chooseSolverToolStripMenuItem
            // 
            this.chooseSolverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rRTToolStripMenuItem,
            this.rRTToolStripMenuItem1});
            this.chooseSolverToolStripMenuItem.Name = "chooseSolverToolStripMenuItem";
            this.chooseSolverToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.chooseSolverToolStripMenuItem.Text = "Choose Planner";
            // 
            // rRTToolStripMenuItem
            // 
            this.rRTToolStripMenuItem.Name = "rRTToolStripMenuItem";
            this.rRTToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.rRTToolStripMenuItem.Text = "RRT";
            this.rRTToolStripMenuItem.Click += new System.EventHandler(this.rRTToolStripMenuItem_Click);
            // 
            // rRTToolStripMenuItem1
            // 
            this.rRTToolStripMenuItem1.Name = "rRTToolStripMenuItem1";
            this.rRTToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.rRTToolStripMenuItem1.Text = "RRTConnect";
            this.rRTToolStripMenuItem1.Click += new System.EventHandler(this.rRTToolStripMenuItem1_Click);
            // 
            // setBiasToolStripMenuItem
            // 
            this.setBiasToolStripMenuItem.Name = "setBiasToolStripMenuItem";
            this.setBiasToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.setBiasToolStripMenuItem.Text = "Set Bias";
            this.setBiasToolStripMenuItem.Click += new System.EventHandler(this.setBiasToolStripMenuItem_Click);
            // 
            // setMaxnToolStripMenuItem
            // 
            this.setMaxnToolStripMenuItem.Name = "setMaxnToolStripMenuItem";
            this.setMaxnToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.setMaxnToolStripMenuItem.Text = "Set Maxn";
            // 
            // setKToolStripMenuItem
            // 
            this.setKToolStripMenuItem.Name = "setKToolStripMenuItem";
            this.setKToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.setKToolStripMenuItem.Text = "Set K";
            // 
            // benchmarkingToolStripMenuItem
            // 
            this.benchmarkingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem,
            this.clearResultsToolStripMenuItem});
            this.benchmarkingToolStripMenuItem.Name = "benchmarkingToolStripMenuItem";
            this.benchmarkingToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.benchmarkingToolStripMenuItem.Text = "Benchmarking";
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveResultsToolStripMenuItem.Text = "Save Results";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // clearResultsToolStripMenuItem
            // 
            this.clearResultsToolStripMenuItem.Name = "clearResultsToolStripMenuItem";
            this.clearResultsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.clearResultsToolStripMenuItem.Text = "Clear Results";
            // 
            // halpToolStripMenuItem
            // 
            this.halpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rektToolStripMenuItem,
            this.showSequenceOfActionsToolStripMenuItem,
            this.showSolutionPathOnlyToolStripMenuItem});
            this.halpToolStripMenuItem.Name = "halpToolStripMenuItem";
            this.halpToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.halpToolStripMenuItem.Text = "Robot Animation";
            // 
            // rektToolStripMenuItem
            // 
            this.rektToolStripMenuItem.Name = "rektToolStripMenuItem";
            this.rektToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.rektToolStripMenuItem.Text = "Animate the robot";
            this.rektToolStripMenuItem.Click += new System.EventHandler(this.rektToolStripMenuItem_Click);
            // 
            // showSequenceOfActionsToolStripMenuItem
            // 
            this.showSequenceOfActionsToolStripMenuItem.Name = "showSequenceOfActionsToolStripMenuItem";
            this.showSequenceOfActionsToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.showSequenceOfActionsToolStripMenuItem.Text = "Animate the robot without removing old moves";
            this.showSequenceOfActionsToolStripMenuItem.Click += new System.EventHandler(this.showSequenceOfActionsToolStripMenuItem_Click);
            // 
            // showSolutionPathOnlyToolStripMenuItem
            // 
            this.showSolutionPathOnlyToolStripMenuItem.Name = "showSolutionPathOnlyToolStripMenuItem";
            this.showSolutionPathOnlyToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.showSolutionPathOnlyToolStripMenuItem.Text = "Show Solution path only";
            this.showSolutionPathOnlyToolStripMenuItem.Click += new System.EventHandler(this.showSolutionPathOnlyToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leComeLeGoToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // leComeLeGoToolStripMenuItem
            // 
            this.leComeLeGoToolStripMenuItem.Name = "leComeLeGoToolStripMenuItem";
            this.leComeLeGoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.leComeLeGoToolStripMenuItem.Text = "le come le go";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(781, 718);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Work Space";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::RRTM.Properties.Resources._720__1_;
            this.pictureBox2.InitialImage = global::RRTM.Properties.Resources._720;
            this.pictureBox2.Location = new System.Drawing.Point(592, 449);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(117, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 699);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.Planner.ResumeLayout(false);
            this.Planner.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MaxNTextBox;
        private System.Windows.Forms.MaskedTextBox BiasTextBox;
        private System.Windows.Forms.MaskedTextBox kTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox AnimateCheckBox;
        private System.Windows.Forms.CheckBox ShowSolutionspathCheckBox;
        private System.Windows.Forms.CheckBox ShowAllNodesCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button ClearNodesButton;
        private System.Windows.Forms.RadioButton DrawCircleradioButton;
        private System.Windows.Forms.RadioButton DrawRectangleradioButton;
        private System.Windows.Forms.RadioButton RRTConnectRadioButton;
        private System.Windows.Forms.RadioButton RRTRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGoalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseSolverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rRTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rRTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setBiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMaxnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benchmarkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leComeLeGoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rektToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton NearestNeighborKDtreeNNradioButton;
        private System.Windows.Forms.RadioButton NearestNeighborLinearradioButton;
        private System.Windows.Forms.ToolStripMenuItem loadWorkspaceToolStripMenuItem;
        private System.Windows.Forms.GroupBox Planner;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton StickRobotRadioButton;
        private System.Windows.Forms.RadioButton DotRobotRadioButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.MaskedTextBox RobotHeightTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SmoothingButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem showSequenceOfActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSolutionPathOnlyToolStripMenuItem;
    }
}

