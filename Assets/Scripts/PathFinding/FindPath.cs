using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding
{
	public static class FindPath
	{
		static GridPoint startPoint;
		static GridPoint targetPoint;

		static List<GridPoint> openSet = new List<GridPoint>();
		static List<GridPoint> closedSet = new List<GridPoint>();

		static GridPoint currentPoint;
		static int newCostNeighbour;
		public static List<GridPoint> CalculatePath(GridPoint _pointStart, GridPoint _pointTarget)
		{
			startPoint = _pointStart;
			targetPoint = _pointTarget;
			 
			openSet.Clear();
			closedSet.Clear();

			openSet.Add(startPoint);

			while (openSet.Count > 0) // Continue loop with openSet items.
			{
				currentPoint = openSet[0];

				for (int i = 1; i < openSet.Count; i++) //Continue with lowest cost in openSet. If it has equal, continue with lower costH item.
				{
					if (openSet[i].costF < currentPoint.costF
						|| (openSet[i].costF == currentPoint.costF
						&& openSet[i].costH < currentPoint.costH))
					{
						currentPoint = openSet[i];
					}
				}

				openSet.Remove(currentPoint);
				closedSet.Add(currentPoint);

				if (currentPoint == targetPoint) // If has reached to target, complete loop.
				{
					return ReturnPath.GetFinalizePath(startPoint, targetPoint);
				}

				foreach (GridPoint neighbour in CalculateCosts.CalculateNeighbours(currentPoint)) // Calculating neighbours costs and overriding.
				{
					if (!neighbour.isEmpty || closedSet.Contains(neighbour)) // If cant be used or in closedSet, it will be move on
					{
						continue;
					}

					newCostNeighbour = currentPoint.costG + CalculateCosts.CalculateCostH(currentPoint, neighbour); 


					// Save the lowest cost in neighbours and continue to loop
					if (newCostNeighbour < neighbour.costG || !openSet.Contains(neighbour))
					{
						neighbour.SetCostG(newCostNeighbour);
						neighbour.SetCostH(CalculateCosts.CalculateCostH(neighbour, targetPoint));
						neighbour.SetPointBefore(currentPoint);

						if (!openSet.Contains(neighbour))
						{
							openSet.Add(neighbour);
						}
					}
				}
			}

			return null;
		}

	}
}