/*
 * Created by SharpDevelop.
 * User: HIV1GA
 * Date: 27/04/2019
 * Time: 10:17 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of Dijkstra.
	/// VERTICES LIST FROM GRAPH MUST BE SORTED
	/// </summary>
	public class Dijkstra
	{
		Graph dijkstraGraph;
		List<Edge> dijkstraFinalPath;
		List<Vertex> dijkstraPath;
		Vertex origin;
		Vertex destination;
		
		List<DijkstraElement> dijkstraElements;
		int unvisitedVertices;
		bool isPath;
		
		public Dijkstra(Vertex origin, Vertex destination, Graph graph)
		{
			dijkstraGraph = new Graph();
			dijkstraFinalPath = new List<Edge>();
			this.origin = origin;
			this.destination = destination;
			dijkstraElements = new List<DijkstraElement>();
			unvisitedVertices = graph.Vertices.Count;
			dijkstraPath = new List<Vertex>();
			isPath = false;
			dijkstra(graph);
			generateGraph(graph);
			generatePath(graph);
		}
		
		public Graph DijkstraGraph{
			get{
				if(isPath) return dijkstraGraph;
				return null;
			}
		}
		
		public List<Edge> DijkstraFinalPath{
			get{
				if(isPath) return dijkstraFinalPath;
				return null;
			}
		}
		
		public bool IsPath{
			get{return isPath;}
		}
		
		void dijkstra(Graph graph){
			initDijkstra(graph);
			DijkstraElement actual = dijkstraElements[origin.Id-1];
			while(unvisitedVertices > 0 && actual != null){
				updateDistances(actual.Vertex);
				//Get next actual
				actual = getShortestElement();
			}
			
			//TODO What is it with the not conected graphs
			
		}
		
//		void generatePath(Graph g){
//			Vertex actual = destination;
//			Vertex prev = dijkstraElements[actual.Id-1].ComingFrom;
//			dijkstraPath.Insert(0,actual);
//			while(actual != origin){
//				dijkstraPath.Insert(0,prev);
//				actual = prev;
//				prev =  dijkstraElements[actual.Id-1].ComingFrom;
//			}
//		}
		
		
		////GENERATES A >NEW< GRAPH FOR THE PATH. Does not make reference to graph
		void generateGraph(Graph g){
			Vertex actual = destination; //Destination
			Vertex prev = dijkstraElements[actual.Id-1].ComingFrom; //One previous from destination
			dijkstraGraph.addNewVertex(actual);
			
			while(actual != origin && !ReferenceEquals(prev,null)){ //Could be null if there is no path
				dijkstraGraph.addNewVertex(prev);
				//Back and forth edges A->B & B<-A
				dijkstraGraph.Vertices[dijkstraGraph.Vertices.Count-2].addNewEdge(findEdge(actual,prev)); //Element before last
				dijkstraGraph.Vertices[dijkstraGraph.Vertices.Count-1].addNewEdge(findEdge(prev,actual));// Last Element (Prev)
				actual = prev;
				prev =  dijkstraElements[actual.Id-1].ComingFrom;
			}
			//IF PATH Exist
			if(actual == origin){
				isPath = true;
				dijkstraGraph.Vertices.Reverse(); //For better understanding
			}
				
		}
		
		//RETURNS A LIST OF EDGES TO FOLLOW. Reference to graph
		void generatePath(Graph g){
			dijkstraFinalPath.Clear();
			Vertex actual = destination; //Destination
			Vertex prev = dijkstraElements[actual.Id-1].ComingFrom; //One previous from destination
						
			while(actual != origin && !ReferenceEquals(prev,null)){ //Could be null if there is no path
				dijkstraFinalPath.Add(findEdge(prev,actual)); //Remember that we are going backwards
				actual = prev;
				prev =  dijkstraElements[actual.Id-1].ComingFrom;
			}
			//IF PATH Exist
			if(actual == origin){
				isPath = true;
				dijkstraFinalPath.Reverse(); //For better understanding
			}
				
		}
		
//		Vertex findVertex(Vertex vertex, Graph g){
//			foreach(Vertex v in g.Vertices){
//				if(v == vertex)
//					return v;
//			}
//			return null;
//		}
		
		Edge findEdge(Vertex from, Vertex to){
			foreach(Edge e in from.Edges){
				if(e.Destination == to)
					return e;
			}
			return null;
		}
		
		//Not using priority Queue
		DijkstraElement getShortestElement(){
			double shortestDistance = double.PositiveInfinity;
			DijkstraElement shortestElement = null;
			foreach(DijkstraElement d in dijkstraElements){
				if(!d.IsDefinitive){
					if(d.ShortestDistance < shortestDistance ){
						shortestElement = d;
						shortestDistance = d.ShortestDistance;
					}
				}
			}
			if(shortestElement != null)
				shortestElement.IsDefinitive = true;
			unvisitedVertices--;
			return shortestElement;
		}
		
		void updateDistances(Vertex actual){
			double newValue;
			DijkstraElement startVertex = dijkstraElements[actual.Id-1]; //DijkstraElement of startVertex
			DijkstraElement nextVertex;
			foreach(Edge e in actual.Edges){
				nextVertex = dijkstraElements[e.Destination.Id-1];
				if(!nextVertex.IsDefinitive){ //If not definitive: Update weights
					newValue = startVertex.ShortestDistance + e.Weight;
					if( newValue < nextVertex.ShortestDistance ){ //Update
						nextVertex.ShortestDistance = newValue;
						nextVertex.ComingFrom = actual;
					}
				}
			}
		}
		
		
		
		//Sets initial vertex with propper info
		void initDijkstra(Graph graph){
			foreach(Vertex v in graph.Vertices){
				DijkstraElement element = new DijkstraElement(v);
//				ShortestElement sE = new ShortestElement(element);
				//Initial
				if(v == origin){
					element.ShortestDistance = 0;
					element.IsDefinitive = true;
				}
				dijkstraElements.Add(element);
			}
			unvisitedVertices = dijkstraElements.Count - 1; //-1 Start Vertex
		}
		
//		void insertSorted(ShortestElement sE){
//			var index = shortestList.BinarySearch(sE);
//			if (index < 0) //Not found weight
//				index = ~index; //Bitwise Complement Operator
//			shortestList.Insert(index, sE);
//		}
	}
	
	
//	//TODO Delete all related to this
//	public class ShortestElement: IComparable<ShortestElement>{
//		
//		DijkstraElement element;
//		
//		public ShortestElement(DijkstraElement e){
//			element = e;
//		}
//
//		public int CompareTo(ShortestElement other){
//			return this.element.ShortestDistance.CompareTo(other.element.ShortestDistance);
//		}
//
//	}
	
	public class DijkstraElement: IComparable<DijkstraElement>{
		Vertex vertex;
		double shortestDistance;
		bool isDefinitive;
		Vertex comingFrom;
				
		public DijkstraElement(Vertex v){
			vertex = v;
			shortestDistance = double.PositiveInfinity;
			isDefinitive = false;
			comingFrom = null;
		}
		
		public int CompareTo(DijkstraElement other)
		{
			return this.shortestDistance.CompareTo(other.shortestDistance);
//			return this.vertex.Id.CompareTo(other.vertex.Id);
//			throw new NotImplementedException();
		}
			
		public Vertex Vertex{
			get{return vertex;}
			set{vertex = value;}
		}
		
		public double ShortestDistance{
			get{return shortestDistance;}
			set{shortestDistance =  value;}
		}
		
		public bool IsDefinitive{
			get{return isDefinitive;}
			set{ isDefinitive = value;}
		}
		
		public Vertex ComingFrom{
			get{return comingFrom;}
			set{ comingFrom = value;}
		}
	}
}
