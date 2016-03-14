using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class Player : MonoBehaviour
{
	public string displayName;

	[SerializeField]
	private Unit unitSelected;




	public void Update ()
	{
		getMouseInput ();
		
	}


	private void getMouseInput ()
	{
		
		if (Input.GetMouseButtonDown (0))
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
			{
				Vector3 worldPosition = this.transform.InverseTransformPoint (hit.point);
				var point = Sector.Map [worldPosition]; 
				if (Sector.Grid.Contains (point))
				{
					{
						leftClickAction (point);
					}

				}
			}
		}
	}


	private void leftClickAction (FlatHexPoint point)
	{
		if (Sector.Grid [point].unit != null)
			SelectUnit (Sector.Grid [point].unit);

		if (unitSelected != null && Sector.Grid [point].contents == Cell.Contents.empty)
			unitSelected.Move (Sector.Map [point]);
	}

	private void SelectUnit (Unit _unit)
	{
		unitSelected = _unit;
		BattleDisplay.BattleUI.unitDetails.Prime (_unit);
	}
}