﻿using System;

using UnityEngine;

// Dispatched when the enemy is clicked
public class EnemyClickedEventArgs : EventArgs
{
}

// Interface for the enemy view
public interface IEnemyView
{
	// Dispatched when the enemy is clicked
	event EventHandler<EnemyClickedEventArgs> OnClicked;

	// Set the enemy's position
	Vector3 Position {set; }
}
	
// Implementation of the enemy view
public class EnemyView : MonoBehaviour, IEnemyView 
{
	// Dispatched wen the enemy is clicked
	public event EventHandler<EnemyClickedEventArgs>OnClicked = (sender, e) => {};

	// Set the enemy's position
	public Vector3 Position { set { transform.position = value; } }

	// Update is called once per frame
	void Update () 
	{
		// If the primary mouse button was clicked this frame
		if (Input.GetMouseButton (0)) 
		{
			// if the mouse hit this enemy
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) && hit.transform == transform) 
			{
				// Dispatche OnClicked event
				var eventArgs = new EnemyClickedEventArgs();
				OnClicked(this, eventArgs);
			}
		}
	}
}
