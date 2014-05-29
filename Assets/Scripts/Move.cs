using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public enum Direction{Up, Right, Down, Left};
	public Direction currentDirection;
	public float speed = 5.0f;
	private bool hasCollided = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasCollided) 
		{
			switch (currentDirection) 
			{
				case Direction.Up:
					MoveUp();
					break;
				case Direction.Right:
					MoveRight();
					break;
				case Direction.Down:
					MoveDown();
					break;
				case Direction.Left:
					MoveLeft();
					break;
			}
		}
	}
	//COLLISION MANAGEMENT
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.name.Contains("GoUp")) 
		{
			currentDirection = Direction.Up;
			Debug.Log("GoUP");
		}
		else if (other.gameObject.name.Contains("GoDown")) 
		{
			currentDirection = Direction.Down;
			Debug.Log("GoDOwn");
		}
		else if (other.gameObject.name.Contains("LightOn")) 
		{
			LightOn ();
			Debug.Log("LightOn");
		}
		else if (other.gameObject.name.Contains("LockDown")) 
		{
			LockDown();
			Debug.Log("LockDOwn");
		}
		else if (other.gameObject.name.Contains("PlayMusic")) 
		{
			PlayMusic();
			Debug.Log("PlayMusic");
		}
		else if (other.gameObject.name.Contains("SendEmail")) 
		{
			SendEmail();
			Debug.Log("SendEmail");
		}
		else if (other.gameObject.name.Contains("Explode")) 
		{
			Explode();
			Debug.Log("Explode");
		}
		else if (other.gameObject.name.Contains("TurnLeft")) 
		{
			currentDirection = Direction.Left;
			Debug.Log("TurnLeft");
		}
		else if (other.gameObject.name.Contains("TurnRight")) 
		{
			currentDirection = Direction.Right;
			Debug.Log("TurnRight");
		}
		else if(other.gameObject.tag == "Obstacle")
		{
			hasCollided = true;
			Debug.Log ("COLLISION TRIGGER");	
		}
	}

	//MARKERS MANAGEMENT
	void MoveUp()
	{
		this.transform.position += Vector3.forward * Time.deltaTime * speed;
		this.transform.localEulerAngles = Vector3.zero;
	}
	void MoveDown()
	{
		this.transform.position -= Vector3.forward  * Time.deltaTime * speed;
		this.transform.localEulerAngles = new Vector3(0, 180, 0);
	}
	void MoveLeft()
	{
		this.transform.position -= Vector3.right * Time.deltaTime * speed;
		this.transform.localEulerAngles = new Vector3(0, 270, 0);
	}
	void MoveRight()
	{
		this.transform.position += Vector3.right * Time.deltaTime * speed;
		this.transform.localEulerAngles = new Vector3(0, 90, 0);
	}
	void LightOn()
	{
		
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
}
