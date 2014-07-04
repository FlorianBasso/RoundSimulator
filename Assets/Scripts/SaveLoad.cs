using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveLoad
{
    public GameObject mainCamera;

    private ArrayList markers = new ArrayList();
    private ArrayList obstacles = new ArrayList();
    private float x, y, z;
    private string name;

    public void Start()
    {
    }

    public void SaveRound(string fileName)
    {
        XmlWriter w;
        markers = mainCamera.GetComponent<Manager>().markersArray;
        obstacles = mainCamera.GetComponent<Manager>().obstaclesArray;

        Debug.Log(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        if (File.Exists(String.Format("{0}{1}", Application.dataPath.ToString(), fileName)))
            File.Delete(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        w = XmlWriter.Create(String.Format("{0}{1}", Application.dataPath.ToString(), fileName));

        w.WriteStartDocument();
        w.WriteStartElement("Elements"); w.WriteWhitespace("\n");
        w.WriteStartElement("Markers"); w.WriteWhitespace("\n");
        foreach (GameObject m in markers)
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
        foreach (GameObject o in obstacles)
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

    public void LoadRound(string fileName)
    {
        XmlDocument d = new XmlDocument();
        d.Load(Application.dataPath + fileName);

        XmlNodeList allMarkersNode = d.GetElementsByTagName("marker");
        Debug.Log(allMarkersNode.Count);
        foreach (XmlNode marker in allMarkersNode)
        {
            XmlNodeList infos = marker.ChildNodes;
            name = infos[0].InnerText;
            x = float.Parse(infos[1].InnerText);
            y = float.Parse(infos[2].InnerText);
            z = float.Parse(infos[3].InnerText);
            GameObject prefab = Resources.Load(name) as GameObject;
            GameObject markObject = GameObject.Instantiate(prefab) as GameObject;
            markObject.transform.position = new Vector3(x, y, z);
        }

        XmlNodeList allObstaclesNode = d.GetElementsByTagName("obstacle");
        foreach (XmlNode obstacle in allObstaclesNode)
        {
            XmlNodeList infos = obstacle.ChildNodes;
            name = infos[0].InnerText;
            x = float.Parse(infos[1].InnerText);
            y = float.Parse(infos[2].InnerText);
            z = float.Parse(infos[3].InnerText);
            GameObject prefab = Resources.Load(name) as GameObject;
            GameObject obstacleObject = GameObject.Instantiate(prefab) as GameObject;
            obstacleObject.transform.position = new Vector3(x, y, z);
        }
    }
}
