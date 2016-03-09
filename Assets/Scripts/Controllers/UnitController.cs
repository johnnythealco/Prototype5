﻿using UnityEngine;
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

	public void DestroyUnit()
	{
		Destroy (this.gameObject);
	}

	public void Move(Vector3 position)
	{
		Battle.Manager.unRegisterAtPoint (this.transform.position, this); 
		Battle.Manager.registerAtPoint (position, this); 
		this.transform.position = position;
	}


}
