using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainModel : MonoBehaviour 
{
	public int trainId;
	public int trainIdx;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
