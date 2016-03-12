using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FleetController : MonoBehaviour
{
	public Player owner;

	public List<UnitState> fleet;

	public int Size {get{return fleet.Count ();}}



	public void Deploy(List<Vector3> _position)
	{
		for (int i = 0; i < fleet.Count (); i++)
		{
			UnitController unit = Instantiate (fleet[i].unitTemplate, _position[i], Quaternion.identity) as UnitController;
			unit.state = fleet [i];
			Battle.Manager.registerAtPoint (_position [i], unit);
	

		}
	}

	public void AddUnit(UnitState _unit)
	{
		fleet.Add (_unit);

	}

	public void RemoveUnit(UnitState _unit)
	{
		fleet.Remove (_unit);
	}


}
