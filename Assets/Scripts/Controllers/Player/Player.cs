using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

/*
 *Class representing the Player
 *Only one instance of this class should exist per player
 *There should be one for each player in a multiplayer gaem
 */

public class Player : MonoBehaviour
{
	public string displayName;

	public FleetState fleet;

	public Unit unitSelected;

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
	}



	public void SelectUnit (Unit _unit)
	{
		unitSelected = _unit;
	}
}