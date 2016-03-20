using UnityEngine;
using System.Collections;
using Gamelogic.Grids;
using Gamelogic;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;



public class Battle : GridBehaviour<FlatHexPoint>
{

	public static Battle Manager;
	public BattleState state;
	public static int sectorSize;
	public Fleet fleet1;



	void Awake ()
	{
		if (Manager == null)
			Manager = this;
		else if (Manager != this)
			Destroy (gameObject);    


		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

		if(Game.Manager.BattleLoadState != null)
			state = Game.Manager.BattleLoadState;
		else
			Debug.Log("No BattleState Loaded!");
//			SceneManager.LoadScene ("Galaxy");


	}

	void Start()
	{

	}


	public void registerAtPoint (Vector3 point, Unit unit)
	{
		var _point = Sector.Map [point];
		Sector.Grid [_point].contents = BattleCell.Contents.unit;
		Sector.Grid [_point].unit = unit;
		Sector.Grid [_point].isAccessible = false;
			
	}

	public void unRegisterAtPoint (Vector3 point, Unit unit)
	{
		var _point = Sector.Map [point];
		Sector.Grid [_point].contents = BattleCell.Contents.empty; 
		Sector.Grid [_point].unit = null;
		Sector.Grid [_point].isAccessible = true;

	}

	public List<Vector3> getDeploymentArea (FlatHexPoint point, int radius)
	{
		List<Vector3> result = new List<Vector3> ();
		var area = Algorithms.GetPointsInRange<BattleCell, FlatHexPoint>
			(Sector.Grid, point,
			           JKCell => JKCell.isAccessible,
			           (p, q) => 1,
			           radius
		           );
	
	
		foreach (var _point in area)
		{
			result.Add (Sector.Map [_point]);
		}
		return result;
	}

//	void CreateSector()
//	{
//		if (Game.Manager.battleState.BattleSector != null)
//			sectorSize = Game.Manager.battleState.BattleSector.size;
//
//		Sector sector = Instantiate (state.BattleSector) as Sector;
//		state.BattleSector.size = sectorSize;
//		state.BattleSector = sector;
//	
//	}


	public void CreateFleet (FleetState _fleet)
	{
		GameObject _obj = new GameObject ("Fleet");
		fleet1 = _obj.AddComponent<Fleet> (); 
		fleet1.state = _fleet;
	}

	public void DeployFleet()
	{
		CreateFleet (Game.Manager.player.fleet);
		var deploymentArea = getDeploymentArea (Sector.northSpawn, fleet1.Size); 
		fleet1.Deploy (deploymentArea);

	}




}
