/*
 * Created by SharpDevelop.
 * User: EliteBook
 * Date: 18/02/2019
 * Time: 08:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	/// 
	#region GRAPH
	public class Graph
	{
		List<Vertex> vertices;
		double totalWeight; //Total graph weight
		List<Edge> edgesList;
		Stopwatch timerBruteForce;
		int totalBruteForceTime;
		Stopwatch timerDivideConquer;
		int totalDivideConquerTime;
		
		public Graph(){
			this.vertices = new List<Vertex>();
			this.totalWeight = 0;
			this.edgesList = new List<Edge>();
			timerBruteForce = new Stopwatch();
			timerDivideConquer = new Stopwatch();
			totalBruteForceTime = 0;
			totalDivideConquerTime = 0;
		}
		public List<Vertex> Vertices{
			get{return this.vertices;}
			//set{this.vertices = value;}
		}
		
		public long TimerBruteForce{
//			get{return timerBruteForce;}
			get{return timerBruteForce.ElapsedMilliseconds;}
		}
		
		public long TimerDivideConquer{
			get{return timerDivideConquer.ElapsedMilliseconds;}
		}
		
		public int TotalBruteForceTime{
//			get{return timerBruteForce;}
			get{return totalBruteForceTime;}
		}
		
		public long TotalDivideConquerTime{
			get{return totalDivideConquerTime;}
		}

		
		public void addVertex(int id, Circle node){
			Vertex vertex = new Vertex(id,node);
			vertices.Add(vertex);
		}
		
		public void addNewVertex(Vertex v){
			Vertex newV = new Vertex(v.Id, v.Node);
			vertices.Add(newV);
		}
		
		public void addVertex(Vertex v){
			vertices.Add(v);
		}
		
		public int findVertexIndex(Vertex v){
			for(int i=0; i< Vertices.Count; i++){
				if(Vertices[i] == v)
					return i;
			}
			return -1;
		}
		
		public double TotalWeight{
			get{return getTotalDirectedWeight();}
		}
		
		public List<Edge> LeveledPath{
			get{return edgesList;}
		}
		
		
		//Divide between 2 because is directed graph
		double getTotalDirectedWeight(){
			this.totalWeight = 0;
			foreach(Vertex v in this.vertices){
				this.totalWeight += v.TotalWeight;
			}
			return this.totalWeight/2;
		}
		
		public void cleanElementsUsingEdges(){
			foreach(Vertex v in vertices){
				foreach(Edge e in v.Edges){
					e.ElementsUsingEdge = 0;
				}
			}
		}
		
		
		#region Shortest BruteForce
		public Edge getShortestPairVertexBruteForce(){
			timerBruteForce.Start();
			Edge result = new Edge();
			Vertex initialVertex, endVertex;
			int distance = 0;
			int actualDistance;
			if(this.Vertices.Count < 2 )
				return null;
			for(int i=0; i<this.Vertices.Count; i++){
				initialVertex = this.Vertices[i];
				for(int j=i+1; j<this.Vertices.Count; j++){
					endVertex = this.Vertices[j];
					actualDistance = getPointsDistance(initialVertex,endVertex);
					if(i==0 && j==1){
						result.Origin = initialVertex;
						result.Destination = endVertex;
						distance = actualDistance;		
					}
					else if( actualDistance < distance){
						result.Origin = initialVertex;
						result.Destination = endVertex;
						distance = actualDistance;
					}
				}
			}
			result.Weight = distance;
			timerBruteForce.Stop();
			return result;
		}
		
		int getPointsDistance(Vertex init, Vertex final){
//			System.Threading.Thread.Sleep(1);
			if(timerBruteForce.IsRunning) totalBruteForceTime++;
			else if(timerDivideConquer.IsRunning) totalDivideConquerTime++;
			Point initialPoint = init.Node.Center;
			Point finalPoint = final.Node.Center;
			return (int)Math.Sqrt( Math.Abs( ((finalPoint.X-initialPoint.X)*(finalPoint.X-initialPoint.X))+(finalPoint.Y-initialPoint.Y)*(finalPoint.Y-initialPoint.Y) ) );
		}
		
		public Edge getLowestEdgeBruteForce(){
			int j;
			int i=0;
			double lowestWeight;
			Edge lowestEdge;
			if(this.Vertices.Count == 0)
				return null;
			else if(this.Vertices[0].Edges.Count == 0)
				return null;
			else{
				lowestEdge = this.Vertices[0].Edges[0];
				lowestWeight = lowestEdge.Weight;
			}
			foreach(Vertex actualVertex in this.Vertices){ //REPEATES CHECK IN FIRST EDGE OF FIRST NODE!!!!!!
				j=0;
				foreach(Edge actualEdge in this.Vertices[i].Edges){
					if(actualEdge.Weight < lowestWeight){
						lowestEdge = actualEdge;
						lowestWeight = actualEdge.Weight;
					}
					j++;	
				}
				i++;
			}
			return lowestEdge; 
		}
		
		#endregion
		
		#region Shortest DivideConquer
		
		public Edge getShortestPairVertexDivideConquer(){
			timerDivideConquer.Start();
			Edge edge = new Edge();
			List<Vertex> initList = new List<Vertex>();
			initList = Vertices.OrderBy(p => p.Node.Center.X).ToList();
//			delayStopwatch();
			edge = divideAndConquer(initList);
			timerDivideConquer.Stop();
			return edge;
		}
		
		public Edge divideAndConquer(List<Vertex> vertices){
			if(vertices.Count <= 4){
				if(vertices.Count < 2)
					return null;
				return shortestPairBruteForce(vertices);
			}
			int middle = (vertices.Count) / 2;
			Edge left = divideAndConquer(vertices.GetRange(0,middle));
			Edge right = divideAndConquer(vertices.GetRange(middle+1, vertices.Count-middle-1));
			Edge edgeMin = minEdge(left,right);
			//Get range of vertices to compare between sets
			List<Vertex> listY = new List<Vertex>();
			for(int i = 0; i < vertices.Count; i++){
				if(Math.Abs(vertices[i].Node.Center.X-vertices[middle].Node.Center.X) < edgeMin.Weight){
					listY.Add(vertices[i]);
				}
			}
			
			listY = listY.OrderBy(p=> p.Node.Center.Y).ToList();
			int auxDistance;
			//Check distances between subsets
			for(int i = 0; i < listY.Count-1; i++){
				for(int j = i+1; j < listY.Count; j++){
					if(Math.Abs(listY[i].Node.Center.Y - listY[j].Node.Center.Y) < edgeMin.Weight){
						auxDistance = getPointsDistance(listY[i],listY[j]);
						if(auxDistance < edgeMin.Weight){
							edgeMin.Origin = listY[i];
							edgeMin.Destination = listY[j];
							edgeMin.Weight = auxDistance;
						}
					}
				}
			}
			if(ReferenceEquals(edgeMin,null))return null;
			return edgeMin;
		}
		
		Edge minEdge(Edge e1, Edge e2){
			return (e1.Weight <= e2.Weight)? e1 : e2;
		}
		
		Edge shortestPairBruteForce(List<Vertex> vL){  
			int min = int.MaxValue; //TODO Could cause problems??
			int auxDistance;
			Edge result = new Edge();
			for (int i = 0; i < vL.Count; ++i){
		    	for (int j = i+1; j < vL.Count; ++j){
		    		auxDistance = getPointsDistance(vL[i],vL[j]);
				    if (auxDistance < min){
				    	min = auxDistance;  
				    	result.Origin = vL[i];
				    	result.Destination = vL[j];
				    	result.Weight = min;
				    }
		    	}    
			}
		    return result;  
		}
		
		int min(int x, int y){
			return (x < y)? x: y;
		}
		
		#endregion
		
		#region BFS
		
		/*
		public bool BFS(Vertex init){
			Queue<Vertex> vertexQueue = new Queue<Vertex>();
			List<Vertex> visitedVertexList =  new List<Vertex>();
			vertexQueue.Enqueue(init);
			visitedVertexList.Add(init);
			List<Edge> edgesList = new List<Edge>();
			bool addedKidLast = true;
			bool addedKidActual = true;
			int brothers = 1;
			int brothersCounter = 0;
			int sons = 0;
			bool firstRow = true;
			int accumSons = 0;
			
			while(vertexQueue.Count > 0){
				sons = 0;
				addedKidActual = false;
				Vertex actualV = vertexQueue.Dequeue();
				foreach(Edge e in actualV.Edges){
					if(visitedVertexList.BinarySearch(e.Destination) < 0){ //Not visited
						sons++;
						addedKidActual = true;
						insertVisitedVertex(e.Destination,visitedVertexList);
						vertexQueue.Enqueue(e.Destination);
						edgesList.Add(e);
					}
				}
				
				//Compare between brothers
				if(!firstRow && (addedKidLast != addedKidActual)){
					return false;
				}
				if(firstRow) firstRow = false;
				if(brothersCounter+1 == brothers){
					accumSons +=
				}
				brothersCounter++;
				if(brothersCounter == brothers){
					firstRow = true;
					brothersCounter = 0;
					brothers = accumSons+sons;
					accumSons = 0;
				}else{
					accumSons += sons;
				}
				
				addedKidLast = addedKidActual;
			}
			return true;
		}
		*/
		
		public bool BFS(Vertex initVertex){
			if(initVertex.Edges.Count == 0) return true;
			bool finalResult = true;
			edgesList.Clear();
			Queue<Vertex> verticesQueue = new Queue<Vertex>();
			Queue<int> verticesLevel = new Queue<int>();
			List<Vertex> visitedVertices = new List<Vertex>();
			verticesQueue.Enqueue(initVertex);
			int lastLevel = 1;
			int actualLevel;
			verticesLevel.Enqueue(lastLevel);
			insertVisitedVertex(initVertex, visitedVertices);
			bool lastHadSons = true;
			bool actualHasSons;
			int fatherBrothers = 0;
			while(verticesQueue.Count > 0){
				actualHasSons = false;
				Vertex actualVertex = verticesQueue.Dequeue();
				actualLevel = verticesLevel.Dequeue(); //Level of actual vertex
				foreach(Edge e in actualVertex.Edges){
					if(visitedVertices.BinarySearch(e.Destination) < 0){ //If not visited
						insertVisitedVertex(e.Destination, visitedVertices);
						verticesQueue.Enqueue(e.Destination);
						verticesLevel.Enqueue(actualLevel+1); //Level of its son
						edgesList.Add(e);
						actualHasSons = true;
					}
				}
				if(lastLevel == actualLevel){ //Same level, previous and actual are brothers
					fatherBrothers++;
					if(actualHasSons != lastHadSons && actualLevel != 1 ){ //Not the first
						finalResult = false;
						break;
					}
				}
				else{
					lastLevel = actualLevel; //Change level below. THIS iteration is the first element in the level.
					/**/
					//At this point we already know that is the FIRST one in the level.
					//If has more than 1 brother and there are no more vertices in the queue to consider -> Not leveled graph
					if( fatherBrothers > 1 && verticesQueue.Count == 0 ){ //If father has just one brother, can cotinue checking.
						finalResult = false;
						break;
					}
					fatherBrothers = 1;
					/**/
				}
				lastHadSons = actualHasSons;
			}
			
			return finalResult;
		}
		
		public void recursiveBFS(Vertex init){
			
			Queue<Vertex> vertexQueue = new Queue<Vertex>();
			List<Vertex> visitedVertexList =  new List<Vertex>();
			vertexQueue.Enqueue(init);
			visitedVertexList.Add(init);
			List<Edge> edgesList = new List<Edge>();
			BFS(vertexQueue,visitedVertexList, edgesList,1,1);
		}
		
		
		bool BFS(Queue<Vertex> queue, List<Vertex> visitedList, List<Edge> edgesList,int brothers, int passedBrothers){ //Brothers from actual vertex
			
			int sons = 0;
			//Make Sons
			if(queue.Count > 0){
				Vertex actualV = queue.Dequeue();
				passedBrothers--;
				foreach(Edge e in actualV.Edges){
					//SONS OF ACTUALV
					if(visitedList.BinarySearch(e.Destination) < 0){ //Not visited
						sons++;
						insertVisitedVertex(e.Destination,visitedList);
						queue.Enqueue(e.Destination);
						edgesList.Add(e);
					}
				}
				//End make sons
//				edgesList.Concat(BFS(queue,visitedList,edgesList));// TODO Check
				//Brother
				bool brotherSon;
				if(passedBrothers == 0) brotherSon = BFS(queue,visitedList,edgesList,sons,sons);
				else brotherSon = BFS(queue,visitedList,edgesList, brothers, passedBrothers);// TODO Check
//				if(brothers){
//				}
				
				brothers--;
				if(brothers > 0){ //We are brothers. Check if I had children too
					
				}

			}
			//
			return sons>0; //Actual vertex says - Tuve # hijos
			
//			return sons; //Actual vertex says - Tuve # hijos
//			return edgesList;
			
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
		
	}
	#endregion
	
	#region VERTEX
	public class Vertex: IComparable<Vertex>{
		int id;
		Circle node;
		List<Edge> edges;
		double totalWeight;//Weight
		
		public Vertex(int id, Circle node){
			this.id = id;
			this.node = node;
			this.edges = new List<Edge>();
			this.totalWeight = 0; //Edges total weight;
		}

		#region IComparable implementation
		public int CompareTo(Vertex other)
		{
			return this.Id.CompareTo(other.Id);
		}
		#endregion		
		public int Id{
			get{return this.id;}
			set{this.id = value;}
		}
		
		public Circle Node{
			get{return this.node;}
			set{this.node = value;}
		}
		
		public List<Edge> Edges{
			get{return this.edges;}
		}
		
		public double TotalWeight{
			get{return totalWeight;}
			set{this.totalWeight = value;}
		}
		
//		double getTotalWeight(){
//			this.totalWeight = 0;
//			foreach(Edge e in this.edges){
//				this.totalWeight += e.Weight;
//			}
//			return this.totalWeight;
//		}
		
		public void addNewEdge(Edge e){
			Edge newEdge = new Edge(e.Origin,e.Destination,e.Weight,e.PixelsList);
			edges.Add(newEdge);
			this.totalWeight += e.Weight;
		}
		
		public void addEdge(Edge e){
			edges.Add(e);
			this.totalWeight += e.Weight;
		}
		
		public void addEdge(Vertex origin, Vertex destination, double weight, List<Point> pixelsList){
			Edge edge = new Edge(origin,destination,weight,pixelsList);
			edges.Add(edge);
			this.totalWeight += weight;
		}
		
		public int searchEdgePos(Edge e){
			for(int i=0; i < edges.Count-1; i++){
				if(edges[i] == e)
					return i;
			}
			return -1;
		}
		
		public static bool operator == (Vertex v1, Vertex v2){ //TODO: Compare edges list to be completely equal
			if(v1.Node == v2.Node )
				return true;
			return false;
		}
		
		public static bool operator != (Vertex v1, Vertex v2){ //TODO: Compare edges list to be completely equal
			if(v1.Node == v2.Node )
				return false;
			return true;
		}
		
		public override string ToString()
		{
			return string.Format("#{0}, Vertex[ {1} ]", id, Node.ToString() );
		}
		
		
	}
	#endregion
	

	#region EDGE
	public class Edge: IComparable<Edge>{
		Vertex origin;
		Vertex destination;
		double weight;
		List<Point> pixelsList;
		int elementsUsingEdge;

		
		public Edge(){ //Ist es richtig?
			this.origin = null;
			this.destination = null;
			this.weight = 0;
			this.pixelsList = new List<Point>();
			elementsUsingEdge = 0;
		}	
	
		public Edge(Vertex origin, Vertex destination, double weight, List<Point> pixelsList ){
			this.origin = origin;
			this.destination = destination;
			this.weight = weight;
			this.pixelsList = reverseList(pixelsList);
			elementsUsingEdge = 0;
		}
		
		public int CompareTo(Edge other){
			//COMPARISON 1
			int val = this.Weight.CompareTo(other.Weight);
////			Get Id's
//			if(val == 0){
//				int thisLowerId, thisMaxId;
//				if(this.Origin.Id < this.Destination.Id){
//					thisMaxId = this.Destination.Id;
//					thisLowerId = Origin.Id;
//				}
//				else{
//					thisMaxId = Origin.Id;
//					thisLowerId = Destination.Id;
//				}
//				
//				int otherLowerId, otherMaxId;
//				if(other.Origin.Id < other.Destination.Id){
//					otherMaxId = other.Destination.Id;
//					otherLowerId = other.Origin.Id;
//				}
//				else{
//					otherMaxId = other.Origin.Id;
//					otherLowerId = other.Destination.Id;
//				}
//				
//				//COMPARISON 3
//				if(thisLowerId == otherLowerId){
//					val = thisMaxId.CompareTo(otherMaxId);
//				}
//				else
//					val = thisLowerId.CompareTo(otherLowerId);
//			}
			return val;
		}
			
		List<Point> reverseList(List<Point> pixels ){
			if( origin.Node.Center != pixels[0] ){ //If original Point is not equal to pixels point
				var reversed = new List<Point>(pixels);
				reversed.Reverse();
				return reversed;
			}
			return pixels;
		}
		
						
		public double Weight{
			get{return this.weight;}
			set{this.weight = value;}
		}
		
		public Vertex Origin{
			get{return this.origin;}
			set{this.origin = value;}
		}
		
		public Vertex Destination{
			get{return this.destination;}
			set{this.destination = value;}
		}
		
		public List<Point> PixelsList{
			get{return this.pixelsList;} //TODO is efficient?
			set{this.pixelsList = value;}
		}
		
		public string Id{
			get{return this.origin.Id.ToString()+" - "+this.destination.Id.ToString();}
		}
		
		public int ElementsUsingEdge{
			get{return this.elementsUsingEdge;} 
			set{this.elementsUsingEdge = value;}
		}
		
		public void incrementElementsUsingEdge(){
			this.elementsUsingEdge++;
		}
		
		public void decrementElementsUsingEdge(){
			this.elementsUsingEdge--;
		}
		
		public Edge newReversedEdge(){
			Edge newEdge = new Edge(this.Destination,this.Origin,this.Weight,this.reverseList(this.pixelsList));
			return newEdge;
		}
		
		public override string ToString(){
			return string.Format("#{0}-{1} : {2}", this.origin.Id.ToString(),this.destination.Id.ToString(),this.weight);
		}
		
		
		public static bool operator ==(Edge e1, Edge e2){
			if(e1.Origin == e2.Origin)
				if(e1.Destination == e2.Destination)
					return true;
			
			if(e1.Origin == e2.Destination)
				if(e1.Destination == e2.Origin)
					return true;
			return false;
		}
		
		public static bool operator !=(Edge e1, Edge e2){
			if(e1.origin == e2.origin)
				if(e1.destination == e2.destination)
					if(e1.weight == e2.weight )
						return false;
			return true;
		}
	}
	#endregion
}
