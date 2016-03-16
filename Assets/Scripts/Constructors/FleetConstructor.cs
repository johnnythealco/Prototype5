using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FleetConstructor : MonoBehaviour
{

	public UnitListDisplay fleetConstructorDisplay;
	[SerializeField]
	private Fleet activeFleet;
	public List<Unit> buildableUnits;

	void Start ()
	{
		showBuildPanel ();	
	}

	void OnDestroy ()
	{
		Debug.Log (" Unsigned-up for onListItemClick");
		fleetConstructorDisplay.onListItemClick -= FleetConstructorDisplay_onListItemClick;
	}

	void FleetConstructorDisplay_onListItemClick (UnitState _unit)
	{
		if (activeFleet != null)
		{
			var unit = new UnitState (_unit.unitTemplate);
			unit.initalize ();
			activeFleet.state.AddUnit (unit);
			Debug.Log (unit.DisplayName + "Added to Fleet");
		}
	}


	public void CreateFleet ()
	{
		GameObject _obj = new GameObject ("Fleet");
		activeFleet = _obj.AddComponent<Fleet> ();

		Testing.testing.showFleetPanel (activeFleet.state);

	}


	public void showBuildPanel ()
	{

		foreach (var unit in buildableUnits)
		{
			unit.initalize ();
		}

		fleetConstructorDisplay.Prime (buildableUnits);

		fleetConstructorDisplay.onListItemClick += FleetConstructorDisplay_onListItemClick;

	}

}
