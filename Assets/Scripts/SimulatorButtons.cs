using UnityEngine;
using System.Collections;

public class SimulatorButtons : MonoBehaviour {

    public Sprite play;
    public Sprite pause;
    private Camera top;
    private Camera fps;
    private bool isPlaying;
    private SpriteRenderer[] allSprites;
    public GameObject sprite_play;
	// Use this for initialization
	void Start () {
        isPlaying = false;
        top = GameObject.FindGameObjectWithTag("CameraTOP").camera;
        fps = GameObject.FindGameObjectWithTag("CameraFPS").camera;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                switch(hit.collider.name)
                {
                    //    ICON PLAY   ///////////////
                    case "icon_play":
                        if (isPlaying)
                        {
                            isPlaying = false;
                            top.enabled = true;
                            fps.enabled = false;
                            sprite_play.GetComponent<SpriteRenderer>().sprite = play;
                        }
                        else
                        {
                            isPlaying = true;
                            top.enabled = false;
                            fps.enabled = true;
                            sprite_play.GetComponent<SpriteRenderer>().sprite = pause;
                        }
                        break;
                    /////////////////////////////////

                    //    ICON STOP   ///////////////
                    case "icon_stop":
                        if (isPlaying)
                        {
                            isPlaying = false;
                            top.enabled = true;
                            fps.enabled = false;
                            sprite_play.GetComponent<SpriteRenderer>().sprite = play;
                        }
                        break;
                    /////////////////////////////////
                }
            }
        }
	}

    void OnMouseDown()
    {        
        
    }
}
