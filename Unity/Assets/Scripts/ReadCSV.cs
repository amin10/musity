// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ReadCSV : MonoBehaviour {
	
	public Dictionary<string, Color> instruments = new Dictionary<string, Color>();
	List<string> csvfiles = new List<string>();
	public Color[] colors = {
		Color.red, Color.green, Color.blue,  Color.yellow, Color.cyan, Color.black, Color.magenta
	};

	void Start ()
	{
		int currentColor = 0;

		for (int file = 1; file < 124; file++) {
			csvfiles.Add (file.ToString("0000")+".csv");
		}
		for (int j = 0; j < csvfiles.Count; j++) {		
			string fileData = System.IO.File.ReadAllText (Application.dataPath + "/CSV/"+csvfiles[j]);
			string[] lines = fileData.Split ("\n" [0]);
		
			List<string> currentInstruments = new List<string>();
			
			for (int i = 1; i < lines.Length-1; i++) {
				string[] items = lines [i].Split ("," [0]);

				GameObject cube = Instantiate (Resources.Load ("Prefabs/Cube")) as GameObject;
				if( !instruments.ContainsKey(items[2])){
					instruments.Add(items[2], colors[currentColor%(colors.Length)]);

					currentColor = currentColor + 1;
				}
				if (! currentInstruments.Contains (items[2])){
					currentInstruments.Add(items[2]);
				}

				cube.GetComponent<MeshRenderer>().material.color = instruments [items [2]];
				cube.transform.localScale = new Vector3 (1, 1, float.Parse (items [1]) - float.Parse (items [0]));


				cube.transform.position = new Vector3 (j, currentInstruments.IndexOf(items[2])+1, float.Parse (items[0]));

			}
		}
	}
}