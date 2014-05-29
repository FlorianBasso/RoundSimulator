using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.forward * Time.deltaTime;
	}
	//COLLISION MANAGEMENT
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.name.Contains("GoUp")) 
		{
			Debug.Log("GoUP");
		}
		else if (other.gameObject.name.Contains("GoDown")) 
		{
			Debug.Log("GoDOwn");
		}
		else if (other.gameObject.name.Contains("LightOn")) 
		{
			Debug.Log("LightOn");
		}
		else if (other.gameObject.name.Contains("LockDown")) 
		{
			Debug.Log("LockDOwn");
		}
		else if (other.gameObject.name.Contains("PlayMusic")) 
		{
			Debug.Log("PlayMusic");
		}
		else if (other.gameObject.name.Contains("SendEmail")) 
		{
			Debug.Log("SendEmail");
		}
		else if (other.gameObject.name.Contains("Explode")) 
		{
			Debug.Log("Explode");
		}
		else if (other.gameObject.name.Contains("TurnLeft")) 
		{
			Debug.Log("TurnLeft");
		}
		else if (other.gameObject.name.Contains("TurnRight")) 
		{
			Debug.Log("TurnRight");
		}
	}
	//MARKERS MANAGEMENT
	void MoveUp()
	{

	}
	void MoveDown()
	{
		
	}
	void MoveLeft()
	{
		
	}
	void MoveRight()
	{
		
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
