using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Unit))]
public class UnitControllerEditor : Editor
{
	Unit _Controller;
	
	UnitState _unit;

	
	
	
	private void OnEnable ()
	{
		_Controller = (Unit)target;
	
		_unit = _Controller.state;
	
		if (_Controller.unitClass != null && !EditorApplication.isPlaying)
		{
			_Controller.initalize ();
		}
	
	
	}

	public override void OnInspectorGUI ()
	{
	
		DrawDefaultInspector ();
	
		if (_Controller.unitClass != null)
		{
	
			_unit = _Controller.state;
	
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

		if(GUILayout.Button("Initalize Ship Class"))
		{
			_Controller.initalize ();
		}


		if(GUILayout.Button("Damage Health by 10"))
		{
			_Controller.state.TakeHealthDamage (10f);
		}
	}



}
