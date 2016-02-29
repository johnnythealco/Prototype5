using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Sector))]
public class SectorEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		Sector sector = (Sector)target;
		if(GUILayout.Button("Build Sector Grid"))
		{
			sector.BuildGrid ();
		}

	}


}
