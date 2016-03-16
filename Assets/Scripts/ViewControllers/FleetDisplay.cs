using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FleetDisplay : MonoBehaviour
{
	protected FleetState fleet;

	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;

	public delegate void FleetDisplayDelegate (UnitState _unit);

	public event FleetDisplayDelegate onListItemClick;

	//List to record what unitDisplays have been created
	//This is to enabel each to be unscuscribed from when this is destroyed
	private List<UnitDisplay> unitDisplays;

	void Awake ()
	{
		unitDisplays = new List<UnitDisplay> ();
	}


	void OnDestroy ()
	{
		foreach (var _display in unitDisplays)
		{		
			Debug.Log (" Unsigned-up for onClick " + _display.displayName.text);
			_display.onClick -= UnitItem_onClick; 
		}
	}


	public void Prime (FleetState _fleet)
	{
		fleet = _fleet;
		fleet.onChanged += handleOnChanged;


		foreach (var unit in _fleet.units)
		{
			UnitDisplay unitItem = (UnitDisplay)Instantiate (unitDisplayPrefab);
			unitItem.transform.SetParent (targetTransform, false);
			unitItem.Prime (unit);
			unitItem.onClick += UnitItem_onClick;
			unitDisplays.Add (unitItem);
		}
	}

	void handleOnChanged ()
	{
		UpdateDisplay (fleet);
	}

	void UnitItem_onClick (UnitState _unit)
	{
		if (onListItemClick != null)
		{
			onListItemClick.Invoke (_unit);
		} 
	}
  

	void UpdateDisplay(FleetState _fleet)
		{

		foreach(var item in unitDisplays)
		{
			item.onClick -= UnitItem_onClick;
		}

		for (int i = 0; i < targetTransform.childCount; i++)
		{
			Destroy (targetTransform.GetChild (i).gameObject);
		}

		foreach (var unit in _fleet.units) 
		{
			UnitDisplay unitItem = (UnitDisplay)Instantiate (unitDisplayPrefab);
			unitItem.transform.SetParent (targetTransform, false);
			unitItem.Prime (unit);
			unitItem.onClick += UnitItem_onClick;
			unitDisplays.Add (unitItem);
		}
		
			
		}

}
