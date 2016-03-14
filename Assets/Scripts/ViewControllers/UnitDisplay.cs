using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour 
{
	protected Unit unit;
	public Image sprite;
	public Text  displayName; 
	public Text actionPoints; 
	public Text  initiative; 
	public Text health; 
	public Text  evasion; 
	public Text  enginesHealth; 
	public Text  weaponsHealth; 
	public Text  movementRange;

	public delegate void UnitDisplayDelegate(Unit _unit);
	public static event UnitDisplayDelegate onClick;


	public void Prime(Unit _unit)
	{
		this.unit = _unit;
		if(displayName != null)
		displayName.text =  _unit.state.DisplayName; 

		if(actionPoints != null)
		actionPoints.text = "Action Points: " + _unit.state.ActionPoints.ToString();

		if(initiative != null)
		initiative.text = "Initiative: " +  _unit.state.Initiative.ToString(); 
		
		if(health != null)
		health.text = "Health: " + _unit.state.Health.ToString(); 
		
		if(evasion != null)
		evasion.text = "Evasion: " + _unit.state.Evasion.ToString(); 
		
		if(enginesHealth != null)
		enginesHealth.text = "Engines: " + _unit.state.EnginesHealth.ToString(); 
		
		if(weaponsHealth != null)
		weaponsHealth.text = "Weapons: " + _unit.state.WeaponsHealth.ToString(); 
		
		if(movementRange != null)
		movementRange.text = "Movement: "  + _unit.state.MovementRange.ToString();
	}

	public void Click()
	{
		Debug.Log ("Clicked " + unit.state.DisplayName);
		if (onClick != null)
		{
		onClick.Invoke (unit);
		}
		else
		{
			Debug.Log ("Nobody was Listening to " + unit.state.DisplayName);
		}
		}



}
