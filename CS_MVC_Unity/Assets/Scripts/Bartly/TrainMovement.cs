using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {

	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveTrain(GameObject train, Vector3 posA, Vector3 posB, int dtime)
	{
		float startTime = Time.time;
		float dist = Vector3.Distance (posA, posB);
		speed = dist / dtime;
		Debug.Log ("TrainMovement[MoveTrain] start time: " + startTime);
		Debug.Log ("Train " + train.tag + " Speed : " + speed);
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
	}
}
