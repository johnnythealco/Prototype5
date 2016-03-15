using UnityEngine;
using System.Collections;

public class FleetDisplay : MonoBehaviour 
{
	protected Fleet fleet;
	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;

	public delegate void FleetDisplayDelegate (Unit _unit);

	public event FleetDisplayDelegate onListItemClick;

	public void Prime (Fleet _fleet)
	{
//		foreach (var unit in units)
//		{
//			UnitDisplay display = (UnitDisplay)Instantiate (unitDisplayPrefab);
//			display.transform.SetParent (targetTransform, false);
//			display.Prime (unit);
//			display.onClick += Display_onClick;
//			unitDisplays.Add (display);
//		}
	}

}
