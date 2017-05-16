using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XmlParsing : MonoBehaviour {

	public event Action OnScheduleParsed;

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
		XmlNodeList routeNode = root.GetElementsByTagName ("route");

		foreach (XmlNode el in routeNode[0].ChildNodes) 
		{
			GameObject Train = new GameObject ();
			Train.AddComponent<TrainSchedule> ();
			Train.name = "Train" + el.Attributes ["trainId"].Value;
			TrainSchedule trainSchedule = Train.GetComponent<TrainSchedule>();
			trainSchedule.routeName = "PITT-SFIA";
			trainSchedule.routeNumber = 1;
			trainSchedule.trainId = int.Parse(el.Attributes ["trainId"].Value);
			trainSchedule.trainIdx = int.Parse(el.Attributes ["trainIdx"].Value);
			Debug.Log ("trainId: " + trainSchedule.trainId + " \ttrainIdx: " + trainSchedule.trainIdx);
			XmlNodeList trainStops = el.ChildNodes;
			foreach (XmlNode Tstop in trainStops) 
			{
				if (Tstop.Attributes ["origTime"] != null) 
				{
					string stringTime = Tstop.Attributes ["origTime"].Value;
					string stationName = Tstop.Attributes ["station"].Value;
					Debug.Log("station: " + stationName + "\t time: " + stringTime);
					DateTime depTime = DateTime.ParseExact (stringTime, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
					TrainStop trainStop = new TrainStop (stationName, depTime);
					trainSchedule.AddStop (trainStop);

				}
			}
			Debug.Log ("trainschedule stops: " + trainSchedule.trainStops.ToString ());
		}
		if (OnScheduleParsed != null)
			OnScheduleParsed ();
	}
}
