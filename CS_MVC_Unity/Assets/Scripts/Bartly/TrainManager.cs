using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Dev version of this method
	public void ScheduleReady()
	{
		var prefab = Resources.Load<GameObject> ("Train");
		var train = UnityEngine.Object.Instantiate (prefab);
		TrainMovement trainMovement = train.GetComponent<TrainMovement> ();
		GameObject trainSched = GameObject.Find ("Train3670757");
		TrainSchedule trainSchedule = trainSched.GetComponent<TrainSchedule> ();
		TrainStop lastStop = null;
		foreach (TrainStop tstop in trainSchedule.trainStops) 
		{
			if (lastStop == null) {
				lastStop = tstop;
			} else {
				double timeDiff = (tstop.origTime - lastStop.origTime).TotalMinutes;
				Vector3 lastStation = GameObject.Find (lastStop.stationName).transform.position;
				Vector3 nextStation = GameObject.Find (tstop.stationName).transform.position;
				trainMovement.MoveTrain (train, lastStation, nextStation, timeDiff);

			}
		}
	}
}
