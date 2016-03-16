using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour
{


	public FleetDisplay fleetListDisplay;

	public static  Testing testing;


	void Awake ()
	{
		testing = this;
	}


	public void showFleetPanel (FleetState fleet)
	{
		fleetListDisplay = (FleetDisplay)Instantiate (fleetListDisplay);

		fleetListDisplay.Prime (fleet);
		
	}


	public void deployFeet ()
	{
//		fleet.Deploy (Battle.Manager.getDeploymentArea (Sector.northSpawn, fleet.Size));

	}


	public void LoadBattle ()
	{
		SceneManager.LoadScene ("TestBattle");
	}




}
