using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	public class GridCreator : GenericSingleton<GridCreator>
	{
		[Header("Grid Options")]
		public GridSet gridSet;
		[SerializeField] RectTransform gridSystemParent;

		[Header("Grid Size")]
		[SerializeField] int gridSizeX;
		[SerializeField] int gridSizeY;


		GameObject createdObject;
		GridPoint createdGridPoint;
		int gridPointTransformSize;
		private void Start()
		{
			CreateGrid(gridSizeX, gridSizeY);
		}

		void CreateGrid(int _gridSizeX, int _gridSizeY)
		{
			GridManager.SetGridPointsSize(_gridSizeX, _gridSizeY);

			gridPointTransformSize = ((int)gridSet.goGridPoint.GetComponent<RectTransform>().sizeDelta.x);

			gridSystemParent.sizeDelta = new Vector2(_gridSizeX * gridPointTransformSize, _gridSizeY * gridPointTransformSize);

			for (int x = 0; x < _gridSizeX; x++)
			{
				for (int y = 0; y < _gridSizeY; y++)
				{
					createdObject = Instantiate(gridSet.goGridPoint, gridSystemParent);
					createdObject.name = "Point [" + x + "," + y + "]";

					createdGridPoint = createdObject.GetComponent<GridPoint>();
					createdGridPoint.GridPointOptions(x, y);


					GridManager.SetGridPoint(createdGridPoint, x, y);
				}
			}
		}
	}
}
