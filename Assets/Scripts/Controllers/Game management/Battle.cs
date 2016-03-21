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

		deployFleetsatSpawnpoints ();
	}


	public void registerAtPoint (Vector3 point, Unit unit)
	{
		var _cell = Sector.Grid [Sector.Map [point]].state;
		_cell.contents = BattleCellState.Contents.unit;
		_cell.unit = unit;
		_cell.isAccessible = false;

		Battle.Manager.state.occupiedCells.Add (_cell);
			
	}

	public void unRegisterAtPoint (Vector3 point, Unit unit)
	{
		var _cell = Sector.Grid [Sector.Map [point]].state;
		_cell.contents = BattleCellState.Contents.empty; 
		_cell.unit = null;
		_cell.isAccessible = true;

		Battle.Manager.state.occupiedCells.Remove (_cell);

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


	public Fleet CreateFleet (FleetState _fleet)
	{
		GameObject _obj = new GameObject ("Fleet");
		var fleet = _obj.AddComponent<Fleet> (); 
		fleet.state = _fleet;
		return fleet;
	}

	public void DeployFleet(FleetState _fleet, FlatHexPoint _spawnPoint)
	{
		
		var fleet = CreateFleet (_fleet);
		var deploymentArea = getDeploymentArea (_spawnPoint, _fleet.Size); 
		fleet.Deploy (deploymentArea);
	
	}

	private void deployFleetsatSpawnpoints()
	{
		foreach(var _fleet in state.Fleets_SpawnPoints.Keys)
		{
			switch(state.Fleets_SpawnPoints[_fleet])
			{
			case 0:
				DeployFleet (_fleet, Sector.centerSpawn);
				break;
			case 1:
				DeployFleet (_fleet, Sector.northSpawn);
				break;
			case 2:
				DeployFleet (_fleet, Sector.northEastSpwan);
				break;
			case 3:
				DeployFleet (_fleet, Sector.southEastSpwan);
				break;
			case 4:
				DeployFleet (_fleet, Sector.southSpawn);
				break;
			case 5:
				DeployFleet (_fleet, Sector.southWestSpawn);
				break;
			case 6:
				DeployFleet (_fleet, Sector.northWestSpawn);
				break;
			default:
				Debug.Log("No Spawn point Found");
				break;

			}



		}
	}




}
