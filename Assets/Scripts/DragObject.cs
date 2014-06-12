using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

	Vector3 screenPoint;
	Vector3 offset;
	Color initialColor;
	GameObject mainCamera;
	private GUIText hintSpaceGUIText;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main.gameObject;
		initialColor = this.renderer.material.color;
		hintSpaceGUIText = GameObject.FindGameObjectWithTag ("hintSpace").guiText;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() 
	{
		if (!mainCamera.GetComponent<Interface> ().simulationIsRunning) 
		{
			hintSpaceGUIText.enabled = true;
			StartCoroutine("FadeIn");
			Vector3 scanPos = gameObject.transform.position;
			screenPoint = Camera.main.WorldToScreenPoint(scanPos);
			offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}	

	void OnMouseUp()
	{
		StartCoroutine("FadeOut");
		if (!mainCamera.GetComponent<Interface> ().simulationIsRunning) 
			this.renderer.material.color = initialColor;
	}
	void OnMouseDrag() 
	{
		if (!mainCamera.GetComponent<Interface> ().simulationIsRunning) 
		{
			this.renderer.material.color = Color.red;
			
			//Update object position
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
			
			//Delete object
			if (Input.GetButtonDown ("Jump")) 
			{
				if(mainCamera.GetComponent<Manager>().markersArray.Contains(this.gameObject))
					mainCamera.GetComponent<Manager>().RemoveObjectInMarkersArray(this.gameObject);
				else if(mainCamera.GetComponent<Manager>().obstaclesArray.Contains(this.gameObject))
					mainCamera.GetComponent<Manager>().RemoveObjectInObstaclesArray(this.gameObject);

				DestroyImmediate(this.gameObject, true);
			}
		}
	}
	IEnumerator FadeIn()
	{
		Debug.Log (hintSpaceGUIText.material.color.a);
		while (hintSpaceGUIText.material.color.a < 1) 
		{
			Color aColor = hintSpaceGUIText.material.color;
			aColor.a += Time.deltaTime;
			hintSpaceGUIText.material.color = aColor;
		}
		yield return null;
	}
	
	IEnumerator FadeOut()
	{
		while (hintSpaceGUIText.material.color.a >= 0) 
		{
			Color aColor = hintSpaceGUIText.material.color;
			aColor.a -= Time.deltaTime;
			hintSpaceGUIText.material.color = aColor;
		}
		yield return null;
	}
}
