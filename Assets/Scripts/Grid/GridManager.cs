using PathFinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	public static class GridManager
	{
		public static GridPoint[,] gridPoints { get; private set; }

		static GridPoint pathStart;
		static GridPoint pathEnd;


		public static void SetGridPointsSize(int _sizeX, int _sizeY)
		{
			gridPoints = new GridPoint[_sizeX, _sizeY];
		}

		public static void SetGridPoint(GridPoint _gridPoint, int _posX, int _poxY)
		{
			gridPoints[_posX, _poxY] = _gridPoint;
		}

		public static void SetPathPoint(GridPoint _gridPoint)
		{
			if (pathStart == null)
			{
				pathStart = _gridPoint;
				pathStart.SetEmptyValue(false);
				return;
			}
			else
			{
				pathStart.ResetState();
				pathStart = _gridPoint;
				pathStart.SetEmptyValue(false);
				ResetSimulated();
			}
		}
		static public void SimulatePath(GridPoint _gridPoint)
		{
			if (pathStart == null)
				return;

			pathEnd = _gridPoint;
			CalculatePath();
		}
		static void CalculatePath()
		{
			List<GridPoint> path = FindPath.CalculatePath(pathStart, pathEnd);
			if (path != null)
			{
				ResetSimulated();

				foreach (var item in path)
				{
					item.SetSimulated();
				}
			}
			else
			{
				ResetSimulated();
				Debug.Log("Path not found! Points are reseted!");
			}
		}
		static void ResetSimulated()
		{
			foreach (var item in gridPoints)
			{
				item.ResetSimulated();
			}
		}
	}
}
