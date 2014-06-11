using UnityEngine;
using System.Collections;
public class RobotBehaviour : MonoBehaviour {

	public float speed = 5.0f;

	private GameObject mainCamera;
	private int currentIndexMarker = 1;
	private GameObject currentMarker;
	private Vector3 currentTargetPosition;
	private ArrayList markersArray;
	private ArrayList lightsArray = new ArrayList();

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		markersArray = mainCamera.GetComponent<Manager> ().markersArray;
		MoveToNextMarker ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mainCamera.GetComponent<Interface> ().simulationIsRunning)
		{
			if (Vector3.Distance(this.transform.position, currentTargetPosition) <= 0.2) 
			{
				if(currentMarker.name.Contains("StartSpawn"))
				{
					removeAllLights();
					mainCamera.GetComponent<Interface>().StopSimulation();
				}
				else
				{
					if (currentMarker.name.Contains("LightOn")) 
					{
						LightOn ();
						Debug.Log("LightOn");
					}
					else if (currentMarker.name.Contains("LockDown")) 
					{
						LockDown();
						Debug.Log("LockDOwn");
					}
					else if (currentMarker.name.Contains("PlayMusic")) 
					{
						PlayMusic();
						Debug.Log("PlayMusic");
					}
					else if (currentMarker.name.Contains("SendEmail")) 
					{
						SendEmail();
						Debug.Log("SendEmail");
					}
					else if (currentMarker.name.Contains("Explode")) 
					{
						Explode();
						Debug.Log("Explode");
					}
					MoveToNextMarker();
				}
			}
		}
	}

	//MARKERS MANAGEMENT
	public void MoveToNextMarker()
	{
		if (currentIndexMarker == markersArray.Count) 
		{
			//GO back to the startSpawn
			currentMarker = markersArray [0] as GameObject;
			currentMarker.GetComponent<BoxCollider> ().enabled = false;
			currentTargetPosition = currentMarker.transform.position;
			this.transform.LookAt(currentTargetPosition * Time.deltaTime);
			this.GetComponent<Actor>().MoveOrder(currentTargetPosition);
			currentIndexMarker = 0;
		}
		else
		{
			//Move to the position of the marker
			currentMarker = markersArray[currentIndexMarker] as GameObject;
			currentMarker.GetComponent<BoxCollider> ().enabled = false;
			float X = currentMarker.transform.position.x;
			float Z = currentMarker.transform.position.z;
			currentTargetPosition = new Vector3(X, this.transform.position.y, Z);
			this.transform.LookAt(currentTargetPosition * Time.deltaTime);
			this.GetComponent<Actor>().MoveOrder(currentTargetPosition);
			currentIndexMarker++;
		}
	}

	void LightOn()
	{
		GameObject lightGameObject = new GameObject("The Light");
		lightGameObject.AddComponent<Light>();
		lightGameObject.light.color = new Color( Random.value, Random.value, Random.value, 1.0f );
		lightGameObject.transform.position = new Vector3(currentMarker.transform.position.x, 5, currentMarker.transform.position.z);
		lightsArray.Add (lightGameObject);
	}
	void LockDown()
	{
		
	}
	void PlayMusic()
	{
		
	}
	void SendEmail()
	{
		
	}
	void Explode()
	{
		
	}

	//LIGHTS ARRAY MANAGEMENT
	void removeAllLights()
	{
		Debug.Log (lightsArray.Count);
		Debug.Log ("IN REMOVE ALL LIGHTS");
		for(int i = 0; i < lightsArray.Count; i++)
		{
			Debug.Log ("IN LOOP IN REMOVE ALL LIGHTS");
			DestroyImmediate(lightsArray[i] as Object, true);
		}
		lightsArray.Clear();
	}
}
