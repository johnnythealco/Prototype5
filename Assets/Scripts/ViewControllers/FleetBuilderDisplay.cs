﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetBuilderDisplay : MonoBehaviour {


	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;



	public void Prime(List<UnitController> units)
	{
		foreach( var unit in units)
		{
			UnitDisplay display = (UnitDisplay)Instantiate (unitDisplayPrefab);
			display.transform.SetParent (targetTransform, false);
			display.Prime (unit);
		}
	}
}
