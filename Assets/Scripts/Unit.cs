using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Unit : System.Object
{
	



	private String displayName;
	private int actionPoints;
	private float initiative;
	private float health;
	private float evasion;
	private float enginesHealth;
	private float weaponsHealth;
	private float movementRange;

	public Player 		Owner { get; set; }


	public String		DisplayName{ get { return displayName; } }

	public int 			ActionPoints{ get { return actionPoints; } }

	public float		Initiative{ get { return initiative; } }

	public float		Health{ get { return health; } }

	public float		Evasion{ get { return evasion; } }

	public float		EnginesHealth{ get { return enginesHealth; } }

	public float		WeaponsHealth{ get { return weaponsHealth; } }

	public float		MovementRange{ get { return movementRange; } }



	public String		OwnerName { 
		get { 
			if (Owner != null)
				return Owner.displayName;
			else
				return "";
		}
	}




	public void initalizeUnit (UnitClass unitClass)
	{
		displayName = unitClass.displayName;
		actionPoints = unitClass.actionPoints;
		initiative = unitClass.initiative;
		health = unitClass.health;
		evasion = unitClass.evasion;
		enginesHealth = unitClass.enginesHealth;
		weaponsHealth = unitClass.weaponsHealth;
		movementRange = unitClass.movementRange; 

	}


}
