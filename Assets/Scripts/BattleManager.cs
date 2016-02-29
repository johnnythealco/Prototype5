using UnityEngine;
using System.Collections;
using Gamelogic.Grids;
using Gamelogic;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class BattleManager : GridBehaviour<FlatHexPoint>
{

	public static BattleManager MGR;

	void Awake()
	{
		MGR = this;
			}


	/**
	 * Returns a list of Flat Hex Points including the start and end points
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<FlatHexPoint> getGridPath(FlatHexPoint start, FlatHexPoint end)
	{
		List<FlatHexPoint> path = new List<FlatHexPoint> ();


		var _path = Algorithms.AStar<Cell, FlatHexPoint>
		(Sector.Grid, start, end,
			            (p, q) => p.DistanceFrom (q),
			            c => c.isAccessible,
			            (p, q) => (Sector.Grid [p].Cost + Sector.Grid [q].Cost / 2)
		            );

		foreach(var step in _path)
		{
			path.Add (step); 

		}

		return path;
	}

	/**
	 * Returns a list of Vector3s including the start and end Vector3s
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<Vector3> getGridPath(Vector3 start, Vector3 end)
	{
		List<Vector3> path = new List<Vector3> ();
		var _start = Sector.Map [start];
		var _end = Sector.Map [end];

		var _path = getGridPath (_start, _end);

		foreach (var step in _path)
		{
			path.Add (Sector.Map [step]);

		}

		return path;
	}


}
