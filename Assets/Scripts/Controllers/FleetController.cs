using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FleetController : MonoBehaviour
{
	public Player owner;

	public List<UnitController> fleet;

	public int Size {get{return fleet.Count ();}}

	[SerializeField]
	private FleetState fleetState;

	public FleetState FleetState
	{ 		get		{ 			return fleetState;		}	}

	public void initalize()
	{
		fleetState = new FleetState (fleet);


	}

	public void Deploy(List<Vector3> _position)
	{
		for (int i = 0; i < fleet.Count (); i++)
		{
			UnitController unit = Instantiate (fleet[i], _position[i], Quaternion.identity) as UnitController;
			unit.state = fleet [i].state;
			Battle.Manager.registerAtPoint (_position [i], unit);
	

		}
	}



}
