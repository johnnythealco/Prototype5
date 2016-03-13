using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Testing : MonoBehaviour
{
	public FleetController fleet;

	public FleetBuilderDisplay fleetBuilderDisplay;


	public List<UnitController> buildableUnits; 

	void Start () {
		UnitDisplay.onClick += UnitDisplay_onClick;
		fleet.fleet.Clear ();

	}

	void OnDestroy(){
		Debug.Log (" Unsigned-up for onClick");
		UnitDisplay.onClick -= UnitDisplay_onClick;
	}

	void UnitDisplay_onClick (UnitController _template)
	{
		var unit = new UnitState (_template);
		unit.initalize();
		fleet.AddUnit(unit);
		Debug.Log( unit.DisplayName +  "Added to Fleet");

	}



	public void showBuildPanel()
	{
		fleetBuilderDisplay = (FleetBuilderDisplay)Instantiate (fleetBuilderDisplay);

		foreach(var unit in buildableUnits)
		{
			unit.initalize ();
		}

		fleetBuilderDisplay.Prime (buildableUnits);
		
	}


	public void deployFeet ()
	{
		fleet.Deploy (Battle.Manager.getDeploymentArea(Sector.northSpawn, fleet.Size));

	}
}
