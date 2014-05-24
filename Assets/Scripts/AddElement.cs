using UnityEngine;
using System.Collections;

public class AddElement : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject dd_object;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        Camera cam = GameObject.FindGameObjectWithTag("CameraTOP").camera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (collider.Raycast(ray, out hit, 1000f))
        {
            switch (hit.collider.name.ToString())
            {
                case "icon_cube":
                    GameObject cubePrefab = Resources.Load("Cube") as GameObject;
                    dd_object = GameObject.Instantiate(cubePrefab) as GameObject;
                    break;
                case "icon_explode":
                    dd_object = new GameObject();
                    break;

                case "icon_goForward":
                    dd_object = new GameObject();
                    break;
                case "icon_ligth":
                    dd_object = new GameObject();
                    break;
                case "icon_lockDown":
                    dd_object = new GameObject();
                    break;

                case "icon_pleyMusic":
                    dd_object = new GameObject();
                    break;

                case "icon_sendEmail":
                    dd_object = new GameObject();
                    break;
                case "icon_sphere":
                    GameObject spherePrefab = Resources.Load("Sphere") as GameObject;
                    dd_object = GameObject.Instantiate(spherePrefab) as GameObject;
                    break;
                case "icon_startPlace":
                    dd_object = new GameObject();
                    break;

                case "icon_turnLeft":
                    dd_object = new GameObject();
                    break;
                case "icon_turnRight":
                    dd_object = new GameObject();
                    break;
            }
            Vector3 posInWorld = cam.ScreenToWorldPoint(Input.mousePosition);

            dd_object.transform.position = new Vector3(posInWorld.x, 0.5f, posInWorld.z);
        }
    }

    void OnMouseDrag() { }
}
