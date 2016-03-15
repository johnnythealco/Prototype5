using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour
{
	Fleet fleet;

	public UnitListDisplay fleetListDisplay;

	public static  Testing testing;


	void Awake()
	{
		testing = this;
	}


	public void showFleetPanel ()
	{
		fleetListDisplay = (UnitListDisplay)Instantiate (fleetListDisplay);


		
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
