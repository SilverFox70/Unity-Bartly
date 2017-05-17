using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManager : MonoBehaviour 
{
	public event Action OnKeyDown_R;
	public event Action OnKeyDown_1;
	public event Action OnKeyDown_2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R))
		if (OnKeyDown_R != null)
			OnKeyDown_R ();

		if (Input.GetKeyDown (KeyCode.Alpha1))
		if (OnKeyDown_1 != null)
			OnKeyDown_1 ();

		if (Input.GetKeyDown (KeyCode.Alpha2))
		if (OnKeyDown_2 != null)
			OnKeyDown_2 ();
	}
}
