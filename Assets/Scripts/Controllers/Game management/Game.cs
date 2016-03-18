using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour
{
	
	public static Game Manager = null;
	public GameState state;
	public Player player;
	public BattleState battleState;
	public List<Faction> factionList;







	void Awake ()
	{
		if (Manager == null)
			Manager = this;
		else if (Manager != this)
			Destroy (gameObject);    
            

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

		InitGame ();
	}


	void InitGame ()
	{
		return;
	}

	public List<string> getfactionNameList()
	{ 
		var result = new List<string> (); 
		foreach (var faction in factionList)
		{
			result.Add (faction.FactionName);
		}

		return result;
	}

	public Faction getFaction(int index)
	{
		if (index <= factionList.Count () && index > -1)
		{
			return factionList [index];
		}
		else
		{
			Debug.Log("Faction not Found!");
			return factionList [0];
		}
			

	}

}
