using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Unit))]
public class UnitEditor : Editor
{
	Unit _unit;

	private void OnEnable ()
	{
		_unit = (Unit)target;
		if (_unit.unitClass != null )
		{
			_unit.initalizeUnit ();
		}


	}

	public override void OnInspectorGUI ()
	{
		_unit.unitClass = EditorGUILayout.ObjectField ("unitClass", _unit.unitClass, typeof(UnitClass), false) as UnitClass;


		if (GUI.changed)
		{
			if (_unit.unitClass != null )
			{
				_unit.initalizeUnit ();
			}
		}
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
		if (_unit.unitClass.enginesHealth > 0)
			EditorGUILayout.LabelField ("Engines Health: ", _unit.EnginesHealth.ToString ());
		EditorGUILayout.LabelField ("");
		if (_unit.unitClass.weaponsHealth > 0)
			EditorGUILayout.LabelField ("Weapons Health:", _unit.WeaponsHealth.ToString ()); 

	}


}
