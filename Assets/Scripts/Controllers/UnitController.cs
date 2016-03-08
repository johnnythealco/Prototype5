using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour
{
	
	public UnitClass unitClass;

	public UnitState state;

	public bool initalized{ get; set;}


	public void initalize ()
	{
		state = new UnitState (unitClass);
		initalized = true;

	}


}
