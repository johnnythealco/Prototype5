using UnityEngine;
using System.Collections;

public class UnitResponder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitDisplay.onClick += UnitDisplay_onClick;
	
	}

	void OnDestroy(){
		Debug.Log (" Unsigned-up for onClick");
		UnitDisplay.onClick -= UnitDisplay_onClick;
	}

	void UnitDisplay_onClick (UnitController _unit)
	{
		Debug.Log(" I AM LISTENING !!");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
