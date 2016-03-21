using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


 
public class Testing : MonoBehaviour
{

	public static  Testing testing;

	public void SaveBattleState()
	{
		Game.Manager.SaveBattleState ();
	}


	public void LoadBattle ()
	{
		var fleets = new Dictionary<FleetState, int> ();
		fleets.Add (Game.Manager.player.fleet, 0);
		int battleSectorSize = 16;
		string SectorName = "Wolf 359";
		Game.Manager.LoadBattle (fleets, battleSectorSize, SectorName);


	}
}