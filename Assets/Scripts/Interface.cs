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
	private Rect windowSave;
	private Rect windowLoad;
	public float robotSpeed = 5.0f;
	public float simulationSpeed = 5.0f;
	static public bool isOnGUI = false;
	public bool simulationIsRunning = false;
	private bool isSaving = false;
	private bool isLoading = false;
	private string saveFileName = "Round1";
	public GUISkin mainSkin;
	public float buttonsWidth;
	public float buttonsHeight;

	// Use this for initialization
	void Start () {

		windowSave = new Rect (Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 100);
		windowLoad = new Rect (Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 100);
//		OBJ.Instance.Start("../Wall-E pack/Wall-E MediumPoly/cube.obj", Vector3.zero, () =>
//		                 {
//			// DO whatever you want on this callback 
//			Debug.Log("fefz");
//		});
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
				this.camera.enabled = (this.camera.enabled ? false : true);
				robot.GetComponentInChildren<Camera>().enabled = (robot.GetComponentInChildren<Camera>().enabled ? false : true);
				this.GetComponent<AudioListener>().enabled = (this.GetComponent<AudioListener>().enabled ? false : true);
				robot.GetComponent<AudioListener>().enabled = (robot.GetComponent<AudioListener>().enabled ? false : true);
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
		//WINDOWS
		if (!simulationIsRunning) 
		{
			if(startSpawn)
				windowMarkers = GUI.Window(2, windowMarkers, setWindowMarkers, "Markers");

			windowObstacle = GUI.Window(0, windowObstacle, setWindowObstacle, "Obstacles");
		}
		windowRobot = GUI.Window(1, windowRobot, setWindowRobot, "Robot");
		if (startSpawn) 
		{
			windowSimulation = GUI.Window(3, windowSimulation, setWindowSimulation, "Simulation");
			if (isSaving)
				windowSave = GUI.Window (4, windowSave, setWindowSave, "Save file");
			if (isLoading)
				windowLoad = GUI.Window (4, windowLoad, setWindowLoad, "Load file");
		}
	}	
	
	void setWindowObstacle(int windowID) 
	{
		GameObject anObstacle;
		if (GUI.Button(new Rect(10, 20, buttonsWidth, buttonsHeight), "Chair"))
		{
			anObstacle =  Instantiate(Resources.Load("chair_7106"), new Vector3(0,0,0), Quaternion.Euler(-90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInObstaclesArray(anObstacle);

		}
		if (GUI.Button(new Rect(10, 50, buttonsWidth, buttonsHeight), "Table"))
		{
			anObstacle = Instantiate(Resources.Load("table_7103"), new Vector3(0,0,0), Quaternion.Euler(-90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInObstaclesArray(anObstacle);
		}
		if (GUI.Button(new Rect(10, 80, buttonsWidth, buttonsHeight), "Couch"))
		{
			anObstacle = Instantiate(Resources.Load("Couch"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
			this.GetComponent<Manager>().AddObjectInObstaclesArray(anObstacle);
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void setWindowRobot(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, buttonsWidth, buttonsHeight), "Starting Point"))
		{
			if(!startSpawn)
			{
				startSpawn = Instantiate(Resources.Load("StartSpawn"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
				this.GetComponent<Manager>().AddObjectInMarkersArray(startSpawn);
			}
		}

		//ROBOT SPEED
		Rect rectLabelRobotSpeed = new Rect(10, 50, buttonsWidth, 30);
		Rect rectRobotSpeed = new Rect(10, 80, buttonsWidth, 30);
		GUI.Label(rectLabelRobotSpeed, "Robot speed");
		robotSpeed = GUI.HorizontalSlider(rectRobotSpeed, robotSpeed, 1.0f, 30.0f);
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void setWindowMarkers(int windowID) 
	{
		GameObject aMarker;
		if (GUI.Button(new Rect(10, 20, buttonsWidth, buttonsHeight), "Node"))
		{
			aMarker = Instantiate(Resources.Load("Node"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 50, buttonsWidth, buttonsHeight), "Explode"))
		{
			aMarker = Instantiate(Resources.Load("Explode"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 80, buttonsWidth, buttonsHeight), "Light On"))
		{
			aMarker = Instantiate(Resources.Load("LightOn"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 110, buttonsWidth, buttonsHeight), "Lock Down"))
		{
			aMarker = Instantiate(Resources.Load("LockDown"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 140, buttonsWidth, buttonsHeight), "Play Music"))
		{
			aMarker = Instantiate(Resources.Load("PlayMusic"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}
		if (GUI.Button(new Rect(10, 170, buttonsWidth, buttonsHeight), "Send Email"))
		{
			aMarker = Instantiate(Resources.Load("SendEmail"), new Vector3(0,0.1f,0), Quaternion.Euler(90, 0, 0)) as GameObject;
			this.GetComponent<Manager>().AddObjectInMarkersArray(aMarker);
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));	
	}

	void setWindowSimulation(int windowID) 
	{
		//PLAY
		if (GUI.Button(new Rect(10, 20, buttonsWidth, buttonsHeight), "Play"))
		{
			if(startSpawn && !robot)
			{
				robot = Instantiate(Resources.Load("Robot"), startSpawn.transform.position, Quaternion.identity) as GameObject;
				this.camera.enabled = false;
				this.GetComponent<AudioListener> ().enabled = false;
				this.GetComponent<CameraControl>().actor = robot;
				robot.GetComponentInChildren<Camera>().enabled = true;
				robot.GetComponent<AudioListener> ().enabled = true;
				simulationIsRunning = true;
			}
		}
		//STOP
		if (GUI.Button(new Rect(10, 50, buttonsWidth, buttonsHeight), "Stop"))
		{
			StopSimulation();
		}
		//SAVE
		if (GUI.Button(new Rect(10, 80, buttonsWidth, buttonsHeight), "Save"))
		{
			isSaving = true;
		}
		//LOAD
		if (GUI.Button(new Rect(10, 110, buttonsWidth, buttonsHeight), "Load"))
		{
			isLoading = true;
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	void setWindowSave (int windowID)
	{
		saveFileName = GUI.TextField(new Rect(10, 30, 280, 20), saveFileName, 25);
		if (GUI.Button (new Rect (10, 60, 280, buttonsHeight), "Done")) 
		{
			isSaving = false;
			this.GetComponent<Manager>().SaveRound(saveFileName);
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	void setWindowLoad (int windowID)
	{
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	public void StopSimulation()
	{
		DestroyImmediate(robot, true);
		this.camera.enabled = true;
		this.GetComponent<AudioListener> ().enabled = true;
		simulationIsRunning = false;

		for(int i = 0; i < this.GetComponent<Manager>().markersArray.Count; i++)
		{
			GameObject anObject = this.GetComponent<Manager>().markersArray[i] as GameObject;
			anObject.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
