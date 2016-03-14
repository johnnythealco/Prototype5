using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour
{
	Fleet fleet;

	public FleetListDisplay fleetBuilderDisplay;
	public FleetListDisplay fleetListDisplay;



	public List<Unit> buildableUnits;

	void Start ()
	{
		UnitDisplay.onClick += UnitDisplay_onClick;



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
		fleetBuilderDisplay = (FleetListDisplay)Instantiate (fleetBuilderDisplay);

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


	public void CreateFleet()
	{
		GameObject _obj = new GameObject ("Fleet");
		fleet = _obj.AddComponent<Fleet> ();
	}
}
