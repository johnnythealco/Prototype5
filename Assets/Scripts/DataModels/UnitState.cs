using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class UnitState : System.Object
{
	
	#region Variables

	private UnitClass unitClass;
	public Unit unitTemplate;

	private String displayName;
	private int actionPoints;
	private float initiative;
	private float health;
	private float evasion;
	private float enginesHealth;
	private float weaponsHealth;
	private float movementRange;

	#endregion

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

	#region Constructors



	public UnitState (Unit _template)
	{
		this.unitTemplate = _template;
		this.unitClass = _template.unitClass;
		this.displayName = _template.unitClass.displayName;
		this.actionPoints = _template.unitClass.actionPoints;
		this.initiative = _template.unitClass.initiative;
		this.health = _template.unitClass.health;
		this.evasion = _template.unitClass.evasion;
		this.enginesHealth = _template.unitClass.enginesHealth;
		this.weaponsHealth = _template.unitClass.weaponsHealth;
		this.movementRange = _template.unitClass.movementRange; 
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

	#endregion

	public bool TakeHealthDamage (float _dmg)
	{
		health = health - _dmg;

		if (health <= 0)
			return true;
		else
			return false;


	}


}
