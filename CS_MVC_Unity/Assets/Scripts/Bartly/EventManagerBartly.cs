using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerBartly : MonoBehaviour 
{
	public WebRequestHandler wrh;
	public UserInputManager userInputManager;
	public XmlParsing xmlParser;
//	public TrainMovement trainMovement;

	// Awake this instance
	void Awake()
	{

	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Event Manager online: " + this.isActiveAndEnabled);
	}

	// Subscribe to events and assign delegates
	private void OnEnable()
	{
		// Register your events here...
		userInputManager.OnKeyDown_R += HandleKeyDown_R;
		userInputManager.OnKeyDown_1 += HandleKeyDown_1;
		userInputManager.OnKeyDown_2 += HandleKeyDown_2;
		wrh.OnLoadedEvent += HandleLoadedEvent;
	}

	// Unsubscribe to events and unregister delegates
	private void OnDisable()
	{
		// UnRegister your event here...
		userInputManager.OnKeyDown_R -= HandleKeyDown_R;
		userInputManager.OnKeyDown_1 -= HandleKeyDown_1;
		userInputManager.OnKeyDown_2 += HandleKeyDown_2;
		wrh.OnLoadedEvent -= HandleLoadedEvent;
	}

	private void HandleKeyDown_R()
	{
		string url = "http://api.bart.gov/api/sched.aspx?cmd=routesched&route=1&key=MW9S-E7SL-26DU-VV8V&time=12:47+am";
		wrh.GetDataFromURL (url);

	}

	private void HandleKeyDown_1()
	{
		Debug.Log ("EventManagerBartly[HandleKeyDown_1]");
		GameObject train = GameObject.FindGameObjectWithTag ("train_1");
		Vector3 trainPos = train.transform.position;
		Vector3 newPos = trainPos + new Vector3 (6, 0, 0);
		TrainMovement trainMovement = train.GetComponent<TrainMovement> ();
		trainMovement.MoveTrain (train, trainPos, newPos, 3);
	}

	private void HandleKeyDown_2()
	{
		Debug.Log ("EventManagerBartly[HandleKeyDown_2]");
		GameObject train = GameObject.FindGameObjectWithTag ("train_2");
		Vector3 trainPos = train.transform.position;
		Vector3 newPos = trainPos + new Vector3 (3, 0, 0);
		TrainMovement trainMovement = train.GetComponent<TrainMovement> ();
		trainMovement.MoveTrain (train, trainPos, newPos, 3);
	}

	private void HandleLoadedEvent()
	{
		string data = wrh.dataString;
		Debug.Log ("EventManagerBartly[HandleLoadedEvent] data:\n" + data);
		xmlParser.parseXml (data);
	}

}
