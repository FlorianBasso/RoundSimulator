using UnityEngine;
using System.Collections;

public class RotateRobot : MonoBehaviour {
	public float rotateValue = 2.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up * rotateValue * Time.deltaTime);
	}
}
