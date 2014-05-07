using UnityEngine;
using System.Collections;

public class ResizeWithScreenHeight : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Get the screen height and set localScale
		float height = Camera.main.orthographicSize * 2.0f;
		transform.localScale = new Vector3(transform.localScale.x,height,transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
