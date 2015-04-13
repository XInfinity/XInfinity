using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public string scene;
	//public Texture image;  
	public GUIStyle title;
	public GUIStyle test;
	private Rect bottom4 = new Rect(0,0,1400,750);
	private Rect windowsRect;
	
	private void OnGUI(){
		GUI.DrawTexture (bottom4,null);
		windowsRect = GUI.Window(0,windowsRect,windowFunc,"XInfinity");
		windowsRect = new Rect (Screen.width/2-250,Screen.height/2-250,200,100);
	}
	
	private void windowFunc(int id){
		//GUILayout.TextArea ("Your Score : ");
		if(GUILayout.Button("Start Play")){
			Application.LoadLevel(scene);
			
		}
		if(GUILayout.Button("Help")){
			Application.LoadLevel("aboutScence");
		}
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
		
	}
	void Update()
	{
		
		// Make a background box
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}


