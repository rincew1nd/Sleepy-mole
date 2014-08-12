using UnityEngine;
using System.Collections;
using System.IO;

public class level_generation : MonoBehaviour {
	
	public int level = 1;
	public int[,] array = new int[30,30];

	void Start () {
		lvlGen ();
		lvlForm ();
	}

	void lvlGen() {
		var sr = new StreamReader(Application.dataPath + "/level" + level + ".txt");
		var fileContents = sr.ReadToEnd();
		sr.Close();

		var lines = fileContents.Split(";\n"[0]);

		for (int i = 0; i<lines.Length; i++) {
			string line = lines[i];
			int j=0;
			foreach (string num in line.Split("."[0])) {
				int number = 5;
				int.TryParse(num, out number);
				array[i,j] = number;
				j++;
			}
		}
	}

	void lvlForm() {
		for (int i=0; i<30; i++) {
			for (int j=0; j<30; j++) {
				string block_name = "null";
				switch (array[i,j]) {
				case 0:
					break;
				case 1:
					block_name = "metal";
					break;
				case 2:
					block_name = "earth";
					break;
				case 3:
					block_name = "water";
					break;
				case 4:
					block_name = "box";
					break;
				default:
					break;
				}
//				Debug.Log(block_name);
				if(block_name != "null")
					Instantiate(Resources.Load(block_name), new Vector3(j, i, 0), Quaternion.identity);
			}
		}
	}
}
