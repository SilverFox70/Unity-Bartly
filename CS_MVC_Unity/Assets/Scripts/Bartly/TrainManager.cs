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
		trainSchedObject = GameObject.Find ("Train3630417");
		trainSchedule = trainSchedObject.GetComponent<TrainSchedule> ();
		IterateStops (train);

//		foreach (TrainStop tstop in trainSchedule.trainStops) 
//		{
//			StartCoroutine (SendMoveData (tstop, trainMovement, train));
//		}
	}

	public void IterateStops(GameObject train)
	{
		if (trainSchedule [index] != null && trainSchedule [index + 1] != null && !trainMovement.moving) 
		{
			TryTrainMove(trainSchedule[index], trainSchedule[ index + 1], train); 
		}
	}

	public void TryTrainMove(TrainStop thisStop, TrainStop nextStop, GameObject train)
	{
		trainMovement.MoveTrain ();
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
