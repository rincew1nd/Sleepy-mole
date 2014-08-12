using UnityEngine;
using System.Collections;
[System.Serializable]

public class block_info  {

	public block_info(int health,int dest,int noise, int danger, string b_type)
	{
		this.health = health;
		this.dest = dest;
		this.noise = noise;
		this.danger = danger;
		this.b_type = b_type;
	}

	public int health;
	public int dest;
	public int noise;
	public int danger;
	public string b_type;
}
