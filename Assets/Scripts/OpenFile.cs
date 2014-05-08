using UnityEngine;
using System.Collections;

public class OpenFile : MonoBehaviour {

    private Texture2D texture = null;
    public Texture2D text;
    private FilePicker fp;
    public GameObject sol;
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (collider.Raycast(ray, out hit, 1000f))
            {
                    sol.renderer.material.SetTexture("_MainTex", texture);
            }
        }
	}
}
