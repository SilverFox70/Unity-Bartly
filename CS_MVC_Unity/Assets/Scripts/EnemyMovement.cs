using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveEnemy(GameObject enemy, Vector3 newPosition)
	{
		enemy.transform.position += newPosition;
	}
}
