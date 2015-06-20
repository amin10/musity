// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ReadCSV : MonoBehaviour {
	
	public Dictionary<string, Color> instruments = new Dictionary<string, Color>();
	public string[] csvfiles = {
		"rainfall.csv", "phoenix.csv"
	};
	public Color[] colors = {
		Color.red, Color.green, Color.blue,  Color.yellow, Color.cyan, Color.black, Color.magenta
	};
	public int currentColor= 0;
	
	void Start ()
	{
		for (int j = 0; j < csvfiles.Length; j++) {
			print(j);
		
			string fileData = System.IO.File.ReadAllText (Application.dataPath + "/CSV/"+csvfiles[j]);
			string[] lines = fileData.Split ("\n" [0]);
		
			//Regex startRegex = new Regex( @"^\d+\.\d+");
			//Regex endRegex = new Regex( @"(?<=^\d+\.\d+,{1})\d+\.\d+");
			//Regex instrumentRegex = new Regex (@"\w+\s+\w+(s\+)");
			
			
			for (int i = 1; i < lines.Length-1; i++) {
				string[] items = lines [i].Split ("," [0]);

				//print ("start: " + items[0] + " end: " + items[1]);
				GameObject cube = Instantiate (Resources.Load ("Prefabs/Cube")) as GameObject;
				if( !instruments.ContainsKey(items[2])){
					instruments.Add(items[2], colors[currentColor]);
					currentColor = (currentColor + 1)% colors.Length;
				}
				cube.GetComponent<MeshRenderer> ().material.color = instruments [items [2]];
				cube.transform.localScale = new Vector3 (1, 1, float.Parse (items [1]) - float.Parse (items [0]));
				
				switch (items [2]) {
				case "acoustic guitar":
					cube.transform.position = new Vector3 (j, 1, float.Parse (items [0]));
					break;
						
				case "female singer":
					cube.transform.position = new Vector3 (j, 2, float.Parse (items [0]));
					break;
						
				case "clean electric guitar":
					cube.transform.position = new Vector3 (j, 3, float.Parse (items [0]));
					break;
				}

				

			}
		}
	}
}