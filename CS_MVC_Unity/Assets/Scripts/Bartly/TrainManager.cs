using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

	private TrainStop lastStop = null;

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
		GameObject trainSched = GameObject.Find ("Train3630417");
		TrainSchedule trainSchedule = trainSched.GetComponent<TrainSchedule> ();


		foreach (TrainStop tstop in trainSchedule.trainStops) 
		{
			StartCoroutine (SendMoveData (tstop, trainMovement, train));
		}
	}

	IEnumerator SendMoveData(TrainStop trainStop, TrainMovement trainMovement, GameObject train)
	{
		
		if (lastStop == null) {
			lastStop = trainStop;
		} else {
			double timeDiff = (trainStop.origTime - lastStop.origTime).TotalMinutes;
			Vector3 lastStation = GameObject.Find (lastStop.stationName).transform.position;
			Vector3 nextStation = GameObject.Find (trainStop.stationName).transform.position;
			trainMovement.MoveTrain (train, lastStation, nextStation, timeDiff);
			while (trainMovement.moving) 
			{
				yield return null;
			}

		}
	}
}
