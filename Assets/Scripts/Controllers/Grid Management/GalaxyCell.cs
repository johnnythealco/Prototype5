using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;
using Gamelogic;

public class GalaxyCell : SpriteCell{

	public List<Fleet> fleets;
	public bool isAccessible = true;
	public float Cost = 1;
	public Color[] colors;
	public Contents contents;






	public enum Contents
	{
		empty,
		star,
		pulsar,
		nebula,
		blackhole,
		supernova,
		wormhole,

	}

}
