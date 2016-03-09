using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour
{
	public FleetController testFleet;

	public static Testing Test;


	void Awake ()
	{
		Test = this;
	}


	void Update ()
	{
	
	}


	public void createFleet ()
	{
		testFleet.Deploy (Battle.Manager.getDeploymentArea (Sector.northSpawn, testFleet.Size));
	}
}
