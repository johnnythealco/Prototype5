using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetListDisplay : MonoBehaviour
{


	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;



	public void Prime (List<Unit> units)
	{
		foreach (var unit in units)
		{
			UnitDisplay display = (UnitDisplay)Instantiate (unitDisplayPrefab);
			display.transform.SetParent (targetTransform, false);
			display.Prime (unit);
			display.onClick += Display_onClick;
		}
	}

	void Display_onClick (Unit _unit)
	{
		
	}
}
