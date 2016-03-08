using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FleetController))]
public class FleetControllerEditor : Editor
{
	FleetController _controller;

	FleetState _state;

	private void OnEnable ()
	{
		_controller = (FleetController)target;
		_state = _controller.FleetState;
	}

	public override void OnInspectorGUI ()
	{

		DrawDefaultInspector ();

		if (GUILayout.Button ("Initalize Ship Class"))
		{
			_controller.initalize ();
		}
	}
}
