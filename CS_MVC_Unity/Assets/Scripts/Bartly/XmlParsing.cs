using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XmlParsing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public XmlDocument LoadXmlDoc(string xmldata)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (xmldata);
		return xmlDoc;
	}

	public void parseXml(string xmldata)
	{
		XmlDocument doc = LoadXmlDoc (xmldata);
		XmlElement root = doc.DocumentElement;
		foreach (XmlNode node in root.ChildNodes) 
		{
			Debug.Log ("node: " + node.Name);
			if (node.Name == "station") 
			{
				XmlNode stationName = node.FirstChild;
				Debug.Log ("station name: " + stationName.InnerXml);
			} 
			else if (node.Name == "uri") 
			{
				Debug.Log ("CDATA: " + node.InnerXml);
				if (node.InnerXml.Contains("cmd=etd"))
				{
					Debug.Log("This is a Realtime Departure list");
				} 
				else if (node.InnerXml.Contains("cmd=routesched"))
				{
					Debug.Log("This is a route schedule");
					TrainScheduleFromXml (root);
				}

			}
		}
	}

	public void TrainScheduleFromXml(XmlElement root)
	{
		List<DateTime> timeList = new List<DateTime> ();
		XmlNodeList routeNode = root.GetElementsByTagName ("route");
		foreach (XmlNode el in routeNode[0].ChildNodes) 
		{
			Debug.Log ("el: " + el.Name);
			XmlNodeList trainStops = el.ChildNodes;
			foreach (XmlNode Tstop in trainStops) 
			{
				if (Tstop.Attributes ["origTime"] != null) 
				{
					string stringTime = Tstop.Attributes ["origTime"].Value;
					Debug.Log("station: " + Tstop.Attributes["station"].Value + "\t time: " + stringTime);
					timeList.Add (DateTime.ParseExact(stringTime, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture));

				}
			}
			Debug.Log ("delta: " + timeList [1].Subtract(timeList[0]).TotalMinutes);
		}
	}
}
