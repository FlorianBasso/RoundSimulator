using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {
	//PREFABS
	public GameObject cube;
	public GameObject sphere;
	public GameObject robot;
	public GameObject startSpawn;
	public GameObject explode;
	public GameObject goUp;
	public GameObject goDown;
	public GameObject lightOn;
	public GameObject lockDown;
	public GameObject PlayMusic;
	public GameObject sendEmail;
	public GameObject turnLeft;
	public GameObject turnRight;
	//BUTTONS INTERFACE
	public Rect windowObstacle;
	public Rect windowRobot;
	public Rect windowMarkers;
	public Rect windowSimulation;
	public float robotSpeed = 5.0f;
	public float simulationSpeed = 5.0f;
	static public bool isOnGUI = false;

	// Use this for initialization
	void Start () {
//		OBJ.Instance.Start("../Wall-E pack/Wall-E MediumPoly/Wall-E.obj", Vector3.zero, () =>
//		                   {
//			// DO whatever you want on this callback 
//			
//		});
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (windowObstacle.Contains (Input.mousePosition) || windowRobot.Contains (Input.mousePosition) || windowMarkers.Contains (Input.mousePosition) || windowSimulation.Contains (Input.mousePosition)) {
			isOnGUI = true;
			robot.GetComponent<FPSInputControllerC>().speed = robotSpeed;
		}
		else 
		{
			isOnGUI = false;
		}
	}

	void OnGUI()
	{	
		windowObstacle = GUI.Window(0, windowObstacle, setWindowObstacle, "Obstacles");
		windowRobot = GUI.Window(1, windowRobot, setWindowRobot, "Robot");
		windowMarkers = GUI.Window(2, windowMarkers, setWindowMarkers, "Markers");
		windowSimulation = GUI.Window(3, windowSimulation, setWindowSimulation, "Simulation");
	}	
	
	void setWindowObstacle(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Cube"))
		{
			Instantiate(cube, new Vector3(0,0.5f,0), Quaternion.identity);
		}
		
		if (GUI.Button(new Rect(10, 50, 100, 20), "Sphere"))
		{
			Instantiate(sphere, new Vector3(0,0.5f,0), Quaternion.identity);
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void setWindowRobot(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Starting Point"))
		{
			Instantiate(startSpawn, new Vector3(0,0.5f,0), Quaternion.identity);
		}
		//ROBOT SPEED
		Rect rectLabelRobotSpeed = new Rect(10, 50, 100, 30);
		Rect rectRobotSpeed = new Rect(10, 80, 100, 30);
		GUI.Label(rectLabelRobotSpeed, "Robot speed");
		robotSpeed = GUI.HorizontalSlider(rectRobotSpeed, robotSpeed, 1.0f, 10.0f);
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void setWindowMarkers(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Turn Left"))
		{
			Instantiate(turnLeft, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 50, 100, 20), "Go Up"))
		{
			Instantiate(goUp, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 80, 100, 20), "Go Down"))
		{
			Instantiate(goDown, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 110, 100, 20), "Turn Right"))
		{
			Instantiate(turnRight, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));	
		}
		if (GUI.Button(new Rect(10, 140, 100, 20), "Explode"))
		{
			Instantiate(explode, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 170, 100, 20), "Put The Light On"))
		{
			Instantiate(lightOn, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 200, 100, 20), "Lock Down"))
		{
			Instantiate(lockDown, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 230, 100, 20), "Play Music"))
		{
			Instantiate(PlayMusic, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
		}
		if (GUI.Button(new Rect(10, 260, 100, 20), "Send Email"))
		{
			Instantiate(sendEmail, new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
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
			
		}
		if (GUI.Button(new Rect(10, 80, 100, 20), "Forward"))
		{
			
		}
		if (GUI.Button(new Rect(10, 110, 100, 20), "Stop"))
		{
			
		}
		//SIMULATION SPEED
		Rect rectLabelSimulationSpeed = new Rect(10, 140, 100, 30);
		Rect rectSimulationSpeed = new Rect(10, 170, 100, 30);
		GUI.Label(rectLabelSimulationSpeed, "Simulation speed");
		simulationSpeed = GUI.HorizontalSlider(rectSimulationSpeed, simulationSpeed, 10.0f, 30.0f);
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
}
