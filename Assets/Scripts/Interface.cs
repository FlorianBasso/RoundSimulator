using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	//GAMEOBJECT IN THE SCENE 
	private GameObject startSpawn;
	private GameObject robot;
	//BUTTONS INTERFACE
	public Rect windowObstacle;
	public Rect windowRobot;
	public Rect windowMarkers;
	public Rect windowSimulation;
	public float robotSpeed = 5.0f;
	public float simulationSpeed = 5.0f;
	static public bool isOnGUI = false;
	public bool simulationIsRunning = false;
	public GUISkin mainSkin;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		OBJ.Instance.Start("../Wall-E pack/Wall-E MediumPoly/cube.obj", Vector3.zero, () =>
		                 {
			// DO whatever you want on this callback 
			Debug.Log("fefz");
			
		});
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (windowObstacle.Contains (Input.mousePosition) || windowRobot.Contains (Input.mousePosition) || windowMarkers.Contains (Input.mousePosition) || windowSimulation.Contains (Input.mousePosition)) {
			isOnGUI = true;
			if(robot)
				robot.GetComponent<Actor>().m_speed_multi = robotSpeed;
		}
		else 
		{
			isOnGUI = false;
		}
		//Change Camera
		if(robot)
		{
			if(Input.GetKeyDown(KeyCode.C))
			{
				Debug.Log("PRESS C");
				this.camera.enabled = (this.camera.enabled ? false : true);
				robot.GetComponentInChildren<Camera>().enabled = (robot.GetComponentInChildren<Camera>().enabled ? false : true);
			}
		}
	}

	void OnGUI()
	{	
		GUI.skin = mainSkin;
		//GO BACK to MENU 
		if (GUI.Button(new Rect(0, 0, 50, 20), "Menu"))
		{
			Application.LoadLevel(0);
		}
		//CLOSE APPLICATION
		if (GUI.Button(new Rect(Screen.width - 50, 0, 50, 20), "Close"))
		{
			Application.Quit();
		}
		if (!simulationIsRunning) 
		{
			if(startSpawn)
				windowMarkers = GUI.Window(2, windowMarkers, setWindowMarkers, "Markers");

			windowObstacle = GUI.Window(0, windowObstacle, setWindowObstacle, "Obstacles");
		}
		windowRobot = GUI.Window(1, windowRobot, setWindowRobot, "Robot");
		if(startSpawn)
			windowSimulation = GUI.Window(3, windowSimulation, setWindowSimulation, "Simulation");
	}	
	
	void setWindowObstacle(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Chair"))
		{
			Instantiate(Resources.Load("chair_7106"), new Vector3(0,0,0), Quaternion.Euler(-90, 0, 0));
		}
		
		if (GUI.Button(new Rect(10, 50, 100, 20), "Table"))
		{
			Instantiate(Resources.Load("table_7103"), new Vector3(0,0,0), Quaternion.Euler(-90, 0, 0));
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void setWindowRobot(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Starting Point"))
		{
			if(!startSpawn)
			{
				startSpawn = Instantiate(Resources.Load("StartSpawn"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
				this.GetComponent<Manager>().AddObjectInMarkersArray(startSpawn);
			}
		}

		//ROBOT SPEED
		Rect rectLabelRobotSpeed = new Rect(10, 50, 100, 30);
		Rect rectRobotSpeed = new Rect(10, 80, 100, 30);
		GUI.Label(rectLabelRobotSpeed, "Robot speed");
		robotSpeed = GUI.HorizontalSlider(rectRobotSpeed, robotSpeed, 1.0f, 30.0f);
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void setWindowMarkers(int windowID) 
	{
		GameObject aMarker;
		if (GUI.Button(new Rect(10, 20, 100, 20), "Node"))
		{
			aMarker = Instantiate(Resources.Load("Node"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 50, 100, 20), "Explode"))
		{
			aMarker = Instantiate(Resources.Load("Explode"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 80, 100, 20), "Light On"))
		{
			aMarker = Instantiate(Resources.Load("LightOn"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 110, 100, 20), "Lock Down"))
		{
			aMarker = Instantiate(Resources.Load("LockDown"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 140, 100, 20), "Play Music"))
		{
			aMarker = Instantiate(Resources.Load("PlayMusic"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 170, 100, 20), "Send Email"))
		{
			aMarker = Instantiate(Resources.Load("SendEmail"), new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));	
	}

	void setWindowSimulation(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Rewind"))
		{
			
		}
		if (GUI.Button(new Rect(10, 50, 100, 20), "Play"))
		{
			if(startSpawn)
			{
				robot = Instantiate(Resources.Load("Robot"), startSpawn.transform.position, Quaternion.identity) as GameObject;
				this.camera.enabled = false;
				robot.GetComponentInChildren<Camera>().enabled = true;
				this.GetComponent<CameraControl>().actor = robot;
				simulationIsRunning = true;
			}
		}
		if (GUI.Button(new Rect(10, 80, 100, 20), "Forward"))
		{
			
		}
		if (GUI.Button(new Rect(10, 110, 100, 20), "Stop"))
		{
			StopSimulation();
		}
		//SAVE
		if (GUI.Button(new Rect(10, 140, 100, 20), "Save"))
		{
			//Add a prompt where the user can enter a name for the save then click ok OR cancel
		}

		//SIMULATION SPEED
//		Rect rectLabelSimulationSpeed = new Rect(10, 140, 100, 30);
//		Rect rectSimulationSpeed = new Rect(10, 170, 100, 30);
//		GUI.Label(rectLabelSimulationSpeed, "Simulation speed");
//		simulationSpeed = GUI.HorizontalSlider(rectSimulationSpeed, simulationSpeed, 10.0f, 30.0f);

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	public void StopSimulation()
	{
		DestroyImmediate(robot, true);
		this.camera.enabled = true;
		simulationIsRunning = false;

		//Enabled all markers' collider
		for (int i = 0; i < this.GetComponent<Manager>().markersArray.Count; i++) 
		{
			GameObject aMarker = this.GetComponent<Manager>().markersArray[i] as GameObject;
			aMarker.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
