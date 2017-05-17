using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this 'singleton' script to globally manage your game
public class BartSceneManager : MonoBehaviour 
{

	public static BartSceneManager instance = null;

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
		
	}

	// Update is called once per frame
	void Update () {

	}

}
