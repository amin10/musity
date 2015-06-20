// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ReadCSV : MonoBehaviour {
	
	void Start ()
	{
	
		string fileData = System.IO.File.ReadAllText("/Users/romansharf/unity-experiments/musity/Unity/Assets/CSV/rainfall.csv");
		string[] lines = fileData.Split("\n"[0]);
		
		Regex regex = new Regex( @"^\d+\.\d+");
		
		for (int i = 1; i < lines.Length; i++)
		{
			Match match = regex.Match (lines[i]);
			if (match.Success)
			{
				print (match.Value);
			}
			//print (Regex.IsMatch(lines[i], @"^\d.\\d").Groups[1].Value);
			//Instantiate(Resources.Load ("Prefabs/Cube"));
		}
		
		
		//string[] lineData  = (lines[0].Trim()).Split(","[0]);
		//float x;
		//float.TryParse(lineData[0], out x);
	}
}