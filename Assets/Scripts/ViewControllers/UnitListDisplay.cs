using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitListDisplay : MonoBehaviour
{

	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;

	public delegate void UnitListDisplayDelegate (UnitState _unit);

	public event UnitListDisplayDelegate onListItemClick;

	private List<UnitDisplay> unitDisplays;

	void Awake()
	{
		unitDisplays = new List<UnitDisplay> ();
	}


	public void Prime (List<Unit> units)
	{
		foreach (var unit in units)
		{
			UnitDisplay display = (UnitDisplay)Instantiate (unitDisplayPrefab);
			display.transform.SetParent (targetTransform, false);
			display.Prime (unit.state);
			display.onClick += Display_onClick;
			unitDisplays.Add (display);
		}
	}

	void OnDestroy ()
	{
		foreach (var _display in unitDisplays)
		{		
			Debug.Log (" Unsigned-up for onClick " + _display.displayName.text);
			_display.onClick -= Display_onClick; 
		}
	}

	void Display_onClick (UnitState _unit)
	{
//		Debug.Log ("Clicked " + _unit.DisplayName);
		if (onListItemClick != null)
		{
			onListItemClick.Invoke (_unit);
		} else
		{
//			Debug.Log ("Nobody was Listening to " + _unit.DisplayName);
		}
	}
}
