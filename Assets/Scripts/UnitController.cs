using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour
{
	
	public UnitClass unitClass;

	public Unit unit;

	public bool initalized{ get; set; }


	public void initalize ()
	{
		unit.initalizeUnit (unitClass);
		initalized = true;
	}


}
