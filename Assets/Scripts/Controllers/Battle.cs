using UnityEngine;
using System.Collections;
using Gamelogic.Grids;
using Gamelogic;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Battle : GridBehaviour<FlatHexPoint>
{

	public static Battle Manager;
	public UnitState test;
	public Player player;
	public Fleet fleet1;
	public UnitState u;

	void Awake ()
	{
		Manager = this;
	}

	//	private void CreateUnit (FlatHexPoint _point, UnitController _unit, Player _owner)
	//	{
	//
	//		UnitController unit = Instantiate (_unit, Sector.Map [_point], Quaternion.identity) as UnitController;
	//
	//		Sector.Grid [_point].contents = Cell.Contents.unit;
	//		Sector.Grid [_point].unit = unit;
	//		Sector.Grid [_point].unit.unit.owner = _owner;
	//		Sector.Grid [_point].isAccessible = false;
	//
	//	}
	//
	//
	//	public void Test1 ()
	//	{
	////		CreateUnit (Sector.northSpawn, test, player);
	//		DeployFleet (Sector.northSpawn, fleet1);
	//	}
	//
	//	public List<Vector3> getDeploymentArea (FlatHexPoint point, int radius)
	//	{
	//		List<Vector3> result = new List<Vector3> ();
	//		var area = Algorithms.GetPointsInRange<Cell, FlatHexPoint>
	//		(Sector.Grid, point,
	//			           JKCell => JKCell.isAccessible,
	//			           (p, q) => 1,
	//			           radius
	//		           );
	//
	//
	//		foreach (var _point in area)
	//		{
	//			result.Add (Sector.Map [_point]);
	//		}
	//		return result;
	//	}
	//
	//
	//	private void DeployFleet (FlatHexPoint _center, Fleet _fleet)
	//	{
	//		var deployment = getDeploymentArea (_center, _fleet.Size);
	//
	//
	//		for (int i = 0; i < _fleet.units.Count (); i++)
	//		{
	//			var point = deployment.RandomItem ();
	//			CreateUnit (Sector.Map [point], _fleet.units [i], _fleet.owner);
	//			deployment.Remove (point);
	//		}
	//	}

}
