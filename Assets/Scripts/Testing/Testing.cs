using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour
{
	public Fleet fleet;

	public FleetBuilderDisplay fleetBuilderDisplay;


	public List<Unit> buildableUnits;

	void Start ()
	{
		UnitDisplay.onClick += UnitDisplay_onClick;
		fleet.state.units.Clear ();

	}

	void OnDestroy ()
	{
		Debug.Log (" Unsigned-up for onClick");
		UnitDisplay.onClick -= UnitDisplay_onClick;
	}

	void UnitDisplay_onClick (Unit _template)
	{
		var unit = new UnitState (_template);
		unit.initalize ();
		fleet.AddUnit (unit);
		Debug.Log (unit.DisplayName + "Added to Fleet");

	}



	public void showBuildPanel ()
	{
		fleetBuilderDisplay = (FleetBuilderDisplay)Instantiate (fleetBuilderDisplay);

		foreach (var unit in buildableUnits)
		{
			unit.initalize ();
		}

		fleetBuilderDisplay.Prime (buildableUnits);
		
	}


	public void deployFeet ()
	{
		fleet.Deploy (Battle.Manager.getDeploymentArea (Sector.northSpawn, fleet.Size));

	}


	public void LoadBattle ()
	{
		SceneManager.LoadScene ("TestBattle");
	}
}
