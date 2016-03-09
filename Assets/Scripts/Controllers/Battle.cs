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


	void Awake ()
	{
		Manager = this;
	}


	public void registerAtPoint(Vector3 point, UnitController unit) 
	{
		var _point = Sector.Map[point];
		Sector.Grid [_point].contents = Cell.Contents.unit;
		Sector.Grid [_point].unit = unit;
		Sector.Grid [_point].isAccessible = false;
			
	}


	public void unRegisterAtPoint(Vector3 point, UnitController unit) 
	{
		var _point = Sector.Map[point];
		Sector.Grid [_point].contents = Cell.Contents.empty; 
		Sector.Grid [_point].unit = null;
		Sector.Grid [_point].isAccessible = true;

	}

	public List<Vector3> getDeploymentArea (FlatHexPoint point, int radius)
		{
			List<Vector3> result = new List<Vector3> ();
			var area = Algorithms.GetPointsInRange<Cell, FlatHexPoint>
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




}
