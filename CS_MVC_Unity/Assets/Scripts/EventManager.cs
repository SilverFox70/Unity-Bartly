using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{
	public Enemy numberOne;
	public Enemy numberTwo;
	public InputManager inputManager;
	public EnemyMovement enemyMovement;

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
		inputManager.OnMouseClicked += HandleMouseClicked;
	}

	// Unsubscribe to events and unregister delegates
	private void OnDisable()
	{
		// UnRegister your event here...
		inputManager.OnMouseClicked -= HandleMouseClicked;
	}

	// Methods to route events to Models goes below here...
	private void HandleMouseClicked(){
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)){
			Vector3 newPos = new Vector3(-1, 0, 0);
			GameObject enemy = hit.collider.gameObject;
			enemyMovement.MoveEnemy(enemy, newPos);
		}
	}

}
