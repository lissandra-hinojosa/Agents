/*
 * Created by SharpDevelop.
 * User: EliteBook
 * Date: 05/03/2019
 * Time: 08:40 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of Agent.
	/// </summary>
	public class Agent
	{
		List<Edge> dijsktraPath;
		
		int agentType; //Normal agent, predator, prey
		int movement; //Move as
		
		int id;
		Vertex initialVertex;
		Vertex destineVertex;
		Vertex actualVertex;
		Edge actualEdge;
		Edge comingEdge; //Same edge as actualEdge but for return
		int actualPos; //Actual position in actualEdge
		int agentSpeed;
		bool canMove; //If it has finished already to go through the graph
		int canMoveReason; //For preys
		bool firstMove;
		int agentIs;
		
		//Move Random
		List<Edge> visitedEdgesList; //Don't sort
		Random random;
		
		//Move in Arm
		Stack<Edge> visitedEdgesStack;
		List<Vertex> visitedVerticesList;
		
		//Move DFS
		Stack<Vertex> visitedVerticesStack;
		List<Edge> path;
		bool constantReturn;
		int returningPos;
		bool isPathCalculated; //When agent moves, prevents from recalculating path
		
		public enum Type{
			Normal,
			Predator,
			Prey
		}
		
		public enum MoveAs{
			Prey, //Established path, avoiding other elements within the edge
			DFS, 
			Random
		}
		
		public enum MovingState{
			Waiting,
			MovingForward,
			Returning,
			ChoosingEdge,
			Dead
		}
		
		public enum AgentIs{
			Moving,
			Finished,
			Dead
		}
		
		public string AgentInfo{
			get{return getAgentInfo();}
		}
		
		public string getAgentInfo(){
			string info;
			switch(agentType){
				case (int)Type.Normal:
					info = "Normal";
					break;
				case (int)Type.Predator:
					info = "Predator";
					break;
				case (int)Type.Prey:
					info = "Prey";
					break;
				default:
					info = "Normal";
					break;
			}
			info += " #"+id+"\n";
			info += " InitVertex: "+initialVertex.Id+"\n";
			switch(movement){
				case (int)MoveAs.DFS:
					info+=" Move: "+"DFS";
					break;
				case (int)MoveAs.Prey:
					info+=" Move: "+"Prey";
					break;
				case (int)MoveAs.Random:
					info+=" Move: "+"Random";
					break;
				default:
					break;
			}
			return info;
		}
		
		#region CONSTRUCTOR
		
		public Agent(List<Edge>path, int id, Vertex initialVertex,Vertex destineVertex, int speed, int type, int movement){
			dijsktraPath = new List<Edge>(path);
			this.agentType = type;
			this.movement = movement;
			this.id = id;
			this.initialVertex = initialVertex;
			this.destineVertex = destineVertex;
			this.actualVertex = initialVertex;
			actualPos = 0;
			this.canMove = true;
			this.canMoveReason = (int)AgentIs.Moving;
			this.firstMove = true;
			visitedEdgesList = new List<Edge>();
			this.agentSpeed = speed;
			this.random = new Random();
			this.visitedEdgesStack = new Stack<Edge>();
			this.visitedVerticesList = new List<Vertex>();
			
			this.visitedVerticesStack = new Stack<Vertex>();
			this.path = new List<Edge>();
			constantReturn = false;
			returningPos = -1;
			isPathCalculated = false;
		}
		
		public Agent(int id, Vertex initialVertex, int speed, Random random, int type, int movement){
			this.agentType = type;
			this.movement = movement;
			this.id = id;
			this.initialVertex = initialVertex;
			this.actualVertex = initialVertex;
			actualPos = 0;
			this.canMove = true;
			this.canMoveReason = (int)AgentIs.Moving;
			this.firstMove = true;
			visitedEdgesList = new List<Edge>();
			this.agentSpeed = speed;
			this.random = random;
			this.visitedEdgesStack = new Stack<Edge>();
			this.visitedVerticesList = new List<Vertex>();
			
			this.visitedVerticesStack = new Stack<Vertex>();
			this.path = new List<Edge>();
			constantReturn = false;
			returningPos = -1;
			isPathCalculated = false;
		}
		
		public Agent(int id, Vertex initialVertex, int speed, int type, int movement){
			this.agentType = type;
			this.movement = movement;
			this.id = id;
			this.initialVertex = initialVertex;
			this.actualVertex = initialVertex;
			actualPos = -1;
			this.canMove = true;
			this.canMoveReason = (int)AgentIs.Moving;
			this.firstMove = true;
			visitedEdgesList = new List<Edge>();
			this.agentSpeed = speed;
			this.random = new Random();
			this.visitedEdgesStack = new Stack<Edge>();
			
			this.visitedVerticesList = new List<Vertex>();
			this.visitedVerticesStack = new Stack<Vertex>();
			this.path = new List<Edge>();
			constantReturn = false;
			returningPos = -1;
			isPathCalculated = false;
		}
		#endregion
		
		#region GENERAL
		//Indicates if it can keep advancing in actualEdge
		bool advance(){
			if(actualVertex.Edges.Count == 0 ){
				canMove = false;
				agentIs = (int)AgentIs.Finished;
				return false;
			}
			if(ReferenceEquals(actualEdge.PixelsList,null)){ 
				canMove = false;
				agentIs = (int)AgentIs.Finished;
				return false;
			}
			if(actualPos+agentSpeed < actualEdge.PixelsList.Count){
				firstMove = false;
				actualPos+=agentSpeed;
				return true;
			}
			actualPos = 0;
			return false;
			
		}
		
		//Advace as prey. Avoids being on an edge when predators are using it
		int carefulAdvance(){
			bool predatorComing = isSomebodyComing();
			
			//Go back if there is a predator coming
			if(predatorComing){
				if( actualPos-agentSpeed > 0){
					actualPos-=agentSpeed;
					if(isSomebodyFollowing()) //Predator coming and following
						return (int)MovingState.Dead;
					return (int)MovingState.Returning; //Same as going forward
				}
				actualPos = 0; //Is in center
//				return (int)MovingState.Waiting;
			}
			//Look back before going out of house (Vertex)
			if(actualPos == 0 && (isSomebodyFollowing()|| predatorComing)){ //Safe in vertex
				return (int)MovingState.Waiting;
			}
			if(actualPos <= agentSpeed && isSomebodyFollowing()){ //Not safe in vertex yet
				if(predatorComing)
					return (int)MovingState.Dead;
				return (int)MovingState.MovingForward; //TODO Waiting?
			}
				
			//Move through edge
			if(actualPos+agentSpeed < actualEdge.PixelsList.Count && !predatorComing ){
				firstMove = false;
				actualPos+=agentSpeed;
				return (int)MovingState.MovingForward;
			}
			
			//Arrived to vertex, can't move in the actual edge
			if(!predatorComing){
				actualPos = 0;
				return (int)MovingState.ChoosingEdge;
			}
			return (int)MovingState.Waiting; //Can keep moving in actual edge
		}
		
								
		//If already inserted, don't reinsert. Comparison by Id
		void insertVisitedVertex(Vertex v, List<Vertex> list){
			var index = list.BinarySearch(v);
			if (index < 0) {
				index = ~index; //Bitwise Complement Operator
				list.Insert(index, v);
			}
		}
		#endregion
		
		#region GET_SET
		public Vertex InitVertex{
			get{ return this.initialVertex;}
			set{ this.initialVertex = value;}
		}
		
		public Vertex DestineVertex{
			get{ return this.destineVertex;}
			set{ this.destineVertex = value;}
		}
		
		public List<Edge> DijkstraPath{
			get{ return this.dijsktraPath;}
			set{ this.dijsktraPath = value;}
		}
		
		public int AgentType{
			get{ return this.agentType;}
			set{ this.agentType = value;}
		}
		
		public int AgentIsNow{
			get{ return this.agentIs;}
			set{ this.agentIs = value;}
		}
		
		public int MovementType{
			get{ return this.movement;}
			set{ this.movement = value;}
		}
		
		public int Id{
			get{return this.id;}
			set{this.id = value;}
		}
		
		public Vertex ActualVertex{
			get{ return this.actualVertex;}
			set{ this.actualVertex = value;}
		}
		
		public Edge ActualEdge{
			get{ return this.actualEdge;}
//			set{ this.actualEdge = value;}
		}
		
		public int ActualPosInt{
			get{return this.actualPos;}
		}
		
		public List<Edge> VisitedEdgesList{
			get{ return this.visitedEdgesList;}
			set{ this.visitedEdgesList = value;}
		}
		
		public bool CanMove{
			get{ return this.canMove;}
		}
		
		public Point getActualPoint(){
			if(agentType == (int)Type.Prey && (!canMove || firstMove)){ //End or start of animation
				switch(canMoveReason){
					case (int)AgentIs.Dead:
						return actualEdge.PixelsList[actualPos];
					case (int)AgentIs.Finished:
					case (int)AgentIs.Moving:
						return actualVertex.Node.Center;
				}
			}
			if(!canMove || firstMove) //End or start of animation
				return actualVertex.Node.Center;
			return actualEdge.PixelsList[actualPos];
		}
		
		#endregion
		
		//Just for preys
		public int move(List<Edge> list){
			switch(movement){
				case (int)MoveAs.Prey:
					return moveAsPrey(list);
				default:
					agentIs = (int)AgentIs.Finished;
					return (int)AgentIs.Finished;
			}
		}
		
		public bool move(Graph g){
			switch(movement){
				case (int)MoveAs.DFS:
					return moveByDFS(actualVertex,g);
				case (int)MoveAs.Random:
					return moveRandom(g);
				default:
					return moveRandom(g);
			}
		}
		
		#region MOVE AS PREY
		int moveAsPrey(List<Edge> listPath){
//			if(!canMove) return (int)AgentIs.Finished;
			if(!canMove) return canMoveReason;
			if(!isPathCalculated) {
				this.path = new List<Edge>(listPath);
				isPathCalculated = true;
				//Set first edge
				nextPathActualEdge();
			}
			if(ReferenceEquals(actualEdge,null))return (int)AgentIs.Finished;
			//Move
			switch(carefulAdvance()){
				case (int)MovingState.ChoosingEdge:
					if(!nextPathActualEdge()){
						agentIs = (int)AgentIs.Finished;
						canMoveReason = (int)AgentIs.Finished;
						canMove = false;
						return (int)AgentIs.Finished;
					}
					break;
				case (int)MovingState.Dead:
					agentIs = (int)AgentIs.Dead;
					canMoveReason = (int)AgentIs.Dead;
					canMove = false;
					return (int)AgentIs.Dead;
				default:
					agentIs = (int)AgentIs.Moving;
					canMoveReason = (int)AgentIs.Moving;
					canMove = true;
					return (int)AgentIs.Moving;;
			}
			agentIs = (int)AgentIs.Moving;
			return (int)AgentIs.Moving;
//			if (!carefulAdvance() && !nextPathActualEdge()) //If can't advance, then nextPathActualEdge
//				canMove = false;
//			return canMove;
		}
				
		#endregion
				
		#region DFS
		
		//Moves after getting path
		bool moveByDFS(Vertex v,Graph g){
			if(!canMove) return false;
			//Calculate DFS path, first call
			if(!isPathCalculated) {
				DFS(v,g);
				isPathCalculated = true;
				//Set first edge
				nextPathActualEdge();
			}
			//Move
			if (!advance() && !nextPathActualEdge()) //If can't advance, then nextPathActualEdge
				canMove = false;
			return canMove;
		}
		
		
		void DFS(Vertex v, Graph g){
			actualVertex = v;
			visitedVerticesStack.Push(actualVertex);
			insertVisitedVertex(actualVertex, visitedVerticesList);
			DFS(visitedVerticesStack,visitedVerticesList);
			if(constantReturn) path.RemoveRange(returningPos,path.Count-returningPos); //To prevent going back in Not-Connected graph
		}
		
		void DFS(Stack<Vertex> verticesStack, List<Vertex> verticesList){
			if(verticesStack.Count > 0){
				actualVertex = verticesStack.Peek();
				foreach(Edge e in actualVertex.Edges){
					if(verticesList.BinarySearch(e.Destination) < 0){ //Not visited destination
						constantReturn = false; //Path may still grow
						verticesStack.Push(e.Destination);
						insertVisitedVertex(e.Destination,verticesList);
						// Edge to advance
						visitedEdgesStack.Push(e); //
						path.Add(e); // 
						DFS(verticesStack,verticesList); //Next Edge
					}
				}
				//Return in edge
				if(verticesStack.Count > 0 && visitedEdgesStack.Count > 0){
					if(!constantReturn){ //First warning
						constantReturn = true;
						returningPos = path.Count;
					}				
					verticesStack.Pop();
					Edge edge = visitedEdgesStack.Pop(); //Need reversed version
					//TODO nasty linear search to get reference of reverse version of poped edge 
					foreach(Edge reversed in edge.Destination.Edges){
						if(reversed == edge){
							this.path.Add(reversed);
							break;
						}
							
					}
					//TODO finished nasty
//					this.path.Add(reversedEdge); 
				}
			}
		}
		
		#endregion
				
		#region ARM
		
//		DFS DEPTH FIRST SEARCH
//		public bool moveAgentDFS(Graph graph){
//			if(!canMove) return false;
//			//FIRST MOVE
//			if(firstMove){ //Start moving
//				insertVisitedVertex(actualVertex,visitedVerticesList); //Insert sorted for first time
//				if(!nextEdgeDFS(graph)){
//					canMove = false;
//					return false;
//				}
//				advance();
//				return true;
//			}
//			//Already started moving
//			if(!advance()){ //Next edge or finished moving
//				this.actualVertex = actualEdge.Destination; //Update next actual Vertex
//				insertVisitedVertex(actualVertex,visitedVerticesList); //Insert sorted vertex
//				if(!nextEdgeDFS(graph)){
//					canMove = false;
//					return false; //FINISHED MOVING
//				}
//			}
//			return true;
//		}
//		
//				
//		//Adds newEdge and updates actualPos
//		bool nextEdgeDFS(Graph graph){
//			if(visitedVerticesList.Count == graph.Vertices.Count) return false;//Detiene a grafos conexos, no a los no conexos
//			//Next Edge from actualVertex 
//			foreach(Edge e in actualVertex.Edges){
//				if(visitedVerticesList.BinarySearch(e.Destination) < 0){ //Not visited destination
//					setActualEdge(e);
////				this.actualEdge = e; 
//					this.visitedEdgesList.Add(actualEdge); //Create path
//					this.visitedEdgesStack.Push(actualEdge);//Help to return
//					return true;
//				}
//			}
//			//Actual vertex has no more options, Return
//			if(visitedEdgesStack.Count > 0 ){ //Can return
//				actualEdge = visitedEdgesStack.Pop(); //TODO update to setActualEdge()
//				actualEdge = new Edge(actualEdge.Destination, actualEdge.Origin, actualEdge.Weight, actualEdge.PixelsList);//TODO update to setActualEdge()
//				actualVertex = actualEdge.Destination;
//				this.visitedEdgesList.Add(actualEdge); //Create path when returning
//				return true;
//			}
//			return false;//No more edges to chose
//			
//		}
		
		
		#endregion
		
				
		#region MOVE_RANDOM
		bool moveRandom(Graph graph){
			if(!canMove) return false;
			if(firstMove){ //Start moving
				if(!nextEdgeRandom(graph)) return false;
				advance();
				return true;
			}
			advance();
			if(actualPos == 0){
				actualVertex = actualEdge.Destination;
				this.visitedEdgesList.Add(this.actualEdge);
				if(!nextEdgeRandom(graph)) return false;
			}
			return true;
		}
		
		
		
		//Must return and edge always, if not, is finished
		bool nextEdgeRandom(Graph graph){
			Edge newEdge;
			int totalEdges = 0;
			bool foundEdge = false;
			int randomEdge;
			List<int> randomEdges = new List<int>();
			while(!foundEdge){
				if(totalEdges == actualVertex.Edges.Count)
					break;
				randomEdge = randomNumber(0,actualVertex.Edges.Count);
				if(!randomEdges.Contains(randomEdge)){
					randomEdges.Add(randomEdge);
					totalEdges++;
				}
				newEdge = actualVertex.Edges[randomEdge];
				if(!isVisitedEdge(newEdge)){
					setActualEdge(newEdge);
//					actualEdge = newEdge;
					return true;
				}
			}
			canMove = false;
			return false;
		}
		#endregion
		
		#region GENERAL
		
		//Uses the List of Edges to follow a path previously generated
		bool nextPathActualEdge(){
			if(!ReferenceEquals(actualEdge,null)) // if there is a previous
				actualVertex = actualEdge.Destination; //Update new actual Vertex
			if(path.Count != 0){
				freeEdgeSpace();
//				visitedEdgesList.Add(actualEdge);
				setActualEdge(path[0]);
				useEdgeSpace();
				path.RemoveAt(0);
				return true;
			}
			freeEdgeSpace();
			return false;
		}
		
		//Manteinance to elements using the edge. Preys are not detected in edges
		void setActualEdge(Edge e){
//			freeEdgeSpace();
			//New edge
			actualEdge = e;
//			useEdgeSpace();
			comingEdge = getComingEdge();
		}
		
		void useEdgeSpace(){
			if(movement != (int)MoveAs.Prey)actualEdge.incrementElementsUsingEdge();
		}
		
		void freeEdgeSpace(){
			if(!ReferenceEquals(actualEdge,null) && movement != (int)MoveAs.Prey ){ //Preys don't count as elements using edges
				actualEdge.decrementElementsUsingEdge(); //Leaving edge
			}
		}
		
		//Searches the same as the actualEdge but for returning
		Edge getComingEdge(){
			if(ReferenceEquals(actualEdge,null))return null;
			Vertex destination = actualEdge.Destination;
			foreach(Edge e in destination.Edges){
				if(actualEdge == e){ //Same edge back and forward
					return e;
				}
			}
			return null;
		}
		
		bool isSomebodyComing(){
			if(!ReferenceEquals(comingEdge,null))
				return comingEdge.ElementsUsingEdge > 0;
			return false;
		}
		
		//TODO Notice that it CAN be the own element which is following if ElementsUsingEdge == 1
		bool isSomebodyFollowing(){
			if(!ReferenceEquals(actualEdge,null))
				return actualEdge.ElementsUsingEdge > 0;
			return false;
		}
		
		int randomNumber(int init, int final){
			return (int)this.random.Next(init, final);
		}
		
		
		bool isVisitedEdge(Edge e){
			if(visitedEdgesList == null) return false;
			for(int i=0; i < visitedEdgesList.Count; i++){
				if(visitedEdgesList[i] == e)
					return true;
			}
			return false;
		}
		

		public static bool operator == (Agent a1, Agent a2){
			if(a1.id == a2.id )
				return true;
			return false;
		}
		
		public static bool operator != (Agent a1, Agent a2){
			if(a1.id == a2.id )
				return false;
			return true;
		}
		
		public override string ToString()
		{
			string info;
			switch(agentType){
				case (int)Type.Normal:
					info = "Normal";
					break;
				case (int)Type.Predator:
					info = "Predator";
					break;
				case (int)Type.Prey:
					info = "Prey";
					break;
				default:
					info = "Normal";
					break;
			}
			return string.Format("Agent #{0} - {1}", id, info);
		}
		
		#endregion
	}
}
