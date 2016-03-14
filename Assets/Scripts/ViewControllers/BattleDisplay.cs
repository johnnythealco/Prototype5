using UnityEngine;
using System.Collections;

public class BattleDisplay : MonoBehaviour
{
	public static BattleDisplay BattleUI;
	public UnitDisplay unitDetails;


	void Awake ()
	{
		BattleUI = this;

		unitDetails.gameObject.SetActive (false);
	
	}
	

}
