using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class Player : MonoBehaviour
{
	public string displayName;

	private FleetState fleet;

	public Unit unitSelected;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}



	public void SelectUnit (Unit _unit)
	{
		unitSelected = _unit;
//		BattleDisplay.BattleUI.unitDetails.Prime (_unit);
	}
}