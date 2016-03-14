using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class FleetState : System.Object
{
//	private Player owner;

//	public Player Owner { get { return owner;}} 
	public List<UnitState> units;

	public int Size	{ get { return units.Count; } }

//	public FleetState(List<Unit> _units )
//	{
//		units = new List<UnitState> ();
//		foreach(var unit in _units)
//		{
//
//			units.Add (unit.state);
//		}
//	}




	

}
