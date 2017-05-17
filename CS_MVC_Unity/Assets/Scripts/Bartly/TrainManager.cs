using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

	private TrainStop lastStop = null;
	private int index = 0;
	private TrainSchedule trainSchedule;
	private GameObject trainSchedObject;
	private TrainMovement trainMovement;

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
		trainMovement = train.GetComponent<TrainMovement> ();
		trainSchedObject = GameObject.Find ("Train3610402");
		trainSchedule = trainSchedObject.GetComponent<TrainSchedule> ();
		IterateStops (train);

	}

	public void IterateStops(GameObject train)
	{
		Debug.Log ("index: " + index + " stop count: " + trainSchedule.trainStops.Count);
		// if the current indexed stop exists, the next index is not out of bounds, and the next stop exists
		if ((trainSchedule.trainStops.Count >= index+2) && trainSchedule.trainStops [index] != null && trainSchedule.trainStops [index + 1] != null) 
		{
			Debug.Log ("Traveling from " + trainSchedule.trainStops [index].stationName + " to " + trainSchedule.trainStops [index + 1].stationName);
			TryTrainMove(trainSchedule.trainStops[index], trainSchedule.trainStops[ index + 1], train); 
		}
	}

	public void TryTrainMove(TrainStop thisStop, TrainStop nextStop, GameObject train)
	{
		index += 1;
		Vector3 startPos = GameObject.Find (thisStop.stationName).transform.position;
		Vector3 endPos = GameObject.Find (nextStop.stationName).transform.position;
		double deltaTime = (nextStop.origTime - thisStop.origTime).TotalMinutes;
		trainMovement.MoveTrain (train, startPos, endPos, deltaTime, IterateStops);
	}

//	IEnumerator SendMoveData(TrainStop trainStop, TrainMovement trainMovement, GameObject train)
//	{
//		
//		if (lastStop == null) {
//			lastStop = trainStop;
//		} else {
//			double timeDiff = (trainStop.origTime - lastStop.origTime).TotalMinutes;
//			Vector3 lastStation = GameObject.Find (lastStop.stationName).transform.position;
//			Vector3 nextStation = GameObject.Find (trainStop.stationName).transform.position;
//			trainMovement.MoveTrain (train, lastStation, nextStation, timeDiff);
//			while (trainMovement.moving) 
//			{
//				yield ;
//			}
//
//		}
//	}
}
