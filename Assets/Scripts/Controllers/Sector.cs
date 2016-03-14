using UnityEngine;
using System.Collections.Generic;
using Gamelogic;
using Gamelogic.Grids;


public class Sector : GLMonoBehaviour
{
	public Cell cellPrefab;
	public int size = 12;
	public Vector2 padding;


	public static FlatHexGrid<Cell> Grid{ get; set; }

	public static IMap3D<FlatHexPoint> Map{ get; set; }

	public static FlatHexPoint northSpawn;
	public static FlatHexPoint southSpawn;
	public static FlatHexPoint northEastSpwan;
	public static FlatHexPoint northWestSpawn;
	public static FlatHexPoint southEastSpwan;
	public static FlatHexPoint southWestSpawn;



	void Start ()
	{
		
		BuildGrid ();

	}



	public void BuildGrid ()
	{

		if (Grid != null)
		{
			foreach (var point in Grid)
			{
				DestroyImmediate (Grid [point].gameObject);

			}
		}


		var spacing = cellPrefab.Dimensions;
		spacing.Scale (padding);

		Grid = FlatHexGrid<Cell>.Hexagon (size);
		Map = new FlatHexMap (spacing).AnchorCellMiddleCenter ().To3DXZ ();

		foreach (var point in Grid)
		{
			var cell = Instantiate (cellPrefab);
			Vector3 worldPoint = Map [point];
			cell.transform.parent = this.transform;
			cell.transform.localScale = Vector3.one;
			cell.transform.localPosition = worldPoint;

			cell.name = point.ToString ();
			Grid [point] = cell;

		}
		positionCollider ();
		createSpawnpoints ();
	}

	void positionCollider ()
	{

		var gridDimensions = new Vector2 ((float)size * 2.1f, (float)size * 2.1f);

		gridDimensions.Scale (cellPrefab.Dimensions);

		Vector3 coliderSize = new Vector3 (gridDimensions.x, 0.1f, gridDimensions.y);

		this.GetComponent<BoxCollider> ().size = coliderSize;

	}

	void createSpawnpoints ()
	{
		int _point = size - 3;

		northSpawn = new FlatHexPoint (0, _point);
		southSpawn = new FlatHexPoint (0, -_point);
		northEastSpwan = new FlatHexPoint (_point, 0);
		southEastSpwan = new FlatHexPoint (_point, -_point);
		northWestSpawn = new FlatHexPoint (-_point, _point); 
		southWestSpawn = new FlatHexPoint (-_point, 0);

		Grid [northSpawn].Color = Color.red;
		Grid [southSpawn].Color = Color.red;
		Grid [northEastSpwan].Color = Color.red;
		Grid [southEastSpwan].Color = Color.red;
		Grid [northWestSpawn].Color = Color.red;
		Grid [southWestSpawn].Color = Color.red;
	}



	/**
	 * Returns a list of Flat Hex Points including the start and end points
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<FlatHexPoint> getGridPath (FlatHexPoint start, FlatHexPoint end)
	{
		List<FlatHexPoint> path = new List<FlatHexPoint> ();


		var _path = Algorithms.AStar<Cell, FlatHexPoint>
		(Grid, start, end,
			            (p, q) => p.DistanceFrom (q),
			            c => c.isAccessible,
			            (p, q) => (Grid [p].Cost + Grid [q].Cost / 2)
		            );

		foreach (var step in _path)
		{
			path.Add (step); 

		}

		return path;
	}

	/**
	 * Returns a list of Vector3s including the start and end Vector3s
	 * accounting for isAccesible and cost for each cell along the path 
	 * */
	public List<Vector3> getGridPath (Vector3 start, Vector3 end)
	{
		List<Vector3> path = new List<Vector3> ();
		var _start = Map [start];
		var _end = Map [end];

		var _path = getGridPath (_start, _end);

		foreach (var step in _path)
		{
			path.Add (Map [step]);

		}

		return path;
	}






}
