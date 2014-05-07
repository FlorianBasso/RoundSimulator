using UnityEngine;
using System.Collections;

public class NewRound_btn : MonoBehaviour {

	public string levelToLoad;
	public Sprite normalSprite;
	public Sprite rollOverSprite;
	public Sprite clickSprite;
	public AudioClip beep;

	
	// Use this for initialization
	void Start () 
	{
//		SpriteFunctions.ResizeSpriteToScreen(this.gameObject, GameObject.FindGameObjectWithTag("MainCamera").camera, 1, 0);
//		Vector3 newPosition = new Vector3 (this.transform.position.x/Screen.width, this.transform.position.y/Screen.height, 0);
//		this.transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnMouseEnter()
	{
		this.GetComponent<SpriteRenderer>().sprite = rollOverSprite;
	}
	
	
	void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer>().sprite = normalSprite;
	}
	
	IEnumerator OnMouseUp()
	{
		//audio.PlayOneShot (beep);
		yield return new WaitForSeconds(0.35f);
		Application.LoadLevel (levelToLoad);
	}
	
	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer>().sprite = clickSprite;
	}
}
