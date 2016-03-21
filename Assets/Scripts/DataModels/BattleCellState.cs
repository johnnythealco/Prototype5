using UnityEngine;
using System.Collections;

[System.Serializable]
public class BattleCellState : System.Object
{
	[SerializeField]
//	public Vector2 coordinates;
	public Unit unit;
	public bool isAccessible = true;
	public float Cost = 1;
	public Contents contents;



	public enum Contents
	{
		empty,
		unit

	}

}
