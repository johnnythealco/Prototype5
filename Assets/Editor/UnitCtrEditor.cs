using UnityEngine;
using System.Collections;
using UnityEditor;

public class UnitCtrEditor : Editor
{
	UnitController _Controller;

	Unit _unit;

	private void OnEnable ()
	{
		_Controller = (UnitController)target;

		_unit = _Controller.unit;

		if (_Controller.unitClass != null)
		{
			_Controller.initalize ();
		}
	
	
	}

	public override void OnInspectorGUI ()
	{

		DrawDefaultInspector ();
	
	

		EditorGUILayout.LabelField ("Owner:", _unit.OwnerName);
		EditorGUILayout.LabelField ("Display Name:", _unit.DisplayName);
		EditorGUILayout.LabelField ("Action Points:", _unit.ActionPoints.ToString ());
		EditorGUILayout.LabelField ("");
		EditorGUILayout.LabelField ("Health:", _unit.Health.ToString ());
		EditorGUILayout.LabelField ("Movement:", _unit.MovementRange.ToString ());
		EditorGUILayout.LabelField ("");
		EditorGUILayout.LabelField ("Initiative:", _unit.Initiative.ToString ());
		EditorGUILayout.LabelField ("");
		EditorGUILayout.LabelField ("Evasion:", _unit.Evasion.ToString ());
		if (_Controller.unitClass.enginesHealth > 0)
			EditorGUILayout.LabelField ("Engines Health: ", _unit.EnginesHealth.ToString ());
		EditorGUILayout.LabelField ("");
		if (_Controller.unitClass.weaponsHealth > 0)
			EditorGUILayout.LabelField ("Weapons Health:", _unit.WeaponsHealth.ToString ());
	
	}


}
