using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	
	public static Game Manager = null;
	public GameState state;
	public Player player;
	public BattleState battleState;



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
}
