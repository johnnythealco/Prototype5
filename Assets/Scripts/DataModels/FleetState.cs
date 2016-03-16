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

	public delegate void FleetStateDelegate ();

	public event FleetStateDelegate onChanged;

	public FleetState ()
	{
		units = new List<UnitState> ();
	}

	public void AddUnit (UnitState _unit)
	{
		units.Add (_unit);
		if (onChanged != null)
			onChanged.Invoke ();
	}

	public void RemoveUnit (UnitState _unit)
	{
		units.Remove (_unit);
		if (onChanged != null)
			onChanged.Invoke ();
	}

		



	

}
