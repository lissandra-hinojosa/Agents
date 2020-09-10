/*
 * Created by SharpDevelop.
 * User: HIV1GA
 * Date: 24/03/2019
 * Time: 02:24 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of Kruskal.
	/// </summary>
	public class Kruskal
	{	
		Graph arm;
		double weight;
		List<Edge> candidates;
		List<RelatedComponent> relatedComponents;
		List<Edge> promising; //When finished, has result
		
		
		public Kruskal(Graph graph){
			this.arm = new Graph();
			this.weight = 0;
			this.relatedComponents = new List<RelatedComponent>();
			this.candidates = new List<Edge>();
			this.promising = new List<Edge>();
			initCandidates(graph);
			getARM(graph);
			
		}
		
		public Graph ARM{
			get{return arm;}
		}
		public bool IsConnected{
			get{return relatedComponents.Count != 1;}
		}
		
		public int TotalSubGraphs{
			get{ return relatedComponents.Count;}
		}
		
		public List<Edge> SelectedEdgesOrder{
			get{return promising;}
		}
		
		void getARM(Graph graph){
			while(candidates.Count > 0){ //End if candidates is 0
				if(promising.Count == graph.Vertices.Count-1) break; //End if edges is equal to number of vertices -1
				Edge selectedEdge = selectEdge();
				bool originFound = false;
				bool destineFound = false;
				int posComponentO = 0;
				int posComponentD = 0;
				int posComponentListO = -1;
				int posComponentListD = -1;
				int i = 0;
				//TODO
				foreach(RelatedComponent component in relatedComponents){
					if(!originFound){
						posComponentO = component.isInComponent(selectedEdge.Origin);
						if(posComponentO >= 0){ //if found
							posComponentListO = i;
							originFound = true;
						}
					}
					if(!destineFound){
						posComponentD = component.isInComponent(selectedEdge.Destination);
						if(posComponentD >= 0){ //if Found
							posComponentListD = i;
							destineFound = true;
						}
					}
					if(originFound && destineFound)break;
					i++;
				}
				
				//If is different component
				if(posComponentListO != posComponentListD){
					promising.Add(selectedEdge); //CANDIDATE ACCEPTED
					//Pass destine component to origin component
					relatedComponents[posComponentListO].glueComponent(relatedComponents[posComponentListD]);
					relatedComponents.RemoveAt(posComponentListD);//Destine component is void, so delete
				}
				
			}
			setARM(graph);
			
		}
		
		//TODO improve
		//From promising list, set the arm
		void setARM(Graph graph){
			foreach(Vertex v in graph.Vertices){
				Vertex vertex = new Vertex(v.Id,v.Node);
				this.arm.addVertex(vertex);
			}
			foreach(Edge e in promising){
				this.weight += e.Weight;
				int indexOrigin = this.arm.findVertexIndex(e.Origin);
				int indexDestination = this.arm.findVertexIndex(e.Destination);
				this.arm.Vertices[indexOrigin].addEdge(this.arm.Vertices[indexOrigin],this.arm.Vertices[indexDestination],e.Weight,e.PixelsList);
				this.arm.Vertices[indexDestination].addEdge(this.arm.Vertices[indexDestination],this.arm.Vertices[indexOrigin],e.Weight,e.PixelsList);
			}
		
		}
		
		Edge selectEdge(){
			if(candidates.Count == 0)return null;
			Edge selectedEdge = candidates[0];
			candidates.RemoveAt(0); //Origin-Destine
//			candidates.RemoveAt(0); //Destine-Origin
			return selectedEdge;
		}
		
		//Returns sorted list 
		void initCandidates(Graph graph){
			foreach(Vertex v in graph.Vertices){
				//Related Components
				RelatedComponent rc = new RelatedComponent();
				rc.addToComponent(v);
				relatedComponents.Add(rc);
				//Candidates
				foreach(Edge e in v.Edges){
					if(!isCandidate(candidates,e)){
						var index = candidates.BinarySearch(e);
						if (index < 0) //Not found weight
							index = ~index; //Bitwise Complement Operator
						candidates.Insert(index, e);
					}
				}
			}
		}
		
		bool isCandidate(List<Edge> list, Edge candidate){
			foreach(Edge e in list){
				if(e == candidate) return true;
			}
			return false;
		}
		
		
	}
	
	
	
	
	public class RelatedComponent{
		List<Vertex> component; //Sorted list by Id
		
		public RelatedComponent(){
			this.component = new List<Vertex>();
		}
		
		public int BinarySearch(Vertex v){
			return component.BinarySearch(v);
		}
		
		public List<Vertex> Component{
			get{return this.component;}
		}
		
		public int isInComponent(Vertex vertex){
			return component.BinarySearch(vertex);
		}
		
				
		public void addToComponent(Vertex v){
			var index = component.BinarySearch(v);
			if (index < 0) index = ~index; //Bitwise Complement Operator
			component.Insert(index, v);
		}
		
		public void glueComponent(RelatedComponent component2){
			foreach(Vertex v in component2.Component){
				addToComponent(v);
			}
		}
		
		void removeComponentElement(Vertex v){
			var index = component.BinarySearch(v);
			if(index >= 0) component.RemoveAt(index);
		}
		
		public void removeComponent(){
			component.Clear();
		}
		
	}
	
}
