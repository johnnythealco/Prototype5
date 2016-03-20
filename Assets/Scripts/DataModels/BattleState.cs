using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class BattleState : System.Object
{
	public Dictionary<FleetState, int> Fleets_SpawnPoints;
	public int battleSectorSize;
	public string SectorName;

	public BattleState( Dictionary<FleetState, int>  _fleets_SpawnPoints, int _sectorSize,string _sectorName)
	{
		Fleets_SpawnPoints = _fleets_SpawnPoints;
		battleSectorSize = _sectorSize;
		SectorName = _sectorName;
	}



}
