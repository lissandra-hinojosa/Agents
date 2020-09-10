/*
 * Created by SharpDevelop.
 * User: EliteBook
 * Date: 28/01/2019
 * Time: 07:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace p01_HinojosaAcosta
{
	/// <summary>
	/// Description of Circle.
	/// </summary>
	public class Circle
	{
		int id;
		Point center;
		int radius;
		
		public Circle( int id, int centerX, int centerY, int radius){
			this.id = id;
			this.center.X = centerX;
			this.center.Y = centerY;
			this.radius = radius;
		}
		
		public Circle( int id, Point center, int radius){
			this.id = id;
			this.center = center;
			this.radius = radius;
			
		}
		public int Radius{
			get{ return this.radius;}
			set{ this.radius = value; }
		}
		
		public int Id{
			get{ return this.id;}
			set{ this.id = value; }
		}
		
		public Point Center{
			get{return this.center;}
			set{this.center = value;}
		}
		
		public override string ToString()
		{
			return string.Format("#{0} Center: ({1},{2}) r: {3}", id, center.X, center.Y, radius);
		}
		
				
		public static bool operator == (Circle c1, Circle c2){
			if(c1.Center == c2.Center )
				return true;
			return false;
		}
		
		public static bool operator != (Circle c1, Circle c2){
			if(c1.Center != c2.Center )
				return true;
			return false;
		}
		
		
	}
}
