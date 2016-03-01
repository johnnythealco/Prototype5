using UnityEngine;
using System.Collections;

public class Fleet : MonoBehaviour 
{
	public Player owner;

	public Unit[] units;

	public int Size	{get{ return units.Length; }	}
	


	

}
