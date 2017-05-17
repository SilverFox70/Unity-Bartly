using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour 
{
	public delegate void OnMovementComplete(GameObject go);
	public float speed = 1.0f;
	public bool moving = false;

	private OnMovementComplete CallBackFunction;

	public void MoveTrain(GameObject train, Vector3 posA, Vector3 posB, double dtime, OnMovementComplete NewCallBackFunction)
	{
		CallBackFunction = NewCallBackFunction;
		float startTime = Time.time;
		float dist = Vector3.Distance (posA, posB);
		speed = dist / (float)dtime;
		Debug.Log ("TrainMovement[MoveTrain] start time: " + startTime);
		Debug.Log ("Train " + train.tag + " Speed : " + speed);
		moving = true;
		StartCoroutine(MoveFromAtoB(train, posA, posB, dist, startTime));
	}

	IEnumerator MoveFromAtoB(GameObject train, Vector3 posA, Vector3 posB, float dist, float startTime)
	{
		float distCovered = 0f;
		while (distCovered < dist) 
		{
			distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / dist;
			train.transform.position = Vector3.Lerp (posA, posB, fracJourney);
			yield return null;
		}
		Debug.Log ("Train " + train.tag + " end time: " + Time.time);
		moving = false;
		CallBackFunction (train);
	}
}
