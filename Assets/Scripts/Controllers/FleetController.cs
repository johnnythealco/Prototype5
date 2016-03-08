using UnityEngine;
using System.Collections;

public class FleetController : MonoBehaviour
{
	public Player owner;

	public UnitController[] fleet;

	[SerializeField]
	private FleetState fleetState;

	public FleetState FleetState
	{ 		get		{ 			return fleetState;		}	}

	public void initalize()
	{
		fleetState = new FleetState (fleet);


	}



}
