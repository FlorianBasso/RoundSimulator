using UnityEngine;
using System.Collections;

public class dragElement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        Camera cam = Camera.allCameras[0];
        Vector3 posInWorld = cam.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = new Vector3(posInWorld.x, 0.5f, posInWorld.y);
    }

    void OnMouseUp()
    {
        //Camera cam = Camera.allCameras[0];
        //Vector3 posInWorld = cam.ScreenToWorldPoint(Input.mousePosition);

        //this.transform.position = new Vector3(posInWorld.x, 0.5f, posInWorld.y);
    }
}
