using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSchedule : MonoBehaviour {

	public List<TrainStop> trainStops;
	public int routeNumber;
	public string routeName;

	public TrainSchedule(int r_number, string r_name)
	{
		routeNumber = r_number;
		routeName = routeName;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStop(TrainStop trainStop)
	{
		trainStops.Add (trainStop);
	}
		
}
