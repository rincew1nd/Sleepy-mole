using UnityEngine;
using System.Collections;

public class block_destruction : MonoBehaviour {

	public int health;
	public int dest;
	public int noise;
	public int danger;

	public bool isGoal;
	public string b_type;

	// Use this for initialization
	void Start () {
		if (dest == 1)
						gameObject.tag = "Block_dest";
				else
						gameObject.tag = "Block_solid";

	
	}
	
	// Update is called once per frame
	void Update () {
				if (health <=0) {
						if(noise==1)
			{
				restart r;
				r= GameObject.Find("Stats").GetComponent<restart>();
				r.score++;

			}
			 if (isGoal) {
				Goal_manager g_m = GameObject.FindGameObjectWithTag("Goal_manager").GetComponent<Goal_manager>();
				for(int i=0;i<g_m.Goal_blocks.Count;i++)
				{
					if(g_m.Goal_blocks[i]==gameObject)
						g_m.Goal_blocks.Remove(g_m.Goal_blocks[i]);

				}
			}

						Destroy (gameObject);
				}
		}

}
