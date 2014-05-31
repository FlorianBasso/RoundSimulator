using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public ArrayList markersArray = new ArrayList();
	public LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
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
}
