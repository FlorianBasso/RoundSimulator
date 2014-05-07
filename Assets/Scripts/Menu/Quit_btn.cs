using UnityEngine;
using System.Collections;

public class Quit_btn : MonoBehaviour {

	public Sprite normalSprite;
	public Sprite rollOverSprite;
	public Sprite clickSprite;
	public AudioClip beep;
	
	// Use this for initialization
	void Start () 
	{
		
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
		Application.Quit();
	}
	
	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer>().sprite = clickSprite;
	}
}
