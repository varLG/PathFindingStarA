using PathFinding;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GridSystem
{
	public class GridPoint : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
	{
		// For Grid System
		public bool isEmpty { get; private set; }
		public bool isSimulated { get; private set; }
		public int pointX { get; private set; }
		public int pointY { get; private set; }  

		Image imgGridPoint; 
		RectTransform rectTransform;


		// For PathFinding
		public int costG { get; private set; }
		public int costH { get; private set; }
		public int costF { get { return costG + costH; } }
		public GridPoint pointBefore { get; private set; }
		 

		// First constructor
		public void GridPointOptions(int _pointX, int _pointY)
		{
			isEmpty = true;

			pointX = _pointX;
			pointY = _pointY;

			imgGridPoint = GetComponent<Image>();
			rectTransform = GetComponent<RectTransform>();

			imgGridPoint.color = GridCreator.Instance.gridSet.colorEmpty;
			rectTransform.anchoredPosition = new Vector2(rectTransform.sizeDelta.x * pointX, rectTransform.sizeDelta.y * pointY);
		}

		// UI Control
		public void OnPointerEnter(PointerEventData eventData)
		{
			GridManager.SimulatePath(this);
		}
		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				ChangeState();
			}
			else if (eventData.button == PointerEventData.InputButton.Left)
			{
				SetPathPoint();
			}
		} 

		// Grid Controls
		void ChangeState()
		{
			if (isEmpty)
			{
				isEmpty = false;
				imgGridPoint.color = GridCreator.Instance.gridSet.colorFull;
			}
			else
			{
				isEmpty = true;
				imgGridPoint.color = GridCreator.Instance.gridSet.colorEmpty;
			} 
		}
		void SetPathPoint()
		{
			imgGridPoint.color = GridCreator.Instance.gridSet.colorPath;
			GridManager.SetPathPoint(this);
		}





		// Prop Set
		public void SetCostG(int _costG)
		{
			costG = _costG;
		} 
		public void SetCostH(int _costH)
		{
			costH= _costH;
		}
		public void SetPointBefore(GridPoint _gridPoint)
		{
			pointBefore = _gridPoint;
		} 
		public void SetEmptyValue(bool _value)
		{
			isEmpty = _value;
		} 
		public void SetSimulated()
		{
			isSimulated = true;
			imgGridPoint.color = GridCreator.Instance.gridSet.colorSimulated;
		}



		// Reset
		public void ResetState()
		{
			isEmpty = true;
			isSimulated = false;

			imgGridPoint.color = GridCreator.Instance.gridSet.colorEmpty; 
		}
		public void ResetSimulated()
		{
			if (isSimulated && isEmpty)
			{
				isSimulated = false;
				imgGridPoint.color = GridCreator.Instance.gridSet.colorEmpty;
			}
		}

	}
}