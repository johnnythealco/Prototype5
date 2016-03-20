using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;


/*
 * A Class to take input from the Player and pass it to the Player Class
 * */


[RequireComponent (typeof(Player))]
public class PlayerInputController : MonoBehaviour
{

	private Player player;

	void Awake ()
	{
		player = GetComponent<Player> ();
	
	}

	public void Update ()
	{
		getMouseInput ();

	}


	private void getMouseInput ()
	{

		if (Input.GetMouseButtonDown (0))
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
			{
				Vector3 worldPosition = this.transform.InverseTransformPoint (hit.point);
				var point = Sector.Map [worldPosition]; 
				if (Sector.Grid.Contains (point))
				{
					{
						leftClickAction (point);
					}

				}
			}
		}
	}


	private void leftClickAction (FlatHexPoint point)
	{
		if (Sector.Grid [point].unit != null)
			player.SelectUnit (Sector.Grid [point].unit);

		if (player.unitSelected != null && Sector.Grid [point].contents == BattleCell.Contents.empty)
			player.unitSelected.Move (Sector.Map [point]);
	}

}
