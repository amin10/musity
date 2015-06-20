// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ReadCSV : MonoBehaviour {
	
	public Dictionary<string, Color> instruments = new Dictionary<string, Color>
	{
		{"acoustic guitar", Color.red},
		{"female singer", Color.blue},
		{"clean electric guitar", Color.green}
	};
	
	
	void Start ()
	{
		string fileData = System.IO.File.ReadAllText(Application.dataPath+"/CSV/rainfall.csv");
		string[] lines = fileData.Split("\n"[0]);
	
		//Regex startRegex = new Regex( @"^\d+\.\d+");
		//Regex endRegex = new Regex( @"(?<=^\d+\.\d+,{1})\d+\.\d+");
		//Regex instrumentRegex = new Regex (@"\w+\s+\w+(s\+)");
		
		
		for (int i = 1; i < lines.Length - 1; i++)
		{
			string[] items = lines[i].Split (","[0]);
			
			print ("start: " + items[0] + " end: " + items[1]);
			GameObject cube = Instantiate(Resources.Load ("Prefabs/Cube"), new Vector3(0,0, float.Parse(items[0])), Quaternion.identity) as GameObject;
			cube.transform.localScale = new Vector3 (1,1, float.Parse (items[1]) - float.Parse (items[0]));
			
			cube.GetComponent<MeshRenderer>().sharedMaterial.color = instruments[items[2]];
			
//			Match startMatch = startRegex.Match (lines[i]);
//			Match endMatch = endRegex.Match (lines[i]);
//			Match instrumentMatch = instrumentRegex.Match (lines[i]);
//			
//			if (startMatch.Success)
//			{
//				GameObject cube = Instantiate(Resources.Load ("Prefabs/Cube"), new Vector3(0,0, float.Parse(startMatch.Value)), Quaternion.identity) as GameObject;
//				cube.transform.localScale = new Vector3 (1,1, float.Parse (endMatch.Value) - float.Parse (startMatch.Value));
//				
//				print (instrumentMatch.Value);
//				//print(instruments[instrumentMatch.Value]);
//				
////				switch (instrumentMatch.Value)
////				{
////					case 
////				}
//				
//				//print (instrumentMatch.Value);
//			}
		}
		
		
		//string[] lineData  = (lines[0].Trim()).Split(","[0]);
		//float x;
		//float.TryParse(lineData[0], out x);
	}
}