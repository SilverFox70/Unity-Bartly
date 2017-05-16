using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStop 
{

	public string stationName;
	public DateTime origTime;

	public TrainStop(string s_name, DateTime depTime)
	{
		stationName = s_name;
		origTime = depTime;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
