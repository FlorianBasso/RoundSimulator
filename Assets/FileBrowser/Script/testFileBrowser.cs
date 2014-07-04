using UnityEngine;
using System.Collections;

public class testFileBrowser : MonoBehaviour {
	public GUISkin[] skins;
	public Texture2D file,folder,back,drive;
	
	string[] layoutTypes = {"Type 0","Type 1"};
	FileBrowser fb = new FileBrowser();
	
	// Use this for initialization
	void Start () {
		//setup file browser style
		fb.guiSkin = skins[0]; //set the starting skin
		//set the various textures
		fb.fileTexture = file; 
		fb.directoryTexture = folder;
		fb.backTexture = back;
		fb.driveTexture = drive;
	}
	
	void OnGUI(){
		//setect from layout types
		GUILayout.BeginVertical();
		GUILayout.Label("Layout Type");
		fb.setLayout(GUILayout.SelectionGrid(fb.layoutType,layoutTypes,1));
		GUILayout.Space(10);
		//select from available gui skins
		GUILayout.Label("GUISkin");
		foreach(GUISkin s in skins){
			if(GUILayout.Button(s.name)){
				fb.guiSkin = s;
			}
		}
		GUILayout.EndVertical();
		//draw and display output
		if(fb.draw()){ //true is returned when a file has been selected
			//the output file is a memeber if the FileInfo class, if cancel was selected the value is null
			Debug.Log((fb.outputFile==null)?"cancel hit":fb.outputFile.ToString());
		}
	}
}
