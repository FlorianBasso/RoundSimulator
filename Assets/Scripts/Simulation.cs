using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Simulation : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject explosionPrefab;
	private GameObject mainCamera;
	private int currentIndexMarker = 1;
	private GameObject currentMarker;
	private Vector3 currentTargetPosition;
	private ArrayList markersArray;
	private ArrayList lightsArray = new ArrayList();
	private ArrayList musicsArray = new ArrayList();

	//MAIL
	private MailMessage mail;
	private SmtpClient smtpServer;

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
					StopAllAudioSources();
					RemoveAllLights();
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
			currentTargetPosition = currentMarker.transform.position;
			this.GetComponent<Actor>().MoveOrder(currentTargetPosition);
			currentIndexMarker = 0;
		}
		else
		{
			//Move to the position of the marker
			currentMarker = markersArray[currentIndexMarker] as GameObject;
			float X = currentMarker.transform.position.x;
			float Z = currentMarker.transform.position.z;
			currentTargetPosition = new Vector3(X, this.transform.position.y, Z);
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
		musicsArray.Add (currentMarker);
		currentMarker.GetComponent<AudioSource> ().Play ();
	}
	void SendEmail()
	{
		mail = new MailMessage();
		
		mail.From = new MailAddress("jpzerobot@gmail.com");
		mail.To.Add("basso.florian@gmail.com");
		mail.To.Add ("alainlioret@gmail.com");
		mail.Subject = "Report Security Robot"; 
		mail.Body = "Everything is fine ! Don't worry Lord, I will protect your house at any price! \n \n Jean Pierre Ze Robot ";
		
		smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("jpzerobot@gmail.com", "JP1990ZeRobot289") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
//		smtpServer.Send (mail);
		smtpServer.SendAsync (mail, "userToken");
//		StartCoroutine ("SendEmailAsync");
		Debug.Log("success");
	}
	IEnumerator SendEmailAsync()
	{
		smtpServer.Send(mail);
		yield return null;
	}
	void Explode()
	{
		GameObject exp = Instantiate (explosionPrefab, this.transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 10); 	
	}

	//LIGHTS ARRAY MANAGEMENT
	void RemoveAllLights()
	{
		Debug.Log (lightsArray.Count);
		for(int i = 0; i < lightsArray.Count; i++)
		{
			DestroyImmediate(lightsArray[i] as Object, true);
		}
		lightsArray.Clear();
	}
	// MUSICS ARRAY MANAGEMENT
	void StopAllAudioSources()
	{
		for(int i = 0; i < musicsArray.Count; i++)
		{
			GameObject anAudioSource = musicsArray[i] as GameObject;
			anAudioSource.GetComponent<AudioSource> ().Stop ();
		}
		lightsArray.Clear();
	}
}
