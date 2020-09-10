/*
 * Created by SharpDevelop.
 * User: EliteBook
 * Date: 25/01/2019
 * Time: 05:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.IO;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List<Circle> circles; //TODO Initialize circles directly in graph
		
		Color circlesColor;
		Color backgroundColor;
		Color agentsColor;
		Color predatorsColor;
		Color idColor;
		Color edgesColor;
		Color centersColor;
		Color idCircleLabel;
		
		Bitmap bmp;
		Bitmap bmpAnimation;
		Bitmap bmpExtraInfo;
		
		Graph graph; //MAIN GRAPH
		Edge lowestEdge; 
		Edge shortestPairVertexBruteForce; //Returned as edge
		Edge shortestPairVertexDivideConquer;
		Kruskal kruskal; //Árbol de Recubrimiento Mínimo
		Prim prim; //ARM
		List<Agent> agents;
		List<Agent> deadAgents;
		int agentsSpeed;
		
		int agentAction;
		
		Dijkstra dijkstra;
		
		Random random;
		
		public MainForm()
		{
			InitializeComponent();
			buttonFindCirclesCenters.Enabled = false;
			circlesColor = Color.Black;
			backgroundColor = Color.White;
			agentsColor = Color.Red;
			predatorsColor = Color.Blue;
			idColor = Color.Red;
			this.edgesColor = Color.Black;
			this.centersColor = Color.Yellow;
			this.idCircleLabel = Color.Red;
			graph = new Graph();
//			armKruskal = new Kruskal(); //Init until needed
//			armPrim = new Prim(); //Init until needed
			this.agentAction = (int)AgentAction.NORMAL;
			this.agents = new List<Agent>();
			this.deadAgents = new List<Agent>();
			this.agentsSpeed = 10;
			numericUpDownAgentSpeed.Value = agentsSpeed;
			initElements();
			random = new Random();
		}
		
		void initElements(){
									
			checkBoxPrimArm.Enabled = false;
			checkBoxKruskalArm.Enabled = false;
			checkBoxShortestPairCircleBruteForce.Enabled = false;
			checkBoxShortestPairCircleDivideConquer.Enabled = false;
			checkBoxLowestEdge.Enabled = false;
			checkBoxDijkstraPath.Enabled = false;
			checkBoxLeveledGraph.Enabled = false;
			checkBoxSelectAll.Enabled = false;
			
			buttonKruskalSelectedEdgesOrder.Enabled = false;
			buttonPrimSelectedEdgesOrder.Enabled = false;
			
			buttonCreatePreyPredators.Enabled = false;
			buttonStartPreyPredators.Enabled = false;
			
			buttonCircles.Enabled = false;
			buttonShowGraph.Enabled = false;
			buttonShowKruskalARM.Enabled = false;
			buttonShowPrimARM.Enabled = false;
			buttonShowAgents.Enabled = false;
			
			numericUpDownNormalAgentSpeed.Value = 10;
			numericUpDownPreyPredatorSpeed.Value = 10;
			//Normal
			panelNormalAgents.Enabled = false;
			panelPreyPredator.Enabled = false;
			panelDijkstra.Enabled = false;
//			numericUpDownTotalNormalAgents.Enabled = false;
//			numericUpDownAgentSpeed.Enabled = false;
//			buttonCreateAllNormalAgents.Enabled = false;
//			buttonStartAllNormalAgents.Enabled = false;
			radioButtonGraphTotal.Checked = true;
			radioButtonMoveRandom.Checked = true;
			
			checkBoxNormalRandomVertex.Checked = true;
			
			comboBoxPrimInitVertex.Enabled = false;
			labelPrimInitVertex.Enabled = false;
			
			checkBoxRandomPreys.Checked = false;
			checkBoxRandomPreys.Enabled = false;
			
			richTextBox1.Text = "Time Complexity:";
			pictureBox1.BackgroundImage = null;
		}
		
		#region EVENTS
		void ButtonSelectImageClick(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
			
			if (openFileDialog1.ShowDialog() == DialogResult.OK){
				clearAll();
				initElements();
				string route = openFileDialog1.FileName;
				string ext = Path.GetExtension(route);
				ext.ToLower();
				if(ext.Equals(".jpg") || ext.Equals(".png")|| ext.Equals(".gif")){}
				else return;
					
				this.bmp = new Bitmap(route);
				pictureBox1.Image = this.bmp;	
				buttonFindCirclesCenters.Enabled = true;
				timerAgents.Stop();
				//Bmp animation
				this.bmpAnimation = new Bitmap(this.bmp.Width, this.bmp.Height);	
//				//Bmp extra
//				this.bmpExtraInfo = new Bitmap(this.bmp.Width, this.bmp.Height);	
			}
		}
		
		
		void ButtonFindCirclesCentersClick(object sender, EventArgs e){
			//FIND CIRCLES
			buttonFindCirclesCenters.Enabled = false;
			circles = findCircles();
			labelNumberOfCirclesFound.Text = circles.Count.ToString() + " circles found.";
			//GRAPH MAINTENANCE
			insertCirclesinGraph();
			//CONNECT CIRCLES - GRAPH DONE
			connectCircles();
			if(this.graph.Vertices.Count <= 0 )return; //RETURN IF NO EDGES NOR CIRCLES (OR 1)
			buttonCircles.Enabled = true;
			buttonShowGraph.Enabled = true;
			//Get Lowest edge and shortest pair of circles
			this.lowestEdge = graph.getLowestEdgeBruteForce();
//			this.shortestPairVertex = graph.getShortestPairVertexBruteForce();
			this.shortestPairVertexBruteForce = graph.getShortestPairVertexBruteForce();
			this.shortestPairVertexDivideConquer = graph.getShortestPairVertexDivideConquer();
//			MessageBox.Show("Time Complexity\n Brute Force: "+graph.TimerBruteForce+" ms\n Divide Conquer: "+graph.TimerDivideConquer+" ms");
//			richTextBox1.Text ="Time Complexity\n Brute Force: "+graph.TimerBruteForce+" ms\n Divide Conquer: "+graph.TimerDivideConquer+" ms";
			//MessageBox.Show("Time Complexity\n Brute Force: "+graph.TotalBruteForceTime+" ms\n Divide Conquer: "+graph.TotalDivideConquerTime+" ms");
			richTextBox1.Text ="Time Complexity\n Brute Force: "+graph.TotalBruteForceTime+" ms\n Divide Conquer: "+graph.TotalDivideConquerTime+" ms";
			//BFS
			getLeveledGraphByBFS();
			//GET ARM
			getArmByKruskal();
			getArmByPrim(this.graph.Vertices[0]);
			//GET DIJSKTRA
			getDijkstra(graph.Vertices[0],graph.Vertices[0]);
			//Init Vertices Combo
			initVerticesCombo(this.graph);
			initNumericLimits(graph);
			initLimitOfPredators(this.graph);
			//DRAW CHANGES
			drawAll();
			setGraphTreeView(this.graph);
			this.bmpExtraInfo = new Bitmap(this.bmp);
			pictureBox1.Image = this.bmpExtraInfo;
			
			//ENABLE
			panelNormalAgents.Enabled = true;
			panelPreyPredator.Enabled = true;
			panelDijkstra.Enabled = true;
			buttonStartAllNormalAgents.Enabled = false;
			buttonStartAllNormalAgents.BackColor = Color.Gray;
			buttonStartPredatorPreys.Enabled = false;
			buttonStartPredatorPreys.BackColor = Color.Gray;
			buttonStopAnimation.Enabled = false;
			buttonStopAnimation.BackColor = Color.Gray;
			buttonStopAnimationPredatosPreys.Enabled = false;
			buttonStopAnimationPredatosPreys.BackColor = Color.Gray;
			buttonCreateAllNormalAgents.Enabled = true;
			buttonCreateAllNormalAgents.BackColor = Color.LightSteelBlue;
			buttonCreatePredatorPreys.Enabled = true;
			buttonCreatePredatorPreys.BackColor = Color.LightSteelBlue;
//			buttonCreatePreyPredators.Enabled = true;
//			buttonCreatePreyPredators.BackColor = Color.LightSteelBlue;
			checkBoxShortestPairCircleBruteForce.Enabled = true;
			checkBoxShortestPairCircleDivideConquer.Enabled = true;
			checkBoxLowestEdge.Enabled = true;
			checkBoxSelectAll.Enabled = true;
				
		}
		
		void getLeveledGraphByBFS(){
			bool leveled = false;
			int count = 0;
			while(!leveled){
				foreach(Vertex v in graph.Vertices){
					count++;
					leveled = graph.BFS(v);
					if(leveled) break;
				}
				if(count > graph.Vertices.Count) break;
			}
			if(!leveled) MessageBox.Show("Not leveled graph found");
			else checkBoxLeveledGraph.Enabled = true;
		}
		
		void initVerticesCombo(Graph g){
			foreach(Vertex v in g.Vertices){
				comboBoxPreyInitVertex.Items.Add(v.Id);
				comboBoxPreyDest.Items.Add(v.Id);
				comboBoxPrimInitVertex.Items.Add(v.Id);
				comboBoxAgentStartVertex.Items.Add(v.Id);
				comboBoxDestineVertex.Items.Add(v.Id);
			}
			if(g.Vertices.Count > 0 ){
				
				comboBoxPreyInitVertex.SelectedIndex = 0;
				comboBoxPreyInitVertex.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBoxPreyInitVertex.Enabled = true;
				
				comboBoxPreyDest.SelectedIndex = 0;
				comboBoxPreyDest.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBoxPreyDest.Enabled = true;
				
				comboBoxPrimInitVertex.SelectedIndex = 0;
				comboBoxPrimInitVertex.DropDownStyle = ComboBoxStyle.DropDownList;
				
				comboBoxAgentStartVertex.SelectedIndex = 0;
				comboBoxAgentStartVertex.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBoxAgentStartVertex.Enabled = true;
				
				comboBoxDestineVertex.SelectedIndex = 0;
				comboBoxDestineVertex.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBoxDestineVertex.Enabled = true;
			}
		}
		
		void initNumericLimits(Graph g){
			numericUpDownTotalNormalAgents.Maximum = g.Vertices.Count;
			numericUpDownTotalPreys.Maximum = g.Vertices.Count;
			numericUpDownTotalPredators.Maximum = g.Vertices.Count;
		}
		
		void initLimitOfPredators(Graph g){
			numericUpDownPredatorsNum.Minimum = 0;
			numericUpDownPredatorsNum.Maximum = g.Vertices.Count -1; //-1 Because the prey occupies already one vertex
		}
		
	
		
		void ButtonCirclesClick(object sender, EventArgs e){
			setListTreeView(this.circles);
		}
		
		void ButtonShowGraphClick(object sender, EventArgs e){
			setGraphTreeView(this.graph);
		}
		
		void ButtonShowKruskalARMClick(object sender, EventArgs e){
			setGraphTreeView(this.kruskal.ARM);
			setKruskalExtraInfoTreeView();
		}
		
		void ButtonShowPrimARMClick(object sender, EventArgs e){
			setGraphTreeView(this.prim.ARM);
			setPrimExtraInfoTreeView();
			
		}
		
		void ButtonShowAgentsClick(object sender, EventArgs e){	
			showAgentPath();
		}
		
		void ButtonStartAgentsAnimationClick(object sender, EventArgs e){
//			this.agentAction = (int)AgentAction.ARM;
			timerAgents.Start();
		}
		
		void TimerAgentsTick(object sender, EventArgs e)
		{
			switch(agentAction){
				case (int)AgentAction.NORMAL:
					if(!moveAgents()){
						if(radioButtonGraphTotal.Checked){
							labelMoreVerticesAgent.Text = getMoreVerticesAgent().ToString();
							MessageBox.Show(labelMoreVerticesAgent.Text+" Won!");
						}
						buttonCreateAllNormalAgents.Enabled = true;
						buttonCreateAllNormalAgents.BackColor = Color.LightSteelBlue;
						buttonStartAllNormalAgents.Enabled = false;
						buttonStartAllNormalAgents.BackColor = Color.Gray;
						buttonStopAnimation.Enabled = false;
						buttonStopAnimation.BackColor = Color.Gray;
						buttonShowAgents.Enabled = true;
					}
					break;
				case (int)AgentAction.PREY_PREDATOR:
//					movePredators();
					moveAgents();
					break;
				default:
					break;
			}
			
			
		}
		
		//TODO Calculate once
		void CheckBoxLowestEdgeCheckedChanged(object sender, EventArgs e)
		{
			drawExtras();
//			setPictureBoxImageWithBitmap(this.bmp);
//			setBmpAnimation();
		}
		
		void drawLowestEdge(Bitmap b){
			if(checkBoxLowestEdge.Checked){
				if(!ReferenceEquals(lowestEdge,null) ){
					drawLine(b,lowestEdge.Origin.Node.Center,lowestEdge.Destination.Node.Center,Color.Orange,2);
				}	
			}
		}
		
		//TODO Calculate once
		void CheckBoxShortestPairCirckeCheckedChanged(object sender, EventArgs e)
		{
			drawExtras();
//			pictureBox1.Image = this.bmp;
//			setBmpAnimation();
		}
		
		void CheckBoxShortestPairCircleDivideConquerCheckedChanged(object sender, EventArgs e)
		{
			drawExtras();
		}
		
		void drawShortestPairVertex(Bitmap b, Edge pair, Color c, bool check){
			if(check){
				Brush brush = new SolidBrush(c);
				if(!ReferenceEquals(pair,null) ){
					drawCircle(b,pair.Origin.Node,brush);
					drawCircle(b,pair.Destination.Node,brush);
				}
			}
		}
		
		void CheckBoxKruskalArmCheckedChanged(object sender, EventArgs e){
			drawExtras();
		}
		
		void drawKruskalArm(Bitmap b){
			if(checkBoxKruskalArm.Checked)
				drawGraph(b,this.kruskal.ARM,Color.Red,4);
		}
		void CheckBoxPrimArmCheckedChanged(object sender, EventArgs e){	
			drawExtras();
		}
		
		void drawPrimArm(Bitmap b){
			if(checkBoxPrimArm.Checked)
				drawGraph(b,this.prim.ARM,Color.Green,14);
		}
		
		void CheckBoxDijkstraPathCheckedChanged(object sender, EventArgs e){
			drawExtras();
		}
		
		void drawDijkstra(Bitmap b){
			if(checkBoxDijkstraPath.Checked){
				if(!ReferenceEquals(dijkstra.DijkstraGraph,null))
					drawGraph(b,this.dijkstra.DijkstraGraph,Color.Violet,4);
			}
		}
		
				
		void CheckBoxLeveledGraphCheckedChanged(object sender, EventArgs e){ drawExtras();}
		
		void drawLeveledGraph(Bitmap b){
			if(checkBoxLeveledGraph.Checked && graph.LeveledPath.Count > 0){
				Brush brush = new SolidBrush(Color.Orange);
				drawCircle(bmpExtraInfo,graph.LeveledPath[0].Origin.Node,brush);
				drawPath(b,graph.LeveledPath, Color.Orange,3);
			}
		}
			
		#endregion 
		
		#region FIND CIRCLES		
		//Returns circle's important information in a list
		List<Circle> findCircles(){
			int x,y;
			Color actualPixelColor;
			Point startPoint = new Point();
			List<Circle> circlesList = new List<Circle>();
			int idCounter = 1;
			bool insideBmp;
			
			for( y = 0; y < this.bmp.Height; y++){
				for( x = 0; x < this.bmp.Width; x++){
					insideBmp = true;
					actualPixelColor = this.bmp.GetPixel(x,y);
					//Possible Circle
					if(isSameColor(actualPixelColor,this.circlesColor)){
						startPoint.X = x;
						startPoint.Y = y;
					
						Point halfPoint = new Point();
						int x_right = startPoint.X;
						do{
							x_right++;
							if(x_right >= this.bmp.Width){
								insideBmp = false;
								break;
							}
							else
								actualPixelColor = this.bmp.GetPixel(x_right,startPoint.Y);
						}
						while(isSameColor(actualPixelColor,this.circlesColor));
						
						if(!insideBmp) break; //Breaks internal for
						
						halfPoint.Y = startPoint.Y;
						halfPoint.X = (x_right-1 + startPoint.X)/2; //Center in x axis
						if(halfPoint.Y-1 >= 0){
							actualPixelColor = this.bmp.GetPixel(halfPoint.X,halfPoint.Y-1); 
							if(!isSameColor(actualPixelColor, this.circlesColor)){ //is the top?
								insideBmp = true;
								int y_down = halfPoint.Y;
								//Find center in y
								do{
									y_down++;
									if(y_down >= this.bmp.Height){
										insideBmp = false;
										break;
									}
									else
										actualPixelColor = this.bmp.GetPixel(halfPoint.X,y_down);
								}
								while(isSameColor(actualPixelColor,this.circlesColor));
								if(!insideBmp) break;
								y_down--;
								//CENTER 
								int radius = (y_down-startPoint.Y)/2;
								halfPoint.Y = (y_down + startPoint.Y)/2;
								Circle circle = new Circle(idCounter,halfPoint.X,halfPoint.Y, radius );
								if(isCircle(halfPoint,radius)){
									idCounter++;
									circlesList.Add(circle);	
										
								}
							}	
						}
						x = x_right-1; //Update x counter
					}					
				}
			}
			return circlesList;
		}
		
		       	
		//Uses circle color and background color to identify if is a circle (not incomplete nor donuts)
		bool isCircle(Point center, int radius){
			if(isSameCircleColor(center, radius-4,this.circlesColor))
				if(isSameCircleColor(center, radius+4,this.backgroundColor))
					return true; //isCircle
			return false; //Incomplete or donut
		}
		
		//Aux function for "isCircle"
		bool isSameCircleColor(Point center, int radius, Color circleColor){
			Point checkPoint = new Point();
			Color actualPixelColor;
			if(radius < 1 ) return false;
			if(center.X-radius >= 0 && center.X+radius < this.bmp.Width){
				if(center.Y-radius >= 0 && center.Y+radius < this.bmp.Height){
					checkPoint.X = center.X-radius;
					checkPoint.Y = center.Y;
					actualPixelColor = this.bmp.GetPixel(checkPoint.X, checkPoint.Y);
					//X left
					if(isSameColor(actualPixelColor,circleColor)){
						checkPoint.X = center.X+radius;
						//MessageBox.Show(checkPoint.X.ToString() + ", " + checkPoint.Y.ToString());
						actualPixelColor = this.bmp.GetPixel(checkPoint.X, checkPoint.Y);
						//X right
						if(isSameColor(actualPixelColor,circleColor)){
							checkPoint.X = center.X;
							checkPoint.Y = center.Y-radius;
							actualPixelColor = this.bmp.GetPixel(checkPoint.X, checkPoint.Y);
							//Y up
							if(isSameColor(actualPixelColor,circleColor)){
								checkPoint.Y = center.Y+radius;
								actualPixelColor = this.bmp.GetPixel(checkPoint.X, checkPoint.Y);
								//Y down
								if(isSameColor(actualPixelColor,circleColor)){
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}
		#endregion
		
		#region CONNECT CIRCLES
		
		void connectCircles(){ //Uses circlesList but can use graph's vertices
			Point initialPoint = new Point();
			Point finalPoint = new Point();
			for(int x = 0; x < circles.Count; x++){
				for(int y = x+1; y < circles.Count; y++){
					initialPoint = circles[x].Center;
					finalPoint = circles[y].Center;
					List<Point> pixelsList = DDA(initialPoint,finalPoint);
					if( pixelsList != null ){//Exists line between points
						//ADD TO GRAPH
						Vertex origin = this.graph.Vertices[x];
						Vertex destination = this.graph.Vertices[y];
						int distance = getPointsDistance(initialPoint,finalPoint);
						//The pixelsList is inserted depending on the way. From origin to destine.
						origin.addEdge(origin,destination,distance,pixelsList);
						destination.addEdge(destination,origin,distance,pixelsList);
						//drawLine(this.bmp,initialPoint,finalPoint,Color.Blue,2); //If EDGES ARE OBSTACLES
					}	
				}
			}
		}
				
		int getPointsDistance(Point initialPoint, Point finalPoint){
			return (int)Math.Sqrt( Math.Abs( ((finalPoint.X-initialPoint.X)*(finalPoint.X-initialPoint.X))+(finalPoint.Y-initialPoint.Y)*(finalPoint.Y-initialPoint.Y) ) );
		}
		
		///AUXILIAR
		void auxPrintPixelsList(List<Point> pointList){
			for(int i=0; i<pointList.Count; i++){
				this.bmp.SetPixel(pointList[i].X,pointList[i].Y,Color.Blue);
			}
		}
		//Digital Differential Analyzer-Line generation algorithm
		List<Point> DDA(Point p_0, Point p_f)
        {
			State actualState = State.START_POINT;
			
			List<Point> pixelsList = new List<Point>();
        	double difX = ((double)p_f.X - (double)p_0.X);
        	double difY = ((double)p_f.Y - (double)p_0.Y);
            double m = difY / difX ;
            double b = (double)p_f.Y - m * (double)p_f.X;
            
            double x_i;
            double y_i;
            Point actualPoint = new Point();
            
            if(difX == 0){ //SLOPE INDETERMINES
            	pointsUptoDown(ref p_0, ref p_f);
            	for(y_i = p_0.Y; y_i <= p_f.Y; y_i++){
            		actualPoint.X = (int)p_0.X;
            		actualPoint.Y = (int)Math.Round(y_i);
            		actualState = evaluateState(actualPoint,actualState,m);
            		pixelsList.Add(actualPoint);
            		if(actualState == State.BLOCKED){
            			pixelsList = null;
            			return pixelsList;	
            		}
                    	
                    //this.bmp.SetPixel((int)p_0.X, (int)Math.Round(y_i), Color.Black);
                }
            }
            else if (m <= 1 && m>= -1){ //Between -1 and 1
            	//MUST BE LEFT TO RIGHT
            	pointsLeftToRight( ref p_0, ref p_f);
                for(x_i = p_0.X; x_i <= p_f.X; x_i++){
                    y_i = m * x_i + b;
                    actualPoint.X = (int)x_i;
                    actualPoint.Y = (int)Math.Round(y_i);
                    actualState = evaluateState(actualPoint,actualState,m);
                    pixelsList.Add(actualPoint);
                    if(actualState == State.BLOCKED){
            			pixelsList = null;
            			return pixelsList;	
            		}
                }
            }
            else{ // Menor que -1 o mayor que 1
            	//MUST BE UP TO DOWN
            	pointsUptoDown(ref p_0, ref p_f);
                for(y_i = p_0.Y; y_i <= p_f.Y; y_i++){
                    x_i = (y_i - b) / m;
                    actualPoint.X = (int)Math.Round(x_i);
                    actualPoint.Y = (int)Math.Round(y_i);
                    actualState = evaluateState(actualPoint,actualState,m);
                    pixelsList.Add(actualPoint);
                    if(actualState == State.BLOCKED){
            			pixelsList = null;
            			return pixelsList;	
            		}
                }
            }
            if(actualState == State.START_POINT)
            		pixelsList = null; //Already marked
            return pixelsList;
        }
		

		void pointsLeftToRight(ref Point p_0, ref Point p_f){
        	Point aux;
        	if(p_0.X > p_f.X){
        		aux = p_0;
        		p_0 = p_f;
        		p_f = aux;
        	}
        }
        
        void pointsUptoDown(ref Point p_0, ref Point p_f){
        	Point aux;
        	if(p_0.Y > p_f.Y){
        		aux = p_0;
        		p_0 = p_f;
        		p_f = aux;
        	}
        }
		
		public enum State{
			START_POINT,
			IN_BACKGROUND,
			POSSIBLE_END,
			BLOCKED,
			END_POINT//Not in use
		}
		
		
		State evaluateState(Point actualPoint, State actualState, double slope){
			Color pixelColor = this.bmp.GetPixel(actualPoint.X,actualPoint.Y);
			//MessageBox.Show(actualPoint.ToString()+" - "+actualState.ToString()+" - "+pixelColor.ToString());
			switch(actualState){
				case State.START_POINT: //Inside Initial circle
					if(isSameColor( pixelColor,this.backgroundColor))//It got out of initial circle
						return State.IN_BACKGROUND;
					return State.START_POINT;
				case State.IN_BACKGROUND:
					if(isSameColor(pixelColor,this.circlesColor)) //Circle color found - Possibility of end
						return State.POSSIBLE_END;
					else if(!isSameColor(pixelColor,this.backgroundColor))
						return State.POSSIBLE_END;
					return State.IN_BACKGROUND;
				case State.POSSIBLE_END: //Circle color found - Possibility of end
					if(isSameColor( pixelColor,this.backgroundColor)) // If it goes out of it, it wasn't final circle- then is OBSTACLE!
						return State.BLOCKED;
					return State.POSSIBLE_END;
				default: //SURE?
					return State.IN_BACKGROUND;
			}
		}
		
		#endregion
		
		#region AGENTS
		
		void createAgents(){
			agents.Clear();
			switch(agentAction){
				case (int)AgentAction.NORMAL:
//					createAgentArm();
					break;
				case (int)AgentAction.PREY_PREDATOR:
//					createAgentDijkstra();
//					createRandomPredators((int)numericUpDownTotalPredators.Value);
					break;
				default:
					break;
			}
		}
		
		int randomNumber(Random random, int init, int final){
			return (int)random.Next(init, final);
		}
		
			
		
		//Creates it in graph
		void createRandomAgents(Graph g,int totalAgents, int moveAs, int agentType){
			agents.Clear();
			Random random = new Random();
			List<int> selectedVertices = new List<int>();
			for(int i=0; i < totalAgents; i++){
				bool inAgentsList;
				do{
					int randomVertex = randomNumber(random, 0, g.Vertices.Count); //Goes from vertex 0 to total of vertices -1 cause random takes +1
					if(selectedVertices.Contains(randomVertex))
						inAgentsList = true;
					else{
						inAgentsList = false;
						Agent newAgent = new Agent(i,g.Vertices[randomVertex],(int)numericUpDownNormalAgentSpeed.Value,random,agentType,moveAs);
						agents.Add(newAgent);
						selectedVertices.Add(randomVertex);
					}
				}
				while(inAgentsList);
			}	
		}
		
		//Creates it in graph
		//Selected vertices list has the elements in which the predator can born
		void createRandomPredators(List<int>selectedVertices, int totalAgents){
			Random random = new Random();
			for(int i=0; i < totalAgents; i++){ //TODO Should start at 0, but starts at 1 considering the dijkstra agent
				bool inAgentsList;
				do{
					int randomVertex = randomNumber(random, 0, graph.Vertices.Count+1); //Goes from vertex 0 to total of vertices -1 cause random takes +1
					if(selectedVertices.Contains(randomVertex)){
						inAgentsList = false;
						Agent newAgent = new Agent(i,graph.Vertices[randomVertex-1],(int)numericUpDownPreyPredatorSpeed.Value,random,(int)Agent.Type.Predator,(int)Agent.MoveAs.DFS);
						agents.Add(newAgent);
						if(selectedVertices.Count == 0)
							break;
						selectedVertices.RemoveAt(selectedVertices.BinarySearch(randomVertex));
					}
					else{
						inAgentsList = true;

					}
				} while(inAgentsList);
				if(selectedVertices.Count == 0) break;
			}	
		}
		
		void drawAgents(List<Agent> ag){
			clearBitmap(this.bmpAnimation);
			Brush brushAgents;
			Brush brushId = new SolidBrush(idColor);
			for(int i=0; i < ag.Count; i++){
				switch(ag[i].AgentType){
					case (int)Agent.Type.Predator:
						brushAgents = new SolidBrush(predatorsColor);
						drawAgent(bmpAnimation,ag[i].getActualPoint(),brushAgents,brushId, ag[i].Id, true);
						break;
					default:
						brushAgents = new SolidBrush(agentsColor);
						drawAgent(bmpAnimation,ag[i].getActualPoint(),brushAgents,brushId, ag[i].Id, true);
						break;
				}
			}
			setBmpAnimation();
		}
		
		Graph getSelectedArm(){
//			if(radioButtonPrim.Checked){
//				return prim.ARM;
//			}
//			else{
//				return kruskal.ARM;
//			}
			if(radioButtonGraphKruskal.Checked)
				return kruskal.ARM;
			if(radioButtonGraphPrim.Checked)
				return prim.ARM;
			else
				return graph;
		}
		
		bool moveAgents(){
			clearBitmap(this.bmpAnimation);
			Brush brushAgents;
			Brush brushId = new SolidBrush(idColor);
			bool continueAnim = false;
			for(int i=0; i < agents.Count; i++){
				Agent agent = agents[i];
				
					
				//Select color deepending on agent type
				switch(agent.AgentType){
					case (int)Agent.Type.Normal:
						if(agent.move(getSelectedArm())){//At least one moves
							continueAnim = true;
						}
						brushAgents = new SolidBrush(agentsColor);
						drawAgent(bmpAnimation,agent.getActualPoint(),brushAgents,brushId, agents[i].Id, true);
						break;
					case (int)Agent.Type.Predator:
						if(agent.move(getSelectedArm())){//At least one moves
							continueAnim = true;
						}
						brushAgents = new SolidBrush(predatorsColor);
						drawAgent(bmpAnimation,agent.getActualPoint(),brushAgents,brushId, agents[i].Id, false);
						break;
					case (int)Agent.Type.Prey:
						if(agent.CanMove){
							continueAnim = true;
						}
						if((int)agent.AgentIsNow == (int)Agent.AgentIs.Moving){
							switch(agent.move(agent.DijkstraPath)){
								case (int)Agent.AgentIs.Dead:
	//								timerAgents.Stop();
									deadAgents.Add(agent);
									timerAgents.Stop();
									MessageBox.Show("Agent "+agent.Id+" died");
									timerAgents.Start();
									break;
								case (int)Agent.AgentIs.Moving:
									continueAnim = true;
									break;
								default:
									break;
							}
						
						}
						if((int)agent.AgentIsNow != (int)Agent.AgentIs.Dead){
							brushAgents = new SolidBrush(agentsColor);
							drawAgent(bmpAnimation,agent.getActualPoint(),brushAgents,brushId, agents[i].Id, true);
						}
						break;
					default:
						break;
				}
				
			}
			setBmpAnimation();
			if( !continueAnim ){
				timerAgents.Stop();
				MessageBox.Show("Animation ended");
				panelNormalAgents.Enabled = true;
				buttonCreatePredatorPreys.Enabled = true;
				buttonCreateAllNormalAgents.BackColor = Color.LightSteelBlue;
				buttonStartPreyPredators.Enabled = false;
				return false;
			}
			return true;
			
		}
		
		//Moves in main graph
		bool moveAgentsRandomly(){
			clearBitmap(this.bmpAnimation);
			Brush brushAgents = new SolidBrush(agentsColor);
			Brush brushId = new SolidBrush(idColor);
			bool continueAnim = false;
			for(int i=0; i < agents.Count; i++){
				Agent agent = agents[i];
				if(agent.move(getSelectedArm())){//At least one moves
//				if(agent.moveByDFS(getSelectedArm().Vertices[(int)comboBoxAgentStart.SelectedItem - 1],getSelectedArm())){//At least one moves
//				if(agent.moveAgentDFS(getSelectedArm())){//At least one moves
					continueAnim = true;
				}
				drawAgent(bmpAnimation,agent.getActualPoint(),brushAgents,brushId, agents[i].Id,true);
			}
			setBmpAnimation();
			if( !continueAnim ){
				timerAgents.Stop();
				return false;
			}
			return true;
		}
		
		//Moves in main graph
		bool movePredators(){
			clearBitmap(this.bmpAnimation);
			Brush brushAgents = new SolidBrush(predatorsColor);
			Brush brushId = new SolidBrush(idColor);
			bool continueAnim = false;
			for(int i=0; i < agents.Count; i++){
				Agent agent = agents[i];
				if(agent.move(graph)){//At least one moves
					continueAnim = true;
				}
				drawAgent(bmpAnimation,agent.getActualPoint(),brushAgents,brushId, agents[i].Id, true);
			}
			setBmpAnimation();
			if( !continueAnim ){
				timerAgents.Stop();
				buttonStartPreyPredators.Enabled = false;
				return false;
			}
			return true;
		}
		
		//TODO what if there are no agents
		Agent getMoreVerticesAgent(){
			int numVertices;
			int distance, auxDistance;
			int moreVerticesAgent = 0;
			for(int i = 0; i < agents.Count; i++){
				numVertices = agents[i].VisitedEdgesList.Count; //+1 cause vertices, not edges
				distance = 0;
				auxDistance = 0;
				if(numVertices > agents[moreVerticesAgent].VisitedEdgesList.Count)
					moreVerticesAgent = i;
				else if(numVertices == agents[moreVerticesAgent].VisitedEdgesList.Count){
					//New possible agent iteration for distance
					for(int j = 0; j< numVertices; j++){
						distance+=(int)agents[i].VisitedEdgesList[j].Weight;
					}	
					for(int y = 0; y< agents[moreVerticesAgent].VisitedEdgesList.Count; y++){
						auxDistance+=(int)agents[moreVerticesAgent].VisitedEdgesList[y].Weight;
					}
					if(distance > auxDistance) //Change > if criterio de desempate cambia
						moreVerticesAgent = i;
				}
			}
			return agents[moreVerticesAgent];
		}
				
		#endregion
		
		#region ARM
		
		void getArmByPrim(Vertex initVertex){
			if(this.graph.Vertices.Count > 0){
				this.prim = new Prim(this.graph, initVertex);
				checkBoxPrimArm.Enabled = true;
				buttonShowPrimARM.Enabled = true;
				buttonPrimSelectedEdgesOrder.Enabled = true;
			}
		}

		void getArmByKruskal(){
			this.kruskal = new Kruskal(this.graph);
			buttonShowKruskalARM.Enabled = true;
			checkBoxKruskalArm.Enabled = true;
			buttonKruskalSelectedEdgesOrder.Enabled = true;
		}
		

		#endregion
		
		#region DIJKSTRA
		bool getDijkstra(Vertex origin, Vertex destination){
			if(this.graph.Vertices.Count > 0){
				this.dijkstra = new Dijkstra(origin, destination, graph);
				if(ReferenceEquals(this.dijkstra.DijkstraGraph,null))
					return false;
			}
			return true;
			
		}
		
		void createAgentDijkstra(){
			if(this.graph.Vertices.Count > 0){
				if(dijkstra.IsPath){
					Agent newAgent = new Agent(0,dijkstra.DijkstraGraph.Vertices[0],(int)numericUpDownAgentSpeed.Value,(int)Agent.Type.Prey,(int)Agent.MoveAs.Prey); //First pos always has start vertex
					agents.Add(newAgent);	
				}	
			}
		}
		
		
		
		#endregion
		
		#region GRAPH MAINTENANCE
		void insertCirclesinGraph(){
			//int id = 1;
			foreach(Circle circle in this.circles){
				graph.addVertex(circle.Id,circle);
				//id++;
			}
		}
				
		#endregion
		
		#region	GENERAL AUXILIAR FUNCTIONS	
		
		void clearAll(){
			//circles.Clear();
			//Circles List
			List<Circle> circles = new List<Circle>();
			//listBoxCircleCenterPoints.DataSource = circles;
			labelNumberOfCirclesFound.Text = "";
			//Graph
			this.graph = new Graph();
			//TODO PRIM AND KRUSKAL Clear until FindCirclesCenters
			//ComboBox
			comboBoxPreyInitVertex.Items.Clear();
			comboBoxPreyDest.Items.Clear();
			comboBoxPrimInitVertex.Items.Clear();
			comboBoxAgentStartVertex.Items.Clear();
			comboBoxDestineVertex.Items.Clear();
			if(radioButtonGraphPrim.Checked)
				comboBoxPrimInitVertex.Enabled = true;
			else
				comboBoxPrimInitVertex.Enabled = false;
			//Tree View
			treeViewCirclesConnections.Nodes.Clear();
			//Agents label
			labelMoreVerticesAgent.Text = "";
			//CheckBoxes
			checkBoxLowestEdge.Checked = false;
			checkBoxShortestPairCircleBruteForce.Checked = false;
			checkBoxShortestPairCircleDivideConquer.Checked = false;
			checkBoxKruskalArm.Checked = false;
			checkBoxPrimArm.Checked = false;
			checkBoxDijkstraPath.Checked = false;
			checkBoxLeveledGraph.Checked = false;
			
		}
		
		void clearBitmap(Bitmap b){
			using(var graphics = Graphics.FromImage(b)){
				graphics.Clear(Color.Transparent);	
			}
			
		}
		
		void drawAll(){
			drawGraph(this.bmp,this.graph,this.edgesColor,2);
			markCenterCircles(this.bmp,circles,this.centersColor);
		}
		
		bool isSameColor(Color color1, Color color2){
			if( color1.R == color2.R)
				if(color1.G == color2.G)
					if(color1.B == color2.B)
						return true;
			return false;
		}
		
		void highlightPoint(Bitmap bmp, Point point, Color color){
			for(int x = point.X-2; x <= point.X+2; x++)
				for(int y = point.Y-2; y <= point.Y+2; y++)
					bmp.SetPixel(x, y, color);
			
		}
		
		void markCenterCircles(Bitmap bmp, List<Circle> circlesList, Color centerColor){
			Brush b = new SolidBrush(this.idCircleLabel);
			Font f = new Font("Times New Roman",25.0f);
			foreach(Circle c in circlesList){
				Point circleCenter = new Point();
				circleCenter = c.Center;
				highlightPoint(bmp,circleCenter,centerColor);
				using(var graphics = Graphics.FromImage(bmp)){
					graphics.DrawString(c.Id.ToString(),f, b, circleCenter.X, circleCenter.Y);
//					if(c.Id < 10)
//						graphics.DrawString(c.Id.ToString(),f, b, circleCenter.X-(c.Radius+20), circleCenter.Y-9);
//					else
//						graphics.DrawString(c.Id.ToString(),f, b, circleCenter.X-(c.Radius+35), circleCenter.Y-9);
				}
			}
		}
		
		//BIDIRECTIONAL 
		void drawGraph(Bitmap bmp, Graph g,Color lineColor, float width){
			int j;
			int i=0;
			if(ReferenceEquals(g,null)){
				return;
			}
			foreach(Vertex actualVertex in g.Vertices){
				j=0;
				foreach(Edge actualEdge in actualVertex.Edges){
					Point startPoint;
					Point endPoint;
					startPoint = g.Vertices[i].Edges[j].Origin.Node.Center;
					endPoint = g.Vertices[i].Edges[j].Destination.Node.Center;
					if(startPoint.Y == endPoint.Y)
						if(startPoint.X < endPoint.X)
							drawLine(bmp,startPoint,endPoint,lineColor,width);	
					if(startPoint.Y < endPoint.Y) //If startpoint is upper than endPoint, that edge has NOT been marked before
						drawLine(bmp,startPoint,endPoint,lineColor,width);
					j++;	
				}
				i++;
			}
			setPictureBoxImageWithBitmap(bmp);
		}
		
		void drawPath(Bitmap b, List<Edge> path, Color color, float width){
			if(ReferenceEquals(path,null)) return;
			foreach(Edge e in path){
				Point startPoint, endPoint;
				startPoint = e.Origin.Node.Center;
				endPoint = e.Destination.Node.Center;
				drawLine(b,startPoint,endPoint,color,width);
			}
		}
		
		void setPictureBoxImageWithBitmap(Bitmap b){
			pictureBox1.Image = b;
		}
		
		void drawLine(Bitmap b, Point start, Point end, Color color, float penWidth){
			Pen lineColor = new Pen(color,penWidth);
			using(var graphics = Graphics.FromImage(b)){
				graphics.DrawLine(lineColor,start,end);
			}
		}
		
		void drawAgent(Bitmap bmp, Point p, Brush bAgent, Brush bId, int id, bool drawId){
			int r = 8;
			Font f = new Font("Times New Roman",20.0f);
			using(var graphics = Graphics.FromImage(bmp)){
				graphics.FillEllipse(bAgent,p.X-r, p.Y-r,2*r,2*r);
				if(drawId)
					graphics.DrawString(id.ToString(),f,bId, p.X, p.Y);
			}
		}
		
		void drawCircle(Bitmap bmp, Circle c, Brush b){
			int r = c.Radius;
			Font f = new Font("Times New Roman",20.0f);
			using(var graphics = Graphics.FromImage(bmp)){
				graphics.FillEllipse(b,c.Center.X-r, c.Center.Y-r,2*r,2*r);
			}
		}
		
		
		
		void setBmpAnimation(){
			pictureBox1.BackgroundImage = this.bmpExtraInfo;
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom ;
			pictureBox1.Image = this.bmpAnimation;
		}
		
		
		void setGraphTreeView(Graph g){
			treeViewCirclesConnections.Nodes.Clear();
			treeViewCirclesConnections.BeginUpdate();
			int j;
			int i=0;
			foreach(Vertex actualVertex in g.Vertices){
				j=0;
				treeViewCirclesConnections.Nodes.Add(actualVertex.Node.ToString());
				foreach(Edge actualEdge in g.Vertices[i].Edges){
					treeViewCirclesConnections.Nodes[i].Nodes.Add(actualEdge.ToString());
					j++;	
				}
				i++;
			}
			treeViewCirclesConnections.Nodes.Add("Weight: "+g.TotalWeight);
			treeViewCirclesConnections.EndUpdate();
		}
		void setListTreeView(List<Edge> list){
			treeViewCirclesConnections.Nodes.Clear();
			treeViewCirclesConnections.BeginUpdate();
			int i=0;
			foreach(Edge o in list){
				treeViewCirclesConnections.Nodes.Add(o.ToString());
				i++;
			}
			treeViewCirclesConnections.EndUpdate();
		}
		
		void setListTreeView(List<Circle> list){
			treeViewCirclesConnections.Nodes.Clear();
			treeViewCirclesConnections.BeginUpdate();
			int i=0;
			foreach(Circle o in list){
				treeViewCirclesConnections.Nodes.Add(o.ToString());
				i++;
			}
			treeViewCirclesConnections.EndUpdate();
		}
		
		void setPrimExtraInfoTreeView(){
			treeViewCirclesConnections.Nodes.Add("Init Vertex: "+ prim.InitVetex.Id); 
			treeViewCirclesConnections.Nodes.Add("SubGraphs: "+prim.TotalSubGraphs);
		}
		
		void setKruskalExtraInfoTreeView(){
			treeViewCirclesConnections.Nodes.Add("SubGraphs: "+kruskal.TotalSubGraphs);
		}
		
		void showAgentPath(){
			treeViewCirclesConnections.Nodes.Clear();
			treeViewCirclesConnections.BeginUpdate();
			int i=0;
			int j;
			foreach(Agent actualAgent in this.agents){
				j = 0;
				treeViewCirclesConnections.Nodes.Add(actualAgent.ToString());
				foreach(Edge actualEdge in actualAgent.VisitedEdgesList){
					treeViewCirclesConnections.Nodes[i].Nodes.Add(actualEdge.ToString());
					j++;	
				}
				i++;
			}
			treeViewCirclesConnections.EndUpdate();
		}
		
		
		void drawExtras(){
			bmpExtraInfo.Dispose();
			this.bmpExtraInfo = new Bitmap(this.bmp);
			
			//ORDER OF THE DRAWINGS IS IMPORTANT
			//Shortest Pair of Circles BruteForce
			drawShortestPairVertex(this.bmpExtraInfo, shortestPairVertexBruteForce, Color.Orange, checkBoxShortestPairCircleBruteForce.Checked);
			//Shortest Pair of Circles DivideConquer
			drawShortestPairVertex(this.bmpExtraInfo, shortestPairVertexDivideConquer, Color.Chocolate, checkBoxShortestPairCircleDivideConquer.Checked);
			//Prim
			drawPrimArm(this.bmpExtraInfo);
			//Kruskal
			drawKruskalArm(this.bmpExtraInfo);
			//Lowest Edge
			drawLowestEdge(this.bmpExtraInfo);
			//Dijkstra
			drawDijkstra(this.bmpExtraInfo);
			//Leveled Graph
			drawLeveledGraph(bmpExtraInfo);
			
			pictureBox1.BackgroundImage = this.bmpExtraInfo;
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom ;
			pictureBox1.Image = this.bmpAnimation;
			
		}
		
				
		#endregion
		
		void ButtonKruskalSelectedEdgesOrderClick(object sender, EventArgs e){
			setListTreeView(kruskal.SelectedEdgesOrder);
		}
		void ButtonPrimSelectedEdgesOrderClick(object sender, EventArgs e){
			setListTreeView(prim.SelectedEdgesOrder);
		}
		
		void ButtonCreatePreyPredatorsClick(object sender, EventArgs e)
		{
			
		}
		void ButtonCreateAllNormalAgentsClick(object sender, EventArgs e)
		{	
			if(pictureBox1.Image == null ){
				MessageBox.Show("You must select an image");
				return;
			}
			if(circles == null ){
				MessageBox.Show("Click'FIND CIRCLES CENTERS'first.");
				return;
			}
			agents.Clear();
			int totalNormalAgents = (int)numericUpDownTotalNormalAgents.Value;
			Graph graphToUse;
			int moveAs;
			List<int> selectedItems = new List<int>();	
			//GRAPH
			if(radioButtonGraphKruskal.Checked)
				graphToUse = kruskal.ARM;
			else if(radioButtonGraphPrim.Checked){
				int selectedVertex = (int)comboBoxPrimInitVertex.SelectedItem - 1;
				getArmByPrim(this.graph.Vertices[selectedVertex]);
				drawExtras(); //Update prim visually
//				buttonPrimSelectedEdgesOrder.PerformClick();
				graphToUse = prim.ARM;
			}
			else
				graphToUse = graph;
			
			foreach(Vertex v in graphToUse.Vertices){
				selectedItems.Add(v.Id);
			}
			selectedItems.Sort();
			//MOVE
			if(radioButtonMoveDFS.Checked)
				moveAs = (int)Agent.MoveAs.DFS;
			else
				moveAs = (int)Agent.MoveAs.Random;
			
			//CREATE AGENTS
			if(!checkBoxNormalRandomVertex.Checked){
				DialogResult ok = DialogResult.Cancel;
				for(int i = 0; i < totalNormalAgents; i++){
					AddAgents addInitVertices = new AddAgents(selectedItems,selectedItems,i+1,(int)AddAgents.Type.Init_NoDestine);
					ok = addInitVertices.ShowDialog();
					if(ok == DialogResult.OK){
						agents.Add(new Agent(i,graphToUse.Vertices[addInitVertices.InitVertex-1],(int)numericUpDownNormalAgentSpeed.Value,random,(int)Agent.Type.Normal,moveAs));
						selectedItems.RemoveAt(selectedItems.BinarySearch(addInitVertices.InitVertex));
					}
					else break;
				}
				if(ok == DialogResult.Cancel) return;
			}
			else{
				createRandomAgents(graphToUse,totalNormalAgents,moveAs,(int)Agent.Type.Normal);
			}
			drawAgents(agents);
			buttonStartAllNormalAgents.Text = "Start";
			buttonStartAllNormalAgents.Enabled = true;
			buttonStartAllNormalAgents.BackColor = Color.CornflowerBlue;
			buttonStopAnimation.Enabled = true;
			buttonStopAnimation.BackColor = Color.IndianRed;
			this.agentAction = (int)AgentAction.NORMAL;
			this.graph.cleanElementsUsingEdges();
			
		}
		void ButtonStartAllNormalAgentsClick(object sender, EventArgs e)
		{
			buttonCreateAllNormalAgents.Enabled = false;
			buttonCreateAllNormalAgents.BackColor = Color.Gray;
			//Pause
			if(timerAgents.Enabled){
				buttonStartAllNormalAgents.Text = "||";
				timerAgents.Stop();
			}
			else{ //Restart
				buttonStartAllNormalAgents.Text = ">";
				timerAgents.Start();
			}
		}
		void RadioButtonGraphPrimCheckedChanged(object sender, EventArgs e)
		{
			if(radioButtonGraphPrim.Checked){
				checkBoxPrimArm.Checked = true;
				comboBoxPrimInitVertex.Enabled = true;
				labelPrimInitVertex.Enabled = true;
				radioButtonMoveDFS.Checked = true;
			}
			else{
				checkBoxPrimArm.Checked = false;
				comboBoxPrimInitVertex.Enabled = false;
				labelPrimInitVertex.Enabled = false;
			}
		}
		void RadioButtonGraphKruskalCheckedChanged(object sender, EventArgs e)
		{
			if(radioButtonGraphKruskal.Checked){
				checkBoxKruskalArm.Checked = true;
				radioButtonMoveDFS.Checked = true;
			}
			else
				checkBoxKruskalArm.Checked = false;
		}
		void ButtonStopAnimationClick(object sender, EventArgs e)
		{
			timerAgents.Stop();
			buttonCreateAllNormalAgents.Enabled = true;
			buttonCreateAllNormalAgents.BackColor = Color.LightSteelBlue;
			buttonStartAllNormalAgents.Enabled =false;
			buttonStartAllNormalAgents.BackColor = Color.Gray;
			
		}
		void ButtonCreatePredatorPreysClick(object sender, EventArgs e)
		{	
			if(pictureBox1.Image == null ){
				MessageBox.Show("Must select an image");
				return;
			}
			if(circles == null ){
				MessageBox.Show("First click 'FIND CIRCLES CENTERS' button.");
				return;
			}
			if(numericUpDownPreyPredatorSpeed.Value < 2 || numericUpDownPreyPredatorSpeed.Value > 30){
				MessageBox.Show("Invalid Speed");
				return;
			}
			if((int)numericUpDownTotalPreys.Value + (int)numericUpDownTotalPredators.Value > graph.Vertices.Count){
				MessageBox.Show("Preys + Predators > Total Vertices in graph");
				return;
			}
				
			//TODO validate if is same initVertex selected, so don't do it again
			checkBoxDijkstraPath.Enabled = true;
			
			agentAction = (int)AgentAction.PREY_PREDATOR;
			
			agents.Clear();
			int totalPreys = (int)numericUpDownTotalPreys.Value;
			List<int> selectedItems = new List<int>();	
			List<int> destines = new List<int>();
			
			foreach(Vertex v in graph.Vertices){
				selectedItems.Add(v.Id);
				destines.Add(v.Id);
			}
			selectedItems.Sort();
			
			//CREATE PREYS
			if(!checkBoxRandomPreys.Checked){
				DialogResult ok = DialogResult.Cancel;
				for(int i = 0; i < totalPreys; i++){
					AddAgents addInitVertices = new AddAgents(selectedItems,destines,i+1,(int)AddAgents.Type.Init_Destine);
					ok = addInitVertices.ShowDialog();
					if(ok == DialogResult.OK){
						if(!getDijkstra(graph.Vertices[addInitVertices.InitVertex-1], graph.Vertices[addInitVertices.DestineVertex-1])){
							i--;
							MessageBox.Show("No path for that pair of vertices, choose another");
						}
						else{
							checkBoxDijkstraPath.Checked = true;
							drawExtras();
							agents.Add(new Agent(dijkstra.DijkstraFinalPath,i,dijkstra.DijkstraGraph.Vertices[0],graph.Vertices[addInitVertices.DestineVertex-1],(int)numericUpDownPreyPredatorSpeed.Value,(int)Agent.Type.Prey,(int)Agent.MoveAs.Prey));
							selectedItems.RemoveAt(selectedItems.BinarySearch(addInitVertices.InitVertex));
						}
					}
					else break;
				}
				if(ok == DialogResult.Cancel) return;
			}
			else{
//				createRandomAgents(graphToUse,totalNormalAgents,moveAs,(int)Agent.Type.Normal);
			}
			createRandomPredators(selectedItems,(int)numericUpDownTotalPredators.Value);
			buttonStartPredatorPreys.Enabled = true;
			buttonStartPredatorPreys.BackColor = Color.CornflowerBlue;
			buttonStopAnimationPredatosPreys.Enabled = true;
			buttonStopAnimationPredatosPreys.BackColor = Color.IndianRed;
			this.agentAction = (int)AgentAction.PREY_PREDATOR;
					
			drawExtras(); //Update dijsktra visually
			//Create agents
			timerAgents.Stop();
			drawAgents(this.agents);
			buttonStartPredatorPreys.Enabled = true;
			buttonStartPredatorPreys.BackColor = Color.CornflowerBlue;
			buttonStopAnimationPredatosPreys.Enabled = true;
			buttonStopAnimationPredatosPreys.BackColor = Color.IndianRed;
			buttonStartPredatorPreys.Text = "Start";
			
		}
		void ButtonStartPredatorPreysClick(object sender, EventArgs e)
		{
			this.agentAction = (int)AgentAction.PREY_PREDATOR;
//			timerAgents.Start();
			buttonCreatePredatorPreys.Enabled = false;
			buttonCreatePredatorPreys.BackColor = Color.Gray;
			buttonEditCurrent.Enabled = false;
			//Pause
			if(timerAgents.Enabled){
				buttonStartPredatorPreys.Text = "||";
				timerAgents.Stop();
			}
			else{ //Restart
				buttonStartPredatorPreys.Text = ">";
				timerAgents.Start();
			}
			
		}
		void ButtonCalculateDijkstraClick(object sender, EventArgs e)
		{
			if(!getDijkstra(graph.Vertices[(int)comboBoxAgentStartVertex.SelectedItem-1], graph.Vertices[(int)comboBoxDestineVertex.SelectedItem-1])){
				MessageBox.Show("No path!");
				checkBoxDijkstraPath.Enabled = false;
				checkBoxDijkstraPath.Checked = false;
				drawExtras();
			}
			else{
				checkBoxDijkstraPath.Enabled = true;
				checkBoxDijkstraPath.Checked = true;
				drawExtras();
			}
		}
		void RadioButtonGraphTotalCheckedChanged(object sender, EventArgs e)
		{
			radioButtonMoveRandom.Checked = true;
		}
		void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
		{
			if(checkBoxSelectAll.Checked){
				checkBoxLowestEdge.Checked = true;
				checkBoxShortestPairCircleBruteForce.Checked = true;
				checkBoxShortestPairCircleDivideConquer.Checked = true;
				checkBoxKruskalArm.Checked = true;
				checkBoxPrimArm.Checked = true;
				if(checkBoxDijkstraPath.Enabled)
					checkBoxDijkstraPath.Checked = true;
				if(checkBoxLeveledGraph.Enabled)
					checkBoxLeveledGraph.Checked = true;
			}
			else{
				checkBoxLowestEdge.Checked = false;
				checkBoxShortestPairCircleBruteForce.Checked = false;
				checkBoxShortestPairCircleDivideConquer.Checked = false;
				checkBoxKruskalArm.Checked = false;
				checkBoxPrimArm.Checked = false;
				checkBoxDijkstraPath.Checked = false;
				checkBoxLeveledGraph.Checked = false;
			}
		}
		void ButtonEditCurrentClick(object sender, EventArgs e)
		{
			if(agents.Count == 0){
				MessageBox.Show("No agents to edit");
				return;
			}
//			if(numericUpDownTotalPredators.Value + agents.Count > graph.Vertices.Count){
//				MessageBox.Show("Preys + Predators > Total Vertices in graph");
//				return;
//			}
			List<Agent> newAgentsList = new List<Agent>();
			List<int> selectedItemsInit = new List<int>();
			List<int> inits = new List<int>();
			List<int> destines = new List<int>();
			foreach(Vertex v in graph.Vertices){
				selectedItemsInit.Add(v.Id);
				inits.Add(v.Id);
				destines.Add(v.Id);
			}
			selectedItemsInit.Sort();//TODO both sorts are unnecessary
			destines.Sort();
			DialogResult ok = DialogResult.Cancel;
			bool existPreys = false;
			for(int i = 0; i < agents.Count; i++){
				Agent a = agents[i];
				if((int)a.AgentType == (int)Agent.Type.Prey && (int)a.AgentIsNow != (int)Agent.AgentIs.Dead){
					existPreys = true;
					ok = DialogResult.Cancel;
					AddAgents addInitVertices = new AddAgents(a,inits,destines);
					ok = addInitVertices.ShowDialog();
					if(ok == DialogResult.OK){
						if(!getDijkstra(graph.Vertices[addInitVertices.InitVertex-1], graph.Vertices[addInitVertices.DestineVertex-1])){
							i--;
							MessageBox.Show("No path for that pair of vertices, choose another");
						}
						else{
							checkBoxDijkstraPath.Checked = true;
							drawExtras();
							newAgentsList.Add(new Agent(dijkstra.DijkstraFinalPath,i,dijkstra.DijkstraGraph.Vertices[0],graph.Vertices[addInitVertices.DestineVertex-1],(int)numericUpDownPreyPredatorSpeed.Value,(int)Agent.Type.Prey,(int)Agent.MoveAs.Prey));
							int index = selectedItemsInit.BinarySearch(addInitVertices.InitVertex);
							if(index >= 0)
								selectedItemsInit.RemoveAt(index);
						}
					}
					else if(ok == DialogResult.Abort){}//Ignore prey
					else break;
					
					if(ok == DialogResult.Cancel) return;
				}
			}
			if(!existPreys) MessageBox.Show("No preys to edit");
			if(ok != DialogResult.Cancel) {
				agents = newAgentsList;
				createRandomPredators(selectedItemsInit,(int)numericUpDownTotalPredators.Value);
			}
			drawAgents(agents);
			this.graph.cleanElementsUsingEdges();
			if(ok == DialogResult.OK && existPreys){
				buttonStartPredatorPreys.Text = "Start";
				buttonStartPredatorPreys.Enabled = true;
				buttonStartPredatorPreys.BackColor = Color.CornflowerBlue;
			}
		}
		void ButtonStopAnimationPredatosPreysClick(object sender, EventArgs e)
		{
//			timerAgents.Stop();
//			buttonCreatePreyPredators.Enabled = true;
//			buttonCreatePreyPredators.BackColor = Color.LightSteelBlue;
			
			timerAgents.Stop();
			buttonCreatePredatorPreys.Enabled = true;
			buttonCreatePredatorPreys.BackColor = Color.LightSteelBlue;
			buttonStartPredatorPreys.Enabled =false;
			buttonStartPredatorPreys.BackColor = Color.Gray;
			buttonEditCurrent.Enabled = true;
			this.graph.cleanElementsUsingEdges();
		}
		
		
		
						
		
		
		#region ENUMS
		public enum AgentAction{
			NORMAL,
			PREY_PREDATOR
		}
		
		#endregion
		
		#region PREYS
		
		
//		
		
		#endregion
		
		
				
		
	}
}
