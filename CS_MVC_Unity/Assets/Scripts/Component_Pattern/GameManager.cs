using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this singleton script to globally manage your game
public class GameManager : MonoBehaviour 
{
	public int NumberOfEnemies = 2;
	public Vector3 EnemySpawnOffset = new Vector3 (0, -1, 0);
	public Vector3 instanceOffset = new Vector3(0, 0, 0);
	public static GameManager instance = null;	

	// Awake is always called before any Start functions
	void Awake()
	{
		// Check if instance already exists
		if (instance == null) 
		{
			// if not, set instance to this
			instance = this;
		}
		// if instance already exists and it's not this:
		else if (instance != this) 
		{
			// Then destory this. This enforces our singleton pattern
			// meaning that there can only ever be one instance of GameManager
			Destroy (gameObject);
		}

		// Set this to not be destroyed when reloading a scene
		DontDestroyOnLoad (gameObject);



	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < NumberOfEnemies; i++) {
			var prefab = Resources.Load<GameObject> ("EnemyObject");
			var instance = Object.Instantiate (prefab);
			instance.transform.position += instanceOffset;
			instanceOffset += EnemySpawnOffset;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
