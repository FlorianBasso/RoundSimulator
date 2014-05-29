using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject test;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//ZOOM 
		float zoom = Input.GetAxis("Mouse ScrollWheel");
		if(zoom >= 0.1)
		{
			this.transform.Translate(Vector3.forward * Time.deltaTime * 200);  
		}	
		//DEZOOM
		else if(zoom <= -0.1)
		{
			this.transform.Translate(-Vector3.forward * Time.deltaTime * 200); 
		}

		//DRAG CAMERA
		if(Input.GetButton("Fire2")) //&& Interface.isOnGUI == false) 
		{
			Vector3 CameraPos;
			
			float MouseX;
			float MouseY;
			
			MouseX = Input.GetAxis("Mouse X");
			MouseY = Input.GetAxis("Mouse Y");
			CameraPos = new Vector3(- MouseX, 0, - MouseY);
			
			this.transform.position += CameraPos;
		}
	}
}
