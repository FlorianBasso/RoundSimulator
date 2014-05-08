using UnityEngine;
using System.Collections;

public class Traveler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    for(float x = -4.9f; x < 5f; x+=0.1f)
        {
            for(float z = 4.9f; z < 5f; z -= 0.1f)
            {
                transform.position=new Vector3(x, 0.1f, z);
            }
        }
	}
}
