/*
 * Created by SharpDevelop.
 * User: EliteBook
 * Date: 25/01/2019
 * Time: 05:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace p01_HinojosaAcosta
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.buttonSelectImage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonFindCirclesCenters = new System.Windows.Forms.Button();
			this.labelNumberOfCirclesFound = new System.Windows.Forms.Label();
			this.treeViewCirclesConnections = new System.Windows.Forms.TreeView();
			this.buttonShowGraph = new System.Windows.Forms.Button();
			this.buttonShowAgents = new System.Windows.Forms.Button();
			this.timerAgents = new System.Windows.Forms.Timer(this.components);
			this.checkBoxLowestEdge = new System.Windows.Forms.CheckBox();
			this.checkBoxShortestPairCircleBruteForce = new System.Windows.Forms.CheckBox();
			this.labelMoreVerticesAgent = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
			this.checkBoxLeveledGraph = new System.Windows.Forms.CheckBox();
			this.checkBoxShortestPairCircleDivideConquer = new System.Windows.Forms.CheckBox();
			this.checkBoxDijkstraPath = new System.Windows.Forms.CheckBox();
			this.checkBoxPrimArm = new System.Windows.Forms.CheckBox();
			this.checkBoxKruskalArm = new System.Windows.Forms.CheckBox();
			this.buttonPrimSelectedEdgesOrder = new System.Windows.Forms.Button();
			this.buttonKruskalSelectedEdgesOrder = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.buttonCircles = new System.Windows.Forms.Button();
			this.buttonShowPrimARM = new System.Windows.Forms.Button();
			this.buttonShowKruskalARM = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.button13 = new System.Windows.Forms.Button();
			this.labelAgentSpeed = new System.Windows.Forms.Label();
			this.numericUpDownAgentSpeed = new System.Windows.Forms.NumericUpDown();
			this.button12 = new System.Windows.Forms.Button();
			this.buttonCreatePreyPredators = new System.Windows.Forms.Button();
			this.labelPreyDestine = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.comboBoxPreyDest = new System.Windows.Forms.ComboBox();
			this.numericUpDownPredatorsNum = new System.Windows.Forms.NumericUpDown();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.button9 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.button10 = new System.Windows.Forms.Button();
			this.labelPredatorsNum = new System.Windows.Forms.Label();
			this.comboBoxPreyInitVertex = new System.Windows.Forms.ComboBox();
			this.labelPreyInit = new System.Windows.Forms.Label();
			this.buttonStartPreyPredators = new System.Windows.Forms.Button();
			this.tabControlAnimation = new System.Windows.Forms.TabControl();
			this.tabPageNormal = new System.Windows.Forms.TabPage();
			this.panelNormalAgents = new System.Windows.Forms.Panel();
			this.checkBoxNormalRandomVertex = new System.Windows.Forms.CheckBox();
			this.labelPrimInitVertex = new System.Windows.Forms.Label();
			this.comboBoxPrimInitVertex = new System.Windows.Forms.ComboBox();
			this.buttonStopAnimation = new System.Windows.Forms.Button();
			this.buttonStartAllNormalAgents = new System.Windows.Forms.Button();
			this.buttonCreateAllNormalAgents = new System.Windows.Forms.Button();
			this.numericUpDownTotalNormalAgents = new System.Windows.Forms.NumericUpDown();
			this.labelTotalAgents = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.radioButtonGraphTotal = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButtonGraphKruskal = new System.Windows.Forms.RadioButton();
			this.radioButtonGraphPrim = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.radioButtonMoveDFS = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButtonMoveRandom = new System.Windows.Forms.RadioButton();
			this.numericUpDownNormalAgentSpeed = new System.Windows.Forms.NumericUpDown();
			this.tabPagePredatorPrey = new System.Windows.Forms.TabPage();
			this.panelPreyPredator = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonEditCurrent = new System.Windows.Forms.Button();
			this.checkBoxRandomPreys = new System.Windows.Forms.CheckBox();
			this.numericUpDownTotalPreys = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.buttonStopAnimationPredatosPreys = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDownPreyPredatorSpeed = new System.Windows.Forms.NumericUpDown();
			this.buttonStartPredatorPreys = new System.Windows.Forms.Button();
			this.buttonCreatePredatorPreys = new System.Windows.Forms.Button();
			this.numericUpDownTotalPredators = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPageDijkstra = new System.Windows.Forms.TabPage();
			this.panelDijkstra = new System.Windows.Forms.Panel();
			this.buttonCalculateDijkstra = new System.Windows.Forms.Button();
			this.labelInitVertexAgent = new System.Windows.Forms.Label();
			this.labelDestineVertex = new System.Windows.Forms.Label();
			this.comboBoxAgentStartVertex = new System.Windows.Forms.ComboBox();
			this.comboBoxDestineVertex = new System.Windows.Forms.ComboBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgentSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPredatorsNum)).BeginInit();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			this.tabControlAnimation.SuspendLayout();
			this.tabPageNormal.SuspendLayout();
			this.panelNormalAgents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalNormalAgents)).BeginInit();
			this.panel9.SuspendLayout();
			this.panel11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalAgentSpeed)).BeginInit();
			this.tabPagePredatorPrey.SuspendLayout();
			this.panelPreyPredator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPreys)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreyPredatorSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPredators)).BeginInit();
			this.tabPageDijkstra.SuspendLayout();
			this.panelDijkstra.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSelectImage
			// 
			this.buttonSelectImage.Location = new System.Drawing.Point(22, 20);
			this.buttonSelectImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonSelectImage.Name = "buttonSelectImage";
			this.buttonSelectImage.Size = new System.Drawing.Size(192, 48);
			this.buttonSelectImage.TabIndex = 0;
			this.buttonSelectImage.Text = "Select Image";
			this.buttonSelectImage.UseVisualStyleBackColor = true;
			this.buttonSelectImage.Click += new System.EventHandler(this.ButtonSelectImageClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(18, 18);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1038, 666);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// buttonFindCirclesCenters
			// 
			this.buttonFindCirclesCenters.Location = new System.Drawing.Point(22, 77);
			this.buttonFindCirclesCenters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonFindCirclesCenters.Name = "buttonFindCirclesCenters";
			this.buttonFindCirclesCenters.Size = new System.Drawing.Size(192, 48);
			this.buttonFindCirclesCenters.TabIndex = 2;
			this.buttonFindCirclesCenters.Text = "Find circles centers";
			this.buttonFindCirclesCenters.UseVisualStyleBackColor = true;
			this.buttonFindCirclesCenters.Click += new System.EventHandler(this.ButtonFindCirclesCentersClick);
			// 
			// labelNumberOfCirclesFound
			// 
			this.labelNumberOfCirclesFound.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumberOfCirclesFound.Location = new System.Drawing.Point(896, 689);
			this.labelNumberOfCirclesFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelNumberOfCirclesFound.Name = "labelNumberOfCirclesFound";
			this.labelNumberOfCirclesFound.Size = new System.Drawing.Size(160, 31);
			this.labelNumberOfCirclesFound.TabIndex = 4;
			this.labelNumberOfCirclesFound.Text = "..";
			// 
			// treeViewCirclesConnections
			// 
			this.treeViewCirclesConnections.Location = new System.Drawing.Point(4, 30);
			this.treeViewCirclesConnections.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.treeViewCirclesConnections.Name = "treeViewCirclesConnections";
			this.treeViewCirclesConnections.Size = new System.Drawing.Size(474, 361);
			this.treeViewCirclesConnections.TabIndex = 5;
			// 
			// buttonShowGraph
			// 
			this.buttonShowGraph.Location = new System.Drawing.Point(14, 58);
			this.buttonShowGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonShowGraph.Name = "buttonShowGraph";
			this.buttonShowGraph.Size = new System.Drawing.Size(112, 35);
			this.buttonShowGraph.TabIndex = 11;
			this.buttonShowGraph.Text = "Graph";
			this.buttonShowGraph.UseVisualStyleBackColor = true;
			this.buttonShowGraph.Click += new System.EventHandler(this.ButtonShowGraphClick);
			// 
			// buttonShowAgents
			// 
			this.buttonShowAgents.Location = new System.Drawing.Point(14, 193);
			this.buttonShowAgents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonShowAgents.Name = "buttonShowAgents";
			this.buttonShowAgents.Size = new System.Drawing.Size(112, 35);
			this.buttonShowAgents.TabIndex = 12;
			this.buttonShowAgents.Text = "Agents";
			this.buttonShowAgents.UseVisualStyleBackColor = true;
			this.buttonShowAgents.Click += new System.EventHandler(this.ButtonShowAgentsClick);
			// 
			// timerAgents
			// 
			this.timerAgents.Interval = 1;
			this.timerAgents.Tick += new System.EventHandler(this.TimerAgentsTick);
			// 
			// checkBoxLowestEdge
			// 
			this.checkBoxLowestEdge.Location = new System.Drawing.Point(5, 5);
			this.checkBoxLowestEdge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxLowestEdge.Name = "checkBoxLowestEdge";
			this.checkBoxLowestEdge.Size = new System.Drawing.Size(141, 37);
			this.checkBoxLowestEdge.TabIndex = 16;
			this.checkBoxLowestEdge.Text = "Lowest Edge";
			this.checkBoxLowestEdge.UseVisualStyleBackColor = true;
			this.checkBoxLowestEdge.CheckedChanged += new System.EventHandler(this.CheckBoxLowestEdgeCheckedChanged);
			// 
			// checkBoxShortestPairCircleBruteForce
			// 
			this.checkBoxShortestPairCircleBruteForce.Location = new System.Drawing.Point(5, 36);
			this.checkBoxShortestPairCircleBruteForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxShortestPairCircleBruteForce.Name = "checkBoxShortestPairCircleBruteForce";
			this.checkBoxShortestPairCircleBruteForce.Size = new System.Drawing.Size(141, 37);
			this.checkBoxShortestPairCircleBruteForce.TabIndex = 17;
			this.checkBoxShortestPairCircleBruteForce.Text = "BruteForce";
			this.checkBoxShortestPairCircleBruteForce.UseVisualStyleBackColor = true;
			this.checkBoxShortestPairCircleBruteForce.CheckedChanged += new System.EventHandler(this.CheckBoxShortestPairCirckeCheckedChanged);
			// 
			// labelMoreVerticesAgent
			// 
			this.labelMoreVerticesAgent.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMoreVerticesAgent.Location = new System.Drawing.Point(795, 741);
			this.labelMoreVerticesAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelMoreVerticesAgent.Name = "labelMoreVerticesAgent";
			this.labelMoreVerticesAgent.Size = new System.Drawing.Size(251, 28);
			this.labelMoreVerticesAgent.TabIndex = 18;
			this.labelMoreVerticesAgent.Text = "..";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSelectImage);
			this.panel1.Controls.Add(this.buttonFindCirclesCenters);
			this.panel1.Location = new System.Drawing.Point(18, 701);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(237, 140);
			this.panel1.TabIndex = 19;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel2.Controls.Add(this.checkBoxSelectAll);
			this.panel2.Controls.Add(this.checkBoxLeveledGraph);
			this.panel2.Controls.Add(this.checkBoxShortestPairCircleDivideConquer);
			this.panel2.Controls.Add(this.checkBoxDijkstraPath);
			this.panel2.Controls.Add(this.checkBoxPrimArm);
			this.panel2.Controls.Add(this.checkBoxKruskalArm);
			this.panel2.Controls.Add(this.checkBoxLowestEdge);
			this.panel2.Controls.Add(this.checkBoxShortestPairCircleBruteForce);
			this.panel2.Location = new System.Drawing.Point(1064, 47);
			this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(150, 378);
			this.panel2.TabIndex = 20;
			// 
			// checkBoxSelectAll
			// 
			this.checkBoxSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxSelectAll.Location = new System.Drawing.Point(9, 336);
			this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxSelectAll.Name = "checkBoxSelectAll";
			this.checkBoxSelectAll.Size = new System.Drawing.Size(141, 37);
			this.checkBoxSelectAll.TabIndex = 24;
			this.checkBoxSelectAll.Text = "Select All";
			this.checkBoxSelectAll.UseVisualStyleBackColor = true;
			this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
			// 
			// checkBoxLeveledGraph
			// 
			this.checkBoxLeveledGraph.Location = new System.Drawing.Point(5, 200);
			this.checkBoxLeveledGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxLeveledGraph.Name = "checkBoxLeveledGraph";
			this.checkBoxLeveledGraph.Size = new System.Drawing.Size(141, 37);
			this.checkBoxLeveledGraph.TabIndex = 23;
			this.checkBoxLeveledGraph.Text = "LeveledGraph";
			this.checkBoxLeveledGraph.UseVisualStyleBackColor = true;
			this.checkBoxLeveledGraph.CheckedChanged += new System.EventHandler(this.CheckBoxLeveledGraphCheckedChanged);
			// 
			// checkBoxShortestPairCircleDivideConquer
			// 
			this.checkBoxShortestPairCircleDivideConquer.Location = new System.Drawing.Point(5, 71);
			this.checkBoxShortestPairCircleDivideConquer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxShortestPairCircleDivideConquer.Name = "checkBoxShortestPairCircleDivideConquer";
			this.checkBoxShortestPairCircleDivideConquer.Size = new System.Drawing.Size(141, 37);
			this.checkBoxShortestPairCircleDivideConquer.TabIndex = 22;
			this.checkBoxShortestPairCircleDivideConquer.Text = "DivideConquer";
			this.checkBoxShortestPairCircleDivideConquer.UseVisualStyleBackColor = true;
			this.checkBoxShortestPairCircleDivideConquer.CheckedChanged += new System.EventHandler(this.CheckBoxShortestPairCircleDivideConquerCheckedChanged);
			// 
			// checkBoxDijkstraPath
			// 
			this.checkBoxDijkstraPath.Location = new System.Drawing.Point(5, 171);
			this.checkBoxDijkstraPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxDijkstraPath.Name = "checkBoxDijkstraPath";
			this.checkBoxDijkstraPath.Size = new System.Drawing.Size(141, 37);
			this.checkBoxDijkstraPath.TabIndex = 21;
			this.checkBoxDijkstraPath.Text = "Dijkstra";
			this.checkBoxDijkstraPath.UseVisualStyleBackColor = true;
			this.checkBoxDijkstraPath.CheckedChanged += new System.EventHandler(this.CheckBoxDijkstraPathCheckedChanged);
			// 
			// checkBoxPrimArm
			// 
			this.checkBoxPrimArm.Location = new System.Drawing.Point(5, 138);
			this.checkBoxPrimArm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxPrimArm.Name = "checkBoxPrimArm";
			this.checkBoxPrimArm.Size = new System.Drawing.Size(141, 37);
			this.checkBoxPrimArm.TabIndex = 19;
			this.checkBoxPrimArm.Text = "Prim ARM";
			this.checkBoxPrimArm.UseVisualStyleBackColor = true;
			this.checkBoxPrimArm.CheckedChanged += new System.EventHandler(this.CheckBoxPrimArmCheckedChanged);
			// 
			// checkBoxKruskalArm
			// 
			this.checkBoxKruskalArm.Location = new System.Drawing.Point(5, 104);
			this.checkBoxKruskalArm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxKruskalArm.Name = "checkBoxKruskalArm";
			this.checkBoxKruskalArm.Size = new System.Drawing.Size(141, 37);
			this.checkBoxKruskalArm.TabIndex = 18;
			this.checkBoxKruskalArm.Text = "Kruskal ARM";
			this.checkBoxKruskalArm.UseVisualStyleBackColor = true;
			this.checkBoxKruskalArm.CheckedChanged += new System.EventHandler(this.CheckBoxKruskalArmCheckedChanged);
			// 
			// buttonPrimSelectedEdgesOrder
			// 
			this.buttonPrimSelectedEdgesOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
			this.buttonPrimSelectedEdgesOrder.Location = new System.Drawing.Point(14, 305);
			this.buttonPrimSelectedEdgesOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonPrimSelectedEdgesOrder.Name = "buttonPrimSelectedEdgesOrder";
			this.buttonPrimSelectedEdgesOrder.Size = new System.Drawing.Size(112, 35);
			this.buttonPrimSelectedEdgesOrder.TabIndex = 20;
			this.buttonPrimSelectedEdgesOrder.Text = "Prim Edges";
			this.buttonPrimSelectedEdgesOrder.UseVisualStyleBackColor = true;
			this.buttonPrimSelectedEdgesOrder.Click += new System.EventHandler(this.ButtonPrimSelectedEdgesOrderClick);
			// 
			// buttonKruskalSelectedEdgesOrder
			// 
			this.buttonKruskalSelectedEdgesOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
			this.buttonKruskalSelectedEdgesOrder.Location = new System.Drawing.Point(14, 260);
			this.buttonKruskalSelectedEdgesOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonKruskalSelectedEdgesOrder.Name = "buttonKruskalSelectedEdgesOrder";
			this.buttonKruskalSelectedEdgesOrder.Size = new System.Drawing.Size(112, 35);
			this.buttonKruskalSelectedEdgesOrder.TabIndex = 15;
			this.buttonKruskalSelectedEdgesOrder.Text = "Kruskal Edges";
			this.buttonKruskalSelectedEdgesOrder.UseVisualStyleBackColor = true;
			this.buttonKruskalSelectedEdgesOrder.Click += new System.EventHandler(this.ButtonKruskalSelectedEdgesOrderClick);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel3.Controls.Add(this.buttonCircles);
			this.panel3.Controls.Add(this.buttonShowPrimARM);
			this.panel3.Controls.Add(this.buttonShowKruskalARM);
			this.panel3.Controls.Add(this.buttonShowGraph);
			this.panel3.Controls.Add(this.buttonPrimSelectedEdgesOrder);
			this.panel3.Controls.Add(this.buttonShowAgents);
			this.panel3.Controls.Add(this.buttonKruskalSelectedEdgesOrder);
			this.panel3.Location = new System.Drawing.Point(1069, 504);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(150, 362);
			this.panel3.TabIndex = 21;
			// 
			// buttonCircles
			// 
			this.buttonCircles.Location = new System.Drawing.Point(14, 14);
			this.buttonCircles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonCircles.Name = "buttonCircles";
			this.buttonCircles.Size = new System.Drawing.Size(112, 35);
			this.buttonCircles.TabIndex = 21;
			this.buttonCircles.Text = "Circles";
			this.buttonCircles.UseVisualStyleBackColor = true;
			this.buttonCircles.Click += new System.EventHandler(this.ButtonCirclesClick);
			// 
			// buttonShowPrimARM
			// 
			this.buttonShowPrimARM.Location = new System.Drawing.Point(14, 148);
			this.buttonShowPrimARM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonShowPrimARM.Name = "buttonShowPrimARM";
			this.buttonShowPrimARM.Size = new System.Drawing.Size(112, 35);
			this.buttonShowPrimARM.TabIndex = 14;
			this.buttonShowPrimARM.Text = "Prim ARM";
			this.buttonShowPrimARM.UseVisualStyleBackColor = true;
			this.buttonShowPrimARM.Click += new System.EventHandler(this.ButtonShowPrimARMClick);
			// 
			// buttonShowKruskalARM
			// 
			this.buttonShowKruskalARM.Location = new System.Drawing.Point(14, 103);
			this.buttonShowKruskalARM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonShowKruskalARM.Name = "buttonShowKruskalARM";
			this.buttonShowKruskalARM.Size = new System.Drawing.Size(112, 35);
			this.buttonShowKruskalARM.TabIndex = 13;
			this.buttonShowKruskalARM.Text = "Kruskal ARM";
			this.buttonShowKruskalARM.UseVisualStyleBackColor = true;
			this.buttonShowKruskalARM.Click += new System.EventHandler(this.ButtonShowKruskalARMClick);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.treeViewCirclesConnections);
			this.panel5.Location = new System.Drawing.Point(1221, 474);
			this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(482, 396);
			this.panel5.TabIndex = 23;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.button13);
			this.panel7.Controls.Add(this.labelAgentSpeed);
			this.panel7.Controls.Add(this.numericUpDownAgentSpeed);
			this.panel7.Controls.Add(this.button12);
			this.panel7.Controls.Add(this.buttonCreatePreyPredators);
			this.panel7.Controls.Add(this.labelPreyDestine);
			this.panel7.Controls.Add(this.button11);
			this.panel7.Controls.Add(this.comboBoxPreyDest);
			this.panel7.Controls.Add(this.numericUpDownPredatorsNum);
			this.panel7.Controls.Add(this.panel6);
			this.panel7.Controls.Add(this.labelPredatorsNum);
			this.panel7.Controls.Add(this.comboBoxPreyInitVertex);
			this.panel7.Controls.Add(this.labelPreyInit);
			this.panel7.Controls.Add(this.buttonStartPreyPredators);
			this.panel7.Location = new System.Drawing.Point(17, 8);
			this.panel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(450, 280);
			this.panel7.TabIndex = 23;
			// 
			// button13
			// 
			this.button13.BackColor = System.Drawing.Color.Gray;
			this.button13.Location = new System.Drawing.Point(332, 298);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(113, 45);
			this.button13.TabIndex = 42;
			this.button13.Text = "Stop";
			this.button13.UseVisualStyleBackColor = false;
			// 
			// labelAgentSpeed
			// 
			this.labelAgentSpeed.Location = new System.Drawing.Point(7, 116);
			this.labelAgentSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelAgentSpeed.Name = "labelAgentSpeed";
			this.labelAgentSpeed.Size = new System.Drawing.Size(87, 35);
			this.labelAgentSpeed.TabIndex = 28;
			this.labelAgentSpeed.Text = "Speed";
			// 
			// numericUpDownAgentSpeed
			// 
			this.numericUpDownAgentSpeed.Location = new System.Drawing.Point(98, 116);
			this.numericUpDownAgentSpeed.Maximum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.numericUpDownAgentSpeed.Minimum = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.numericUpDownAgentSpeed.Name = "numericUpDownAgentSpeed";
			this.numericUpDownAgentSpeed.Size = new System.Drawing.Size(196, 26);
			this.numericUpDownAgentSpeed.TabIndex = 27;
			this.numericUpDownAgentSpeed.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			// 
			// button12
			// 
			this.button12.BackColor = System.Drawing.Color.Gray;
			this.button12.Location = new System.Drawing.Point(98, 298);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(234, 45);
			this.button12.TabIndex = 41;
			this.button12.Text = "Start";
			this.button12.UseVisualStyleBackColor = false;
			// 
			// buttonCreatePreyPredators
			// 
			this.buttonCreatePreyPredators.Location = new System.Drawing.Point(102, 152);
			this.buttonCreatePreyPredators.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonCreatePreyPredators.Name = "buttonCreatePreyPredators";
			this.buttonCreatePreyPredators.Size = new System.Drawing.Size(94, 35);
			this.buttonCreatePreyPredators.TabIndex = 26;
			this.buttonCreatePreyPredators.Text = "Create";
			this.buttonCreatePreyPredators.UseVisualStyleBackColor = true;
			this.buttonCreatePreyPredators.Click += new System.EventHandler(this.ButtonCreatePreyPredatorsClick);
			// 
			// labelPreyDestine
			// 
			this.labelPreyDestine.Location = new System.Drawing.Point(7, 50);
			this.labelPreyDestine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPreyDestine.Name = "labelPreyDestine";
			this.labelPreyDestine.Size = new System.Drawing.Size(85, 35);
			this.labelPreyDestine.TabIndex = 25;
			this.labelPreyDestine.Text = "Prey Dest";
			// 
			// button11
			// 
			this.button11.BackColor = System.Drawing.Color.Gray;
			this.button11.Location = new System.Drawing.Point(0, 298);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(108, 45);
			this.button11.TabIndex = 40;
			this.button11.Text = "Create";
			this.button11.UseVisualStyleBackColor = false;
			// 
			// comboBoxPreyDest
			// 
			this.comboBoxPreyDest.FormattingEnabled = true;
			this.comboBoxPreyDest.Location = new System.Drawing.Point(98, 47);
			this.comboBoxPreyDest.Name = "comboBoxPreyDest";
			this.comboBoxPreyDest.Size = new System.Drawing.Size(196, 28);
			this.comboBoxPreyDest.TabIndex = 24;
			// 
			// numericUpDownPredatorsNum
			// 
			this.numericUpDownPredatorsNum.Location = new System.Drawing.Point(98, 84);
			this.numericUpDownPredatorsNum.Name = "numericUpDownPredatorsNum";
			this.numericUpDownPredatorsNum.Size = new System.Drawing.Size(196, 26);
			this.numericUpDownPredatorsNum.TabIndex = 23;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label9);
			this.panel6.Controls.Add(this.numericUpDown3);
			this.panel6.Controls.Add(this.button9);
			this.panel6.Controls.Add(this.label10);
			this.panel6.Controls.Add(this.comboBox3);
			this.panel6.Controls.Add(this.numericUpDown4);
			this.panel6.Controls.Add(this.label11);
			this.panel6.Controls.Add(this.comboBox4);
			this.panel6.Controls.Add(this.label12);
			this.panel6.Controls.Add(this.button10);
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(450, 280);
			this.panel6.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 116);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(87, 35);
			this.label9.TabIndex = 28;
			this.label9.Text = "Speed";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(98, 116);
			this.numericUpDown3.Maximum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.numericUpDown3.Minimum = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(196, 26);
			this.numericUpDown3.TabIndex = 27;
			this.numericUpDown3.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(102, 152);
			this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(94, 35);
			this.button9.TabIndex = 26;
			this.button9.Text = "Create";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.ButtonCreatePreyPredatorsClick);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(7, 50);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 35);
			this.label10.TabIndex = 25;
			this.label10.Text = "Prey Dest";
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(98, 47);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(196, 28);
			this.comboBox3.TabIndex = 24;
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(98, 84);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(196, 26);
			this.numericUpDown4.TabIndex = 23;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 86);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(87, 35);
			this.label11.TabIndex = 22;
			this.label11.Text = "Predators";
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(98, 13);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(196, 28);
			this.comboBox4.TabIndex = 20;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 16);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(71, 35);
			this.label12.TabIndex = 9;
			this.label12.Text = "Prey Init";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(204, 153);
			this.button10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(94, 35);
			this.button10.TabIndex = 10;
			this.button10.Text = "Start";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// labelPredatorsNum
			// 
			this.labelPredatorsNum.Location = new System.Drawing.Point(6, 86);
			this.labelPredatorsNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPredatorsNum.Name = "labelPredatorsNum";
			this.labelPredatorsNum.Size = new System.Drawing.Size(87, 35);
			this.labelPredatorsNum.TabIndex = 22;
			this.labelPredatorsNum.Text = "Predators";
			// 
			// comboBoxPreyInitVertex
			// 
			this.comboBoxPreyInitVertex.FormattingEnabled = true;
			this.comboBoxPreyInitVertex.Location = new System.Drawing.Point(98, 13);
			this.comboBoxPreyInitVertex.Name = "comboBoxPreyInitVertex";
			this.comboBoxPreyInitVertex.Size = new System.Drawing.Size(196, 28);
			this.comboBoxPreyInitVertex.TabIndex = 20;
			// 
			// labelPreyInit
			// 
			this.labelPreyInit.Location = new System.Drawing.Point(6, 16);
			this.labelPreyInit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPreyInit.Name = "labelPreyInit";
			this.labelPreyInit.Size = new System.Drawing.Size(71, 35);
			this.labelPreyInit.TabIndex = 9;
			this.labelPreyInit.Text = "Prey Init";
			// 
			// buttonStartPreyPredators
			// 
			this.buttonStartPreyPredators.Location = new System.Drawing.Point(204, 153);
			this.buttonStartPreyPredators.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonStartPreyPredators.Name = "buttonStartPreyPredators";
			this.buttonStartPreyPredators.Size = new System.Drawing.Size(94, 35);
			this.buttonStartPreyPredators.TabIndex = 10;
			this.buttonStartPreyPredators.Text = "Start";
			this.buttonStartPreyPredators.UseVisualStyleBackColor = true;
			// 
			// tabControlAnimation
			// 
			this.tabControlAnimation.Controls.Add(this.tabPageNormal);
			this.tabControlAnimation.Controls.Add(this.tabPagePredatorPrey);
			this.tabControlAnimation.Controls.Add(this.tabPageDijkstra);
			this.tabControlAnimation.Location = new System.Drawing.Point(1217, 18);
			this.tabControlAnimation.Name = "tabControlAnimation";
			this.tabControlAnimation.SelectedIndex = 0;
			this.tabControlAnimation.Size = new System.Drawing.Size(482, 411);
			this.tabControlAnimation.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControlAnimation.TabIndex = 24;
			// 
			// tabPageNormal
			// 
			this.tabPageNormal.Controls.Add(this.panelNormalAgents);
			this.tabPageNormal.Location = new System.Drawing.Point(4, 29);
			this.tabPageNormal.Name = "tabPageNormal";
			this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNormal.Size = new System.Drawing.Size(474, 378);
			this.tabPageNormal.TabIndex = 0;
			this.tabPageNormal.Text = "Normal";
			this.tabPageNormal.UseVisualStyleBackColor = true;
			// 
			// panelNormalAgents
			// 
			this.panelNormalAgents.Controls.Add(this.checkBoxNormalRandomVertex);
			this.panelNormalAgents.Controls.Add(this.labelPrimInitVertex);
			this.panelNormalAgents.Controls.Add(this.comboBoxPrimInitVertex);
			this.panelNormalAgents.Controls.Add(this.buttonStopAnimation);
			this.panelNormalAgents.Controls.Add(this.buttonStartAllNormalAgents);
			this.panelNormalAgents.Controls.Add(this.buttonCreateAllNormalAgents);
			this.panelNormalAgents.Controls.Add(this.numericUpDownTotalNormalAgents);
			this.panelNormalAgents.Controls.Add(this.labelTotalAgents);
			this.panelNormalAgents.Controls.Add(this.panel9);
			this.panelNormalAgents.Controls.Add(this.label2);
			this.panelNormalAgents.Controls.Add(this.panel11);
			this.panelNormalAgents.Controls.Add(this.numericUpDownNormalAgentSpeed);
			this.panelNormalAgents.Location = new System.Drawing.Point(6, 6);
			this.panelNormalAgents.Name = "panelNormalAgents";
			this.panelNormalAgents.Size = new System.Drawing.Size(462, 366);
			this.panelNormalAgents.TabIndex = 25;
			// 
			// checkBoxNormalRandomVertex
			// 
			this.checkBoxNormalRandomVertex.Location = new System.Drawing.Point(354, 160);
			this.checkBoxNormalRandomVertex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxNormalRandomVertex.Name = "checkBoxNormalRandomVertex";
			this.checkBoxNormalRandomVertex.Size = new System.Drawing.Size(104, 37);
			this.checkBoxNormalRandomVertex.TabIndex = 42;
			this.checkBoxNormalRandomVertex.Text = "Random";
			this.checkBoxNormalRandomVertex.UseVisualStyleBackColor = true;
			// 
			// labelPrimInitVertex
			// 
			this.labelPrimInitVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPrimInitVertex.Location = new System.Drawing.Point(16, 238);
			this.labelPrimInitVertex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPrimInitVertex.Name = "labelPrimInitVertex";
			this.labelPrimInitVertex.Size = new System.Drawing.Size(107, 25);
			this.labelPrimInitVertex.TabIndex = 41;
			this.labelPrimInitVertex.Text = "Prim Init";
			// 
			// comboBoxPrimInitVertex
			// 
			this.comboBoxPrimInitVertex.FormattingEnabled = true;
			this.comboBoxPrimInitVertex.Location = new System.Drawing.Point(142, 235);
			this.comboBoxPrimInitVertex.Name = "comboBoxPrimInitVertex";
			this.comboBoxPrimInitVertex.Size = new System.Drawing.Size(203, 28);
			this.comboBoxPrimInitVertex.TabIndex = 40;
			// 
			// buttonStopAnimation
			// 
			this.buttonStopAnimation.BackColor = System.Drawing.Color.Gray;
			this.buttonStopAnimation.Location = new System.Drawing.Point(345, 314);
			this.buttonStopAnimation.Name = "buttonStopAnimation";
			this.buttonStopAnimation.Size = new System.Drawing.Size(113, 45);
			this.buttonStopAnimation.TabIndex = 39;
			this.buttonStopAnimation.Text = "Stop";
			this.buttonStopAnimation.UseVisualStyleBackColor = false;
			this.buttonStopAnimation.Click += new System.EventHandler(this.ButtonStopAnimationClick);
			// 
			// buttonStartAllNormalAgents
			// 
			this.buttonStartAllNormalAgents.BackColor = System.Drawing.Color.Gray;
			this.buttonStartAllNormalAgents.Location = new System.Drawing.Point(111, 314);
			this.buttonStartAllNormalAgents.Name = "buttonStartAllNormalAgents";
			this.buttonStartAllNormalAgents.Size = new System.Drawing.Size(234, 45);
			this.buttonStartAllNormalAgents.TabIndex = 38;
			this.buttonStartAllNormalAgents.Text = "Start";
			this.buttonStartAllNormalAgents.UseVisualStyleBackColor = false;
			this.buttonStartAllNormalAgents.Click += new System.EventHandler(this.ButtonStartAllNormalAgentsClick);
			// 
			// buttonCreateAllNormalAgents
			// 
			this.buttonCreateAllNormalAgents.BackColor = System.Drawing.Color.Gray;
			this.buttonCreateAllNormalAgents.Location = new System.Drawing.Point(2, 314);
			this.buttonCreateAllNormalAgents.Name = "buttonCreateAllNormalAgents";
			this.buttonCreateAllNormalAgents.Size = new System.Drawing.Size(108, 45);
			this.buttonCreateAllNormalAgents.TabIndex = 37;
			this.buttonCreateAllNormalAgents.Text = "Create";
			this.buttonCreateAllNormalAgents.UseVisualStyleBackColor = false;
			this.buttonCreateAllNormalAgents.Click += new System.EventHandler(this.ButtonCreateAllNormalAgentsClick);
			// 
			// numericUpDownTotalNormalAgents
			// 
			this.numericUpDownTotalNormalAgents.Location = new System.Drawing.Point(143, 165);
			this.numericUpDownTotalNormalAgents.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDownTotalNormalAgents.Name = "numericUpDownTotalNormalAgents";
			this.numericUpDownTotalNormalAgents.Size = new System.Drawing.Size(202, 26);
			this.numericUpDownTotalNormalAgents.TabIndex = 36;
			this.numericUpDownTotalNormalAgents.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// labelTotalAgents
			// 
			this.labelTotalAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTotalAgents.Location = new System.Drawing.Point(16, 167);
			this.labelTotalAgents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTotalAgents.Name = "labelTotalAgents";
			this.labelTotalAgents.Size = new System.Drawing.Size(120, 35);
			this.labelTotalAgents.TabIndex = 35;
			this.labelTotalAgents.Text = "Total Agents";
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.LightGray;
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Controls.Add(this.radioButtonGraphTotal);
			this.panel9.Controls.Add(this.label1);
			this.panel9.Controls.Add(this.radioButtonGraphKruskal);
			this.panel9.Controls.Add(this.radioButtonGraphPrim);
			this.panel9.Location = new System.Drawing.Point(34, 15);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(174, 120);
			this.panel9.TabIndex = 30;
			// 
			// radioButtonGraphTotal
			// 
			this.radioButtonGraphTotal.Location = new System.Drawing.Point(14, 26);
			this.radioButtonGraphTotal.Name = "radioButtonGraphTotal";
			this.radioButtonGraphTotal.Size = new System.Drawing.Size(80, 26);
			this.radioButtonGraphTotal.TabIndex = 22;
			this.radioButtonGraphTotal.TabStop = true;
			this.radioButtonGraphTotal.Text = "Total";
			this.radioButtonGraphTotal.UseVisualStyleBackColor = true;
			this.radioButtonGraphTotal.CheckedChanged += new System.EventHandler(this.RadioButtonGraphTotalCheckedChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 23);
			this.label1.TabIndex = 21;
			this.label1.Text = "Path";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// radioButtonGraphKruskal
			// 
			this.radioButtonGraphKruskal.Location = new System.Drawing.Point(14, 85);
			this.radioButtonGraphKruskal.Name = "radioButtonGraphKruskal";
			this.radioButtonGraphKruskal.Size = new System.Drawing.Size(92, 28);
			this.radioButtonGraphKruskal.TabIndex = 17;
			this.radioButtonGraphKruskal.TabStop = true;
			this.radioButtonGraphKruskal.Text = "Kruskal";
			this.radioButtonGraphKruskal.UseVisualStyleBackColor = true;
			this.radioButtonGraphKruskal.CheckedChanged += new System.EventHandler(this.RadioButtonGraphKruskalCheckedChanged);
			// 
			// radioButtonGraphPrim
			// 
			this.radioButtonGraphPrim.Location = new System.Drawing.Point(14, 55);
			this.radioButtonGraphPrim.Name = "radioButtonGraphPrim";
			this.radioButtonGraphPrim.Size = new System.Drawing.Size(80, 26);
			this.radioButtonGraphPrim.TabIndex = 16;
			this.radioButtonGraphPrim.TabStop = true;
			this.radioButtonGraphPrim.Text = "Prim";
			this.radioButtonGraphPrim.UseVisualStyleBackColor = true;
			this.radioButtonGraphPrim.CheckedChanged += new System.EventHandler(this.RadioButtonGraphPrimCheckedChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 202);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 28);
			this.label2.TabIndex = 33;
			this.label2.Text = "Speed";
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.Color.LightGray;
			this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel11.Controls.Add(this.radioButtonMoveDFS);
			this.panel11.Controls.Add(this.label3);
			this.panel11.Controls.Add(this.radioButtonMoveRandom);
			this.panel11.Location = new System.Drawing.Point(259, 15);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(173, 120);
			this.panel11.TabIndex = 32;
			// 
			// radioButtonMoveDFS
			// 
			this.radioButtonMoveDFS.Location = new System.Drawing.Point(8, 57);
			this.radioButtonMoveDFS.Name = "radioButtonMoveDFS";
			this.radioButtonMoveDFS.Size = new System.Drawing.Size(104, 24);
			this.radioButtonMoveDFS.TabIndex = 22;
			this.radioButtonMoveDFS.TabStop = true;
			this.radioButtonMoveDFS.Text = "DFS";
			this.radioButtonMoveDFS.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 23);
			this.label3.TabIndex = 21;
			this.label3.Text = "Move";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// radioButtonMoveRandom
			// 
			this.radioButtonMoveRandom.Location = new System.Drawing.Point(8, 27);
			this.radioButtonMoveRandom.Name = "radioButtonMoveRandom";
			this.radioButtonMoveRandom.Size = new System.Drawing.Size(104, 24);
			this.radioButtonMoveRandom.TabIndex = 18;
			this.radioButtonMoveRandom.TabStop = true;
			this.radioButtonMoveRandom.Text = "Random";
			this.radioButtonMoveRandom.UseVisualStyleBackColor = true;
			// 
			// numericUpDownNormalAgentSpeed
			// 
			this.numericUpDownNormalAgentSpeed.Location = new System.Drawing.Point(143, 202);
			this.numericUpDownNormalAgentSpeed.Maximum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.numericUpDownNormalAgentSpeed.Minimum = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.numericUpDownNormalAgentSpeed.Name = "numericUpDownNormalAgentSpeed";
			this.numericUpDownNormalAgentSpeed.Size = new System.Drawing.Size(202, 26);
			this.numericUpDownNormalAgentSpeed.TabIndex = 34;
			this.numericUpDownNormalAgentSpeed.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			// 
			// tabPagePredatorPrey
			// 
			this.tabPagePredatorPrey.Controls.Add(this.panelPreyPredator);
			this.tabPagePredatorPrey.Controls.Add(this.panel7);
			this.tabPagePredatorPrey.Location = new System.Drawing.Point(4, 29);
			this.tabPagePredatorPrey.Name = "tabPagePredatorPrey";
			this.tabPagePredatorPrey.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePredatorPrey.Size = new System.Drawing.Size(474, 378);
			this.tabPagePredatorPrey.TabIndex = 1;
			this.tabPagePredatorPrey.Text = "Predator-Prey";
			this.tabPagePredatorPrey.UseVisualStyleBackColor = true;
			// 
			// panelPreyPredator
			// 
			this.panelPreyPredator.Controls.Add(this.textBox1);
			this.panelPreyPredator.Controls.Add(this.buttonEditCurrent);
			this.panelPreyPredator.Controls.Add(this.checkBoxRandomPreys);
			this.panelPreyPredator.Controls.Add(this.numericUpDownTotalPreys);
			this.panelPreyPredator.Controls.Add(this.label13);
			this.panelPreyPredator.Controls.Add(this.buttonStopAnimationPredatosPreys);
			this.panelPreyPredator.Controls.Add(this.label5);
			this.panelPreyPredator.Controls.Add(this.numericUpDownPreyPredatorSpeed);
			this.panelPreyPredator.Controls.Add(this.buttonStartPredatorPreys);
			this.panelPreyPredator.Controls.Add(this.buttonCreatePredatorPreys);
			this.panelPreyPredator.Controls.Add(this.numericUpDownTotalPredators);
			this.panelPreyPredator.Controls.Add(this.label7);
			this.panelPreyPredator.Location = new System.Drawing.Point(7, 8);
			this.panelPreyPredator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panelPreyPredator.Name = "panelPreyPredator";
			this.panelPreyPredator.Size = new System.Drawing.Size(460, 362);
			this.panelPreyPredator.TabIndex = 23;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(81, 28);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(302, 21);
			this.textBox1.TabIndex = 46;
			this.textBox1.Text = "       Preys: Dijkstra                              Predators: DFS";
			// 
			// buttonEditCurrent
			// 
			this.buttonEditCurrent.Location = new System.Drawing.Point(73, 238);
			this.buttonEditCurrent.Name = "buttonEditCurrent";
			this.buttonEditCurrent.Size = new System.Drawing.Size(310, 42);
			this.buttonEditCurrent.TabIndex = 45;
			this.buttonEditCurrent.Text = "Edit current preys";
			this.buttonEditCurrent.UseVisualStyleBackColor = true;
			this.buttonEditCurrent.Click += new System.EventHandler(this.ButtonEditCurrentClick);
			// 
			// checkBoxRandomPreys
			// 
			this.checkBoxRandomPreys.Location = new System.Drawing.Point(340, 63);
			this.checkBoxRandomPreys.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxRandomPreys.Name = "checkBoxRandomPreys";
			this.checkBoxRandomPreys.Size = new System.Drawing.Size(110, 37);
			this.checkBoxRandomPreys.TabIndex = 24;
			this.checkBoxRandomPreys.Text = "Random";
			this.checkBoxRandomPreys.UseVisualStyleBackColor = true;
			// 
			// numericUpDownTotalPreys
			// 
			this.numericUpDownTotalPreys.Location = new System.Drawing.Point(140, 68);
			this.numericUpDownTotalPreys.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDownTotalPreys.Name = "numericUpDownTotalPreys";
			this.numericUpDownTotalPreys.Size = new System.Drawing.Size(193, 26);
			this.numericUpDownTotalPreys.TabIndex = 44;
			this.numericUpDownTotalPreys.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(13, 70);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(120, 35);
			this.label13.TabIndex = 43;
			this.label13.Text = "Total Preys";
			// 
			// buttonStopAnimationPredatosPreys
			// 
			this.buttonStopAnimationPredatosPreys.BackColor = System.Drawing.Color.Gray;
			this.buttonStopAnimationPredatosPreys.Location = new System.Drawing.Point(346, 314);
			this.buttonStopAnimationPredatosPreys.Name = "buttonStopAnimationPredatosPreys";
			this.buttonStopAnimationPredatosPreys.Size = new System.Drawing.Size(113, 45);
			this.buttonStopAnimationPredatosPreys.TabIndex = 42;
			this.buttonStopAnimationPredatosPreys.Text = "Stop";
			this.buttonStopAnimationPredatosPreys.UseVisualStyleBackColor = false;
			this.buttonStopAnimationPredatosPreys.Click += new System.EventHandler(this.ButtonStopAnimationPredatosPreysClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 146);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 35);
			this.label5.TabIndex = 28;
			this.label5.Text = "Speed";
			// 
			// numericUpDownPreyPredatorSpeed
			// 
			this.numericUpDownPreyPredatorSpeed.Location = new System.Drawing.Point(140, 141);
			this.numericUpDownPreyPredatorSpeed.Maximum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.numericUpDownPreyPredatorSpeed.Minimum = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.numericUpDownPreyPredatorSpeed.Name = "numericUpDownPreyPredatorSpeed";
			this.numericUpDownPreyPredatorSpeed.Size = new System.Drawing.Size(193, 26);
			this.numericUpDownPreyPredatorSpeed.TabIndex = 27;
			this.numericUpDownPreyPredatorSpeed.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			// 
			// buttonStartPredatorPreys
			// 
			this.buttonStartPredatorPreys.BackColor = System.Drawing.Color.Gray;
			this.buttonStartPredatorPreys.Location = new System.Drawing.Point(112, 314);
			this.buttonStartPredatorPreys.Name = "buttonStartPredatorPreys";
			this.buttonStartPredatorPreys.Size = new System.Drawing.Size(234, 45);
			this.buttonStartPredatorPreys.TabIndex = 41;
			this.buttonStartPredatorPreys.Text = "Start";
			this.buttonStartPredatorPreys.UseVisualStyleBackColor = false;
			this.buttonStartPredatorPreys.Click += new System.EventHandler(this.ButtonStartPredatorPreysClick);
			// 
			// buttonCreatePredatorPreys
			// 
			this.buttonCreatePredatorPreys.BackColor = System.Drawing.Color.Gray;
			this.buttonCreatePredatorPreys.Location = new System.Drawing.Point(3, 314);
			this.buttonCreatePredatorPreys.Name = "buttonCreatePredatorPreys";
			this.buttonCreatePredatorPreys.Size = new System.Drawing.Size(108, 45);
			this.buttonCreatePredatorPreys.TabIndex = 40;
			this.buttonCreatePredatorPreys.Text = "Create New";
			this.buttonCreatePredatorPreys.UseVisualStyleBackColor = false;
			this.buttonCreatePredatorPreys.Click += new System.EventHandler(this.ButtonCreatePredatorPreysClick);
			// 
			// numericUpDownTotalPredators
			// 
			this.numericUpDownTotalPredators.Location = new System.Drawing.Point(140, 102);
			this.numericUpDownTotalPredators.Name = "numericUpDownTotalPredators";
			this.numericUpDownTotalPredators.Size = new System.Drawing.Size(193, 26);
			this.numericUpDownTotalPredators.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(13, 112);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 35);
			this.label7.TabIndex = 22;
			this.label7.Text = "Predators";
			// 
			// tabPageDijkstra
			// 
			this.tabPageDijkstra.Controls.Add(this.panelDijkstra);
			this.tabPageDijkstra.Location = new System.Drawing.Point(4, 29);
			this.tabPageDijkstra.Name = "tabPageDijkstra";
			this.tabPageDijkstra.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDijkstra.Size = new System.Drawing.Size(474, 378);
			this.tabPageDijkstra.TabIndex = 2;
			this.tabPageDijkstra.Text = "Dijkstra";
			this.tabPageDijkstra.UseVisualStyleBackColor = true;
			// 
			// panelDijkstra
			// 
			this.panelDijkstra.Controls.Add(this.buttonCalculateDijkstra);
			this.panelDijkstra.Controls.Add(this.labelInitVertexAgent);
			this.panelDijkstra.Controls.Add(this.labelDestineVertex);
			this.panelDijkstra.Controls.Add(this.comboBoxAgentStartVertex);
			this.panelDijkstra.Controls.Add(this.comboBoxDestineVertex);
			this.panelDijkstra.Location = new System.Drawing.Point(6, 6);
			this.panelDijkstra.Name = "panelDijkstra";
			this.panelDijkstra.Size = new System.Drawing.Size(462, 366);
			this.panelDijkstra.TabIndex = 17;
			// 
			// buttonCalculateDijkstra
			// 
			this.buttonCalculateDijkstra.Location = new System.Drawing.Point(143, 254);
			this.buttonCalculateDijkstra.Name = "buttonCalculateDijkstra";
			this.buttonCalculateDijkstra.Size = new System.Drawing.Size(203, 58);
			this.buttonCalculateDijkstra.TabIndex = 16;
			this.buttonCalculateDijkstra.Text = "Calculate";
			this.buttonCalculateDijkstra.UseVisualStyleBackColor = true;
			this.buttonCalculateDijkstra.Click += new System.EventHandler(this.ButtonCalculateDijkstraClick);
			// 
			// labelInitVertexAgent
			// 
			this.labelInitVertexAgent.Location = new System.Drawing.Point(70, 77);
			this.labelInitVertexAgent.Name = "labelInitVertexAgent";
			this.labelInitVertexAgent.Size = new System.Drawing.Size(117, 27);
			this.labelInitVertexAgent.TabIndex = 13;
			this.labelInitVertexAgent.Text = "Init Vertex";
			// 
			// labelDestineVertex
			// 
			this.labelDestineVertex.Location = new System.Drawing.Point(70, 125);
			this.labelDestineVertex.Name = "labelDestineVertex";
			this.labelDestineVertex.Size = new System.Drawing.Size(117, 27);
			this.labelDestineVertex.TabIndex = 15;
			this.labelDestineVertex.Text = "Destine Vertex";
			// 
			// comboBoxAgentStartVertex
			// 
			this.comboBoxAgentStartVertex.FormattingEnabled = true;
			this.comboBoxAgentStartVertex.Location = new System.Drawing.Point(194, 74);
			this.comboBoxAgentStartVertex.Name = "comboBoxAgentStartVertex";
			this.comboBoxAgentStartVertex.Size = new System.Drawing.Size(207, 28);
			this.comboBoxAgentStartVertex.TabIndex = 12;
			// 
			// comboBoxDestineVertex
			// 
			this.comboBoxDestineVertex.FormattingEnabled = true;
			this.comboBoxDestineVertex.Location = new System.Drawing.Point(194, 122);
			this.comboBoxDestineVertex.Name = "comboBoxDestineVertex";
			this.comboBoxDestineVertex.Size = new System.Drawing.Size(207, 28);
			this.comboBoxDestineVertex.TabIndex = 14;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBox1.Location = new System.Drawing.Point(795, 793);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(267, 73);
			this.richTextBox1.TabIndex = 25;
			this.richTextBox1.Text = "Time Complexity:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1780, 880);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.labelNumberOfCirclesFound);
			this.Controls.Add(this.labelMoreVerticesAgent);
			this.Controls.Add(this.tabControlAnimation);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(5, 5, 20, 5);
			this.Text = "p01_HinojosaAcosta";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAgentSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPredatorsNum)).EndInit();
			this.panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			this.tabControlAnimation.ResumeLayout(false);
			this.tabPageNormal.ResumeLayout(false);
			this.panelNormalAgents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalNormalAgents)).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalAgentSpeed)).EndInit();
			this.tabPagePredatorPrey.ResumeLayout(false);
			this.panelPreyPredator.ResumeLayout(false);
			this.panelPreyPredator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPreys)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreyPredatorSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPredators)).EndInit();
			this.tabPageDijkstra.ResumeLayout(false);
			this.panelDijkstra.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelMoreVerticesAgent;
		private System.Windows.Forms.CheckBox checkBoxShortestPairCircleBruteForce;
		private System.Windows.Forms.CheckBox checkBoxLowestEdge;
		private System.Windows.Forms.Timer timerAgents;
		private System.Windows.Forms.Button buttonShowAgents;
		private System.Windows.Forms.Button buttonShowGraph;
		private System.Windows.Forms.TreeView treeViewCirclesConnections;
		private System.Windows.Forms.Label labelNumberOfCirclesFound;
		private System.Windows.Forms.Button buttonFindCirclesCenters;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonSelectImage;
		private System.Windows.Forms.Button buttonShowKruskalARM;
		private System.Windows.Forms.CheckBox checkBoxPrimArm;
		private System.Windows.Forms.CheckBox checkBoxKruskalArm;
		private System.Windows.Forms.Button buttonShowPrimARM;
		private System.Windows.Forms.Button buttonKruskalSelectedEdgesOrder;
		private System.Windows.Forms.Button buttonPrimSelectedEdgesOrder;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.ComboBox comboBoxPreyInitVertex;
		private System.Windows.Forms.Label labelPreyInit;
		private System.Windows.Forms.Button buttonStartPreyPredators;
		private System.Windows.Forms.NumericUpDown numericUpDownPredatorsNum;
		private System.Windows.Forms.Label labelPredatorsNum;
		private System.Windows.Forms.CheckBox checkBoxDijkstraPath;
		private System.Windows.Forms.Label labelPreyDestine;
		private System.Windows.Forms.ComboBox comboBoxPreyDest;
		private System.Windows.Forms.Button buttonCreatePreyPredators;
		private System.Windows.Forms.Label labelAgentSpeed;
		private System.Windows.Forms.NumericUpDown numericUpDownAgentSpeed;
		private System.Windows.Forms.CheckBox checkBoxShortestPairCircleDivideConquer;
		private System.Windows.Forms.CheckBox checkBoxLeveledGraph;
		private System.Windows.Forms.TabControl tabControlAnimation;
		private System.Windows.Forms.TabPage tabPageNormal;
		private System.Windows.Forms.TabPage tabPagePredatorPrey;
		private System.Windows.Forms.Button buttonStartAllNormalAgents;
		private System.Windows.Forms.Button buttonCreateAllNormalAgents;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownNormalAgentSpeed;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.RadioButton radioButtonMoveDFS;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButtonMoveRandom;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.RadioButton radioButtonGraphTotal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButtonGraphKruskal;
		private System.Windows.Forms.RadioButton radioButtonGraphPrim;
		private System.Windows.Forms.Label labelTotalAgents;
		private System.Windows.Forms.NumericUpDown numericUpDownTotalNormalAgents;
		private System.Windows.Forms.Panel panelNormalAgents;
		private System.Windows.Forms.Button buttonCircles;
		private System.Windows.Forms.Button buttonStopAnimation;
		private System.Windows.Forms.Label labelPrimInitVertex;
		private System.Windows.Forms.ComboBox comboBoxPrimInitVertex;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Panel panelPreyPredator;
		private System.Windows.Forms.Button buttonStopAnimationPredatosPreys;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDownPreyPredatorSpeed;
		private System.Windows.Forms.Button buttonStartPredatorPreys;
		private System.Windows.Forms.Button buttonCreatePredatorPreys;
		private System.Windows.Forms.NumericUpDown numericUpDownTotalPredators;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numericUpDownTotalPreys;
//		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TabPage tabPageDijkstra;
		private System.Windows.Forms.Label labelDestineVertex;
		private System.Windows.Forms.ComboBox comboBoxDestineVertex;
		private System.Windows.Forms.Label labelInitVertexAgent;
		private System.Windows.Forms.ComboBox comboBoxAgentStartVertex;
		private System.Windows.Forms.Button buttonCalculateDijkstra;
		private System.Windows.Forms.CheckBox checkBoxRandomPreys;
		private System.Windows.Forms.CheckBox checkBoxNormalRandomVertex;
		private System.Windows.Forms.Panel panelDijkstra;
		private System.Windows.Forms.CheckBox checkBoxSelectAll;
		private System.Windows.Forms.Button buttonEditCurrent;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
//		private System.Windows.Forms.Button button1;
	}
}
