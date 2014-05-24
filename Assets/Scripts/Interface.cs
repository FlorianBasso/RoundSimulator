using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {


	public Rect windowObstacle;
	public Rect windowRobot;
	public Rect windowMarkers;
	public Rect windowSimulation;
	public float robotSpeed = 5.0f;
	public float simulationSpeed = 5.0f;
	static public bool isOnGUI = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (windowObstacle.Contains (Input.mousePosition) || windowRobot.Contains (Input.mousePosition) || windowMarkers.Contains (Input.mousePosition) || windowSimulation.Contains (Input.mousePosition)) {
			isOnGUI = true;
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

		}
		
		if (GUI.Button(new Rect(10, 50, 100, 20), "Sphere"))
		{
		
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void setWindowRobot(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Starting Point"))
		{
			
		}
		//ROBOT SPEED
		Rect rectLabelRobotSpeed = new Rect(10, 50, 100, 30);
		Rect rectRobotSpeed = new Rect(10, 80, 100, 30);
		GUI.Label(rectLabelRobotSpeed, "Robot speed");
		robotSpeed = GUI.HorizontalSlider(rectRobotSpeed, robotSpeed, 10.0f, 30.0f);
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void setWindowMarkers(int windowID) 
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Turn Left"))
		{
			
		}
		if (GUI.Button(new Rect(10, 50, 100, 20), "Go Forward"))
		{
			
		}
		if (GUI.Button(new Rect(10, 80, 100, 20), "Turn Right"))
		{
			
		}
		if (GUI.Button(new Rect(10, 110, 100, 20), "Explode"))
		{
			
		}
		if (GUI.Button(new Rect(10, 140, 100, 20), "Put The Light On"))
		{
			
		}
		if (GUI.Button(new Rect(10, 170, 100, 20), "Lock Down"))
		{
			
		}
		if (GUI.Button(new Rect(10, 200, 100, 20), "Play Music"))
		{
			
		}
		if (GUI.Button(new Rect(10, 230, 100, 20), "Send Email"))
		{
			
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
