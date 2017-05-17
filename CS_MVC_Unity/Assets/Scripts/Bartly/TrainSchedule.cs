using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSchedule : MonoBehaviour {

	public List<TrainStop> trainStops;
	public int routeNumber;
	public string routeName;
	public int trainId;
	public int trainIdx;

	void Awake()
	{
		trainStops = new List<TrainStop> ();
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
