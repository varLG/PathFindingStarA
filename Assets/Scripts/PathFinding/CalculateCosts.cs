using GridSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding
{
	public static class CalculateCosts
	{
		static List<GridPoint> _listNeighbours = new List<GridPoint>();
		static int _pointX;
		static int _pointY;

		static int distanceX;
		static int distanceY;

		static int distanceMin;
		static int distanceMax;

		static int hValue;


		public static List<GridPoint> CalculateNeighbours(GridPoint _gridPoint)
		{
			_listNeighbours.Clear();
			_pointX = _gridPoint.pointX;
			_pointY = _gridPoint.pointY;

			//Check all ways

			if (_pointX > 0) // Left
			{
				_listNeighbours.Add(GridManager.gridPoints[(_pointX - 1), _pointY]);
			}

			if (_pointX < GridManager.gridPoints.GetLength(0) - 1) // Right
			{
				_listNeighbours.Add(GridManager.gridPoints[_pointX + 1, _pointY]);
			}

			if (_pointY > 0) // Down
			{
				_listNeighbours.Add(GridManager.gridPoints[_pointX, _pointY - 1]);
			}

			if (_pointY < GridManager.gridPoints.GetLength(1) - 1) // Up
			{
				_listNeighbours.Add(GridManager.gridPoints[_pointX, _pointY + 1]);
			}

			return _listNeighbours;
		}



		public static int CalculateCostH(GridPoint _pointA, GridPoint _pointB)
		{
			// H cost with between to two point

			distanceX = Mathf.Abs(_pointA.pointX - _pointB.pointX);
			distanceY = Mathf.Abs(_pointA.pointY - _pointB.pointY);

			distanceMin = Mathf.Min(distanceX, distanceY);
			distanceMax = Mathf.Max(distanceX, distanceY);

			hValue = (14 * distanceMin) + (distanceMax - distanceMin);

			return hValue;
		}
	}
}