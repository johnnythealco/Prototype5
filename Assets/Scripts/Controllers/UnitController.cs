using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour
{
	
	//	public UnitClass unitClass;

	public UnitState state;

	public bool initalized{ get { return state.initalized; } }


	public void initalize ()
	{
		state.initalize ();
		state.initalized = true;
	}


}
