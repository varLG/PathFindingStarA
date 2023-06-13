using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding
{
	public static class ReturnPath
	{
		static List<GridPoint> ListFinalizePath = new List<GridPoint>();
		static GridPoint currentNode;
		public static List<GridPoint> GetFinalizePath(GridPoint _pointA, GridPoint _pointB)
		{
			// Last Point going to "before" variables inside and adding the list.

			ListFinalizePath.Clear();

			currentNode = _pointB;

			while (currentNode != _pointA) //Döngü ilk pointe ulaþana kadar sürsün.
			{
				ListFinalizePath.Add(currentNode);
				currentNode = currentNode.pointBefore;
			}

			ListFinalizePath.Reverse();
			return ListFinalizePath;
		}
	}
}