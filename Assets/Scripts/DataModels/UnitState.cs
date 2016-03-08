using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class UnitState : System.Object
{
	

	private UnitClass unitClass;

	private String displayName;
	private int actionPoints;
	private float initiative;
	private float health;
	private float evasion;
	private float enginesHealth;
	private float weaponsHealth;
	private float movementRange;

	#region Properties

	public Player 		Owner { get; set; }

	public bool initalized{ get; set; }


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

	#endregion

	public UnitState(UnitClass _unitClass)
	{
		this.unitClass = _unitClass;
		this.displayName = _unitClass.displayName;
		this.actionPoints = _unitClass.actionPoints;
		this.initiative = _unitClass.initiative;
		this.health = _unitClass.health;
		this.evasion = _unitClass.evasion;
		this.enginesHealth = _unitClass.enginesHealth;
		this.weaponsHealth = _unitClass.weaponsHealth;
		this.movementRange = _unitClass.movementRange; 
	}

	public void initalize ()
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
