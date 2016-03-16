using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour
{

	public static  Testing testing;
	public int sectorSize;
	public Sector BattleSectorPrefab;


	void Awake ()
	{
		testing = this;
	}


	public void LoadBattle ()
	{
		Game.Manager.battleState.BattleSector.size = sectorSize;
		SceneManager.LoadScene ("TestBattle");
	}

	public void CreateBattleState()
	{


	}




}
