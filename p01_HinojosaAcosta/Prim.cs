/*
 * Created by SharpDevelop.
 * User: HIV1GA
 * Date: 24/03/2019
 * Time: 10:45 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace p01_HinojosaAcosta
{
	public class Prim
	{
		Graph arm;
		Vertex initVertex;
		List<Edge> candidates;
		List<Edge> promising; //When finished, has result
		List<Vertex> visited;
		
		//Maintenance for not connected graphs
		bool isConnected;
		List<int> subGraphs; //Saves id of start of subgraphs
		
		public Prim(Graph graph, Vertex initVertex){
			this.arm = new Graph();
			this.initVertex = initVertex;
			this.candidates = new List<Edge>();
			this.promising = new List<Edge>();
			this.visited = new List<Vertex>();
			this.subGraphs = new List<int>();
			this.isConnected = getArm(graph,initVertex);
			//Take care of islands
			while(!isConnected){
				this.isConnected = getArm(graph, newInitVertex(graph));
			}
			setARM(graph);
		}
		
		public Graph ARM{
			get{return arm;}
		}
		
		public Vertex InitVetex{
			get{return this.initVertex;}
		}
		
		public int TotalSubGraphs{
			get{ return subGraphs.Count;}
		}
		
		public List<Edge> SelectedEdgesOrder{
			get{return promising;}
		}
		
		bool getArm(Graph graph, Vertex initVertex){
			addVertexCandidates(initVertex);
			insertVisitedVertex(initVertex);
			while(this.candidates.Count > 0){
				if(this.promising.Count == graph.Vertices.Count-1) break; //Solution for prim
				Edge selectedEdge = selectEdge();
				if(feasible(selectedEdge)){ //If it does not generate cycles
					this.promising.Add(selectedEdge);
				}
			}
			this.subGraphs.Add(initVertex.Id);//If graph is "NO CONEXO", this will be > 1
			if(isArmComplete(graph)) return true;//GRAFO CONEXO
			return false; // NO CONEXO, FALTAN ISLAS
		}
		
		
		bool isArmComplete(Graph graph){
			//An ARM is complete if its egdes is equal to the number of vertices-1 PER GRAPH
			//In two different graphs(islands) this applies as well on each of them, then is vertices-2
			//3 graphs -> Each graph -1
			return promising.Count == graph.Vertices.Count - subGraphs.Count;
		}
		
		//Returns sorted list 
		void addVertexCandidates(Vertex initVertex){
			foreach(Edge e in initVertex.Edges)
				insertSortedEdge(this.candidates, e);
		}
		
		//Entry list is already sorted
		Edge selectEdge(){
			if(this.candidates.Count == 0)return null;
			Edge selectedEdge = candidates[0];
			candidates.RemoveAt(0);
			return selectedEdge;
		}
		
		//If both vertices are on visited, is not factible candidate
		bool feasible(Edge addedEdge){
			Vertex originV = addedEdge.Origin;
			bool isOrigin = false;
			bool isDestine = false;
			if(this.visited.BinarySearch(addedEdge.Origin) >= 0) isOrigin = true;
			if(this.visited.BinarySearch(addedEdge.Destination) >= 0) isDestine = true;
			if(isOrigin && isDestine) return false; // Not factible candidate
			if(isOrigin){ //Add destine
				insertVisitedVertex(addedEdge.Destination);
				addVertexCandidates(addedEdge.Destination);//Update Candidates
			}
			if(isDestine){ //Add origin
				insertVisitedVertex(addedEdge.Origin);
				addVertexCandidates(addedEdge.Origin); //Update Candidates
			}
			return true;
		}
		
		void insertVisitedVertex(Vertex v){
			var index = visited.BinarySearch(v);
			if (index < 0) index = ~index; //Bitwise Complement Operator
			this.visited.Insert(index, v);
		}
		
		void insertSortedEdge(List<Edge> list, Edge element){
			var index = list.BinarySearch(element);
			if (index < 0) index = ~index; //Bitwise Complement Operator
			list.Insert(index, element);
		}
		
		//TODO improve
		//From promising list, set the arm
		void setARM(Graph graph){
			foreach(Vertex v in graph.Vertices){
				Vertex vertex = new Vertex(v.Id,v.Node);
				this.arm.addVertex(vertex);
			}
			foreach(Edge e in promising){
				int indexOrigin = this.arm.findVertexIndex(e.Origin);
				int indexDestination = this.arm.findVertexIndex(e.Destination);
				this.arm.Vertices[indexOrigin].addEdge(this.arm.Vertices[indexOrigin],this.arm.Vertices[indexDestination],e.Weight,e.PixelsList);
				this.arm.Vertices[indexDestination].addEdge(this.arm.Vertices[indexDestination],this.arm.Vertices[indexOrigin],e.Weight,e.PixelsList);
			}
		
		}
		
		Vertex newInitVertex(Graph graph){
			foreach(Vertex v in graph.Vertices){
				if(this.visited.BinarySearch(v) < 0)
					return v;
			}
			return null;
		}
	}
}
