using UnityEngine;
using System.Collections;

[System.Serializable]
public class Fleet : System.Object
{
	public Player owner;

	public UnitState[] units;

	public int Size	{ get { return units.Length; } }
	


	

}
