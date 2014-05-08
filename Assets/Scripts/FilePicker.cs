//
//Name : CTreeView.cs
//Desc : Use this class to show a browse window like a tree view
//      u can choose folder and file
//Auth : Nette
//Date : 10-25-2008 
//

using UnityEngine;
using System.IO;
using System.Collections;

public class FilePicker : MonoBehaviour
{
    public Rect winRect = new Rect(20, 20, 80, 60);   //windows basic rect
    public string location;
    private Vector2 scrollPosition;
    private string[] strs;  //record the special level's selection
    private int index;
    public string path = "";    //this is the selected file's full name
    public GUIStyle fileStyle;                      //if the item is a file use this style
    public GUIStyle dirStyle;                       //if the item is a directory use this style
    public string filter;                           //filter of file select
    public Texture2D fileTexture;                   //the file texture
    public Texture2D dirTexture;                    //the directory texture
    
    void Awake()
    {
        location = Application.dataPath;
        strs = new string[20];
        index = 0;
        path = location;
    }

    void OnGUI()
    {
        winRect = GUILayout.Window(1, winRect, DoMyWindow, "Browser");
    }
 
    void DoMyWindow(int windowID)
    {
        OpenFileWindow(location);
        GUI.DragWindow();
    }
 
    void OpenFileWindow(string location)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(160), GUILayout.Height(120));
        GUILayout.BeginVertical();
        FileBrowser(location, 0, 0);
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        GUILayout.Label("Selected: " + path);
    }
 
    void FileBrowser(string location, int spaceNum, int index)
    {
        FileInfo fileSelection;
        DirectoryInfo directoryInfo;
        DirectoryInfo directorySelection;
        //
        fileSelection = new FileInfo(location);
        if (fileSelection.Attributes == FileAttributes.Directory)
            directoryInfo = new DirectoryInfo(location);
        else
            directoryInfo = fileSelection.Directory;
        //
        GUILayout.BeginVertical();
        foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(spaceNum);
            GUILayout.Label(dirTexture, dirStyle, GUILayout.Width(12));
            
            if (GUILayout.Button(dirInfo.Name, dirStyle))
            {
                strs[index] = dirInfo.FullName;
                path = dirInfo.FullName;
            }
            GUILayout.EndHorizontal();
            if (dirInfo.FullName == strs[index] && strs[index] != location)
                FileBrowser(strs[index], spaceNum + 20, index + 1);
        }
        //list the special file with speical style and texture under current directory
        //if( filter=="") filter = "*.*";
        fileSelection = SelectList(directoryInfo.GetFiles(), null, fileStyle, fileTexture, spaceNum) as FileInfo;
        if (fileSelection != null)
            path = fileSelection.FullName;
        GUILayout.EndVertical();
    }
   
    private object SelectList(ICollection list, object selected, GUIStyle style, Texture image, int spaceNum)
    {
        foreach (object item in list)
        {
            //just show the name of directory and file
            FileSystemInfo info = item as FileSystemInfo;
            GUILayout.BeginHorizontal();
            GUILayout.Space(spaceNum);
            GUILayout.Label(image, style, GUILayout.Width(12));
            if (GUILayout.Button(info.Name, style))
            {
                selected = item;
            }
            GUILayout.EndHorizontal();
        }
        return selected;
    }
}