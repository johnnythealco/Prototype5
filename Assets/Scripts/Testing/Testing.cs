using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


 
public class Testing : MonoBehaviour
{

	public static  Testing testing;


	public void LoadBattle ()
	{
		var fleets = new Dictionary<FleetState, int> ();
		int battleSectorSize = 16;
		string SectorName = "Wolf 359";
		Game.Manager.LoadBattle (fleets, battleSectorSize, SectorName);


	}
}