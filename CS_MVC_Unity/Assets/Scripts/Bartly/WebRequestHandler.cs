using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestHandler : MonoBehaviour {

	public event Action OnLoadedEvent;
	[HideInInspector]
	public string dataString = "";
	[HideInInspector]
	public string originalPath;

	/// <summary>
	/// Gets the data from URL path specified and invokes a Callback function
	/// once the request has completed.
	/// </summary>
	/// <param name="urlPath">URL path.</param>
	/// <param name="NewCallBackFunction">New call back function.</param>
	public void GetDataFromURL(string urlPath)
	{
		originalPath = urlPath;
		StartCoroutine(GetData(urlPath));
	}

	/// <summary>
	/// Gets the data from the URL path and calls a Callback function once
	/// www.isDone returns true.
	/// </summary>
	/// <returns>The data.</returns>
	/// <param name="urlPath">URL path.</param>
	IEnumerator GetData(string urlPath)
	{
		UnityWebRequest www = UnityWebRequest.Get (urlPath);
		www.downloadHandler = new DownloadHandlerBuffer ();
		yield return www.Send ();

		Debug.Log ("WebRequestHandler[GetDataFromURL] progress: " + www.downloadProgress);

		if (www.isError) 
		{
			Debug.Log ("Web Request Error: " + www.error);
		}
		else if (www.isDone)
		{
			dataString = www.downloadHandler.text;
			Debug.Log ("WebRequestHandler[GetDataFromURL] request results: " + dataString);
			if (OnLoadedEvent != null)
				OnLoadedEvent ();
		}
	}

}
