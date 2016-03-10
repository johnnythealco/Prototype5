using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitView : MonoBehaviour 
{
	
	public Text  displayName; 
	public Text actionPoints; 
	public Text  initiative; 
	public Text health; 
	public Text  evasion; 
	public Text  enginesHealth; 
	public Text  weaponsHealth; 
	public Text  movementRange;

	public void initalize(UnitState _unit)
	{
		displayName.text = "DisplayName: " + _unit.DisplayName; 
		actionPoints.text = "Action Points: " + _unit.ActionPoints.ToString(); 
		initiative.text = "Initiative: " +  _unit.Initiative.ToString(); 
		health.text = "Health: " + _unit.Health.ToString(); 
		evasion.text = "Evasion: " + _unit.Evasion.ToString(); 
		enginesHealth.text = "Engines: " + _unit.EnginesHealth.ToString(); 
		weaponsHealth.text = "Weapons: " + _unit.WeaponsHealth.ToString(); 
		movementRange.text = "Movement: "  + _unit.MovementRange.ToString();
	}



}
