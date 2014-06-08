using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	RaycastHit hit;
	bool leftClickFlag = true;
	
	public GameObject actor;
	public string floorTag;
	
	Actor actorScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		/***Left Click****/

		if (actor) 
		{
			if (Input.GetKey(KeyCode.Mouse0) && leftClickFlag)
				leftClickFlag = false;
			
			if (!Input.GetKey(KeyCode.Mouse0) && !leftClickFlag)
			{
				leftClickFlag = true;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 100))
				{
					if (hit.transform.tag == floorTag)
					{
						float X = hit.point.x;
						float Z = hit.point.z;
						Vector3 target = new Vector3(X, actor.transform.position.y, Z);
						
						actor.GetComponent<Actor>().MoveOrder(target);
					}
				}
			}
		}

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
