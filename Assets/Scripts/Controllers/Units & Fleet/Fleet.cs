using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Fleet : MonoBehaviour
{
	public Player owner;

	public FleetState state;

	public int Size { get { return state.units.Count (); } }

	void Awake ()
	{
		if (state == null)
			state = new FleetState ();
	}



	public void Deploy (List<Vector3> _position)
	{
		for (int i = 0; i < state.units.Count (); i++)
		{
			Unit unit = Instantiate (state.units [i].unitTemplate, _position [i], Quaternion.identity) as Unit;
			unit.state = state.units [i];
			Battle.Manager.registerAtPoint (_position [i], unit);
		}
	}




}
