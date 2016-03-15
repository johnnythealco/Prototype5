using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
	protected UnitState unit;
	public Image sprite;
	public Text displayName;
	public Text actionPoints;
	public Text initiative;
	public Text health;
	public Text evasion;
	public Text enginesHealth;
	public Text weaponsHealth;
	public Text movementRange;

	public delegate void UnitDisplayDelegate (UnitState _unit);

	public event UnitDisplayDelegate onClick;


	public void Prime (UnitState unitState)
	{
		unit = unitState;
		
		if (displayName != null)
			displayName.text = unitState.DisplayName; 

		if (actionPoints != null)
			actionPoints.text = "Action Points: " + unitState.ActionPoints.ToString ();

		if (initiative != null)
			initiative.text = "Initiative: " + unitState.Initiative.ToString (); 
		
		if (health != null)
			health.text = "Health: " + unitState.Health.ToString (); 
		
		if (evasion != null)
			evasion.text = "Evasion: " + unitState.Evasion.ToString (); 
		
		if (enginesHealth != null)
			enginesHealth.text = "Engines: " + unitState.EnginesHealth.ToString (); 
		
		if (weaponsHealth != null)
			weaponsHealth.text = "Weapons: " + unitState.WeaponsHealth.ToString (); 
		
		if (movementRange != null)
			movementRange.text = "Movement: " + unitState.MovementRange.ToString ();
	}

	public void Click ()
	{
//		Debug.Log ("Clicked " + unit.DisplayName);
		if (onClick != null)
		{
			onClick.Invoke (unit);
		} else
		{
//			Debug.Log ("Nobody was Listening to " + unit.DisplayName);
		}
	}



}
