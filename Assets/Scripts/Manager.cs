﻿using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Collections;

public class Manager : MonoBehaviour {

	public ArrayList markersArray = new ArrayList();
	public ArrayList obstaclesArray = new ArrayList();
	public LineRenderer lineRenderer;

    private float x, y, z;
    private string name;

	// Use this for initialization
	void Start () {
//		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(Color.red, Color.red);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (markersArray.Count > 0) 
		{
			lineRenderer.enabled = true;
			lineRenderer.SetVertexCount(markersArray.Count);
			int i = 0;
			while (i < markersArray.Count) 
			{
				GameObject aMarker = markersArray[i] as GameObject;
				lineRenderer.SetPosition(i, aMarker.transform.position);
				i++;
			}
		}
	}
	//MARKERS ARRAY MANAGEMENT
	public void RemoveObjectInMarkersArray(GameObject anObject){
		for(int i = 0; i < markersArray.Count; i++){
			if(anObject.Equals(markersArray[i])){
				markersArray.RemoveAt(i);
			}
		}
	}
	public void AddObjectInMarkersArray(GameObject anObject){
		markersArray.Add (anObject);
	}
	//OBSTACLES ARRAY MANAGEMENT
	public void RemoveObjectInObstaclesArray(GameObject anObject){
		for(int i = 0; i < obstaclesArray.Count; i++){
			if(anObject.Equals(obstaclesArray[i])){
				obstaclesArray.RemoveAt(i);
			}
		}
	}
	public void AddObjectInObstaclesArray(GameObject anObject){
		obstaclesArray	.Add (anObject);
	}

	//SAVE MANAGEMENT
	public void SaveRound(string fileName)
	{
		//Create file and really save :D
        XmlWriter w;
        Debug.Log(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        if (File.Exists(String.Format("{0}{1}", Application.dataPath.ToString(), fileName)))
            File.Delete(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        w = XmlWriter.Create(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        w.WriteStartDocument();
        w.WriteStartElement("Elements"); w.WriteWhitespace("\n");
        w.WriteStartElement("Markers"); w.WriteWhitespace("\n");
        foreach (GameObject m in markersArray)
        {
            w.WriteStartElement("marker");
            w.WriteElementString("name", m.name.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posX", m.transform.position.x.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posY", m.transform.position.y.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posZ", m.transform.position.z.ToString()); w.WriteWhitespace("\n");
            w.WriteEndElement();
            w.WriteWhitespace("\n");
        }
        w.WriteEndElement(); w.WriteWhitespace("\n");

        w.WriteStartElement("Obstacles"); w.WriteWhitespace("\n");
        foreach (GameObject o in obstaclesArray)
        {
            w.WriteStartElement("obstacle");
            w.WriteElementString("name", o.name.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posX", o.transform.position.x.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posY", o.transform.position.y.ToString()); w.WriteWhitespace("\n");
            w.WriteElementString("posZ", o.transform.position.z.ToString()); w.WriteWhitespace("\n");
            w.WriteEndElement();
            w.WriteWhitespace("\n");
        }
        w.WriteEndElement(); w.WriteWhitespace("\n");

        w.WriteEndElement(); w.WriteWhitespace("\n");
        w.WriteEndDocument();
	}
}
