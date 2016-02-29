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
	public static IMap3D<FlatHexPoint> Map{ get; set;}

	public FlatHexPoint northSpawn;
	public FlatHexPoint southSpawn;
	public FlatHexPoint northEastSpwan;
	public FlatHexPoint northWestSpawn;
	public FlatHexPoint southEastSpwan;
	public FlatHexPoint southWestSpawn;



		void Start () 
	{
		
		BuildGrid ();

		createSpawnpoints ();


	}
	


	public void BuildGrid()
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

		foreach(var point in Grid)
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
	}

	void positionCollider()
	{

		var gridDimensions = new Vector2 ((float)size * 2.1f, (float)size * 2.1f);

		gridDimensions.Scale ( cellPrefab.Dimensions);

		Vector3 coliderSize = new Vector3(gridDimensions.x, 0.1f, gridDimensions.y);

		this.GetComponent<BoxCollider> ().size = coliderSize;

	}

	void createSpawnpoints()
	{
		int _point = size - 3;

		northSpawn = new FlatHexPoint (0, _point);
		southSpawn = new FlatHexPoint(0, -_point);
		northEastSpwan = new FlatHexPoint (_point,0);
		southEastSpwan = new FlatHexPoint (_point,-_point);
		northWestSpawn = new FlatHexPoint (-_point,_point); 
		southWestSpawn = new FlatHexPoint (-_point,0);

		Grid [northSpawn].Color = Color.red;
		Grid [southSpawn].Color = Color.red;
		Grid [northEastSpwan].Color = Color.red;
		Grid [southEastSpwan].Color = Color.red;
		Grid [northWestSpawn].Color = Color.red;
		Grid [southWestSpawn].Color = Color.red;
	}







}
