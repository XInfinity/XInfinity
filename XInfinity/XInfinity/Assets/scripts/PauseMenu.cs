using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUISkin mySkin1;

	private Rect windowsRect1;
	private bool paused = false ;
	// Use this for initialization
	void Start () {
		windowsRect1 = new Rect (Screen.width/2-100,Screen.height/2-100,200,200);
	}

	private void OnGUI(){
		if (paused) {
						windowsRect1 = GUI.Window (0, windowsRect1, windowFunc, "Pause ");	
				}
	}
	private void windowFunc(int id){
			
			
		if(GUILayout.Button("Resume")){
			paused = false;

		}
		if(GUILayout.Button("Return to Main Menu")){
			Application.LoadLevel("MainMenuScense");
		}
		if(GUILayout.Button("Quit Game")){
			Application.Quit();
		}

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)){
			if (paused){
				paused = false;}
				else {
				paused = true;}


		}
		if (paused) {
						Time.timeScale = 0;
				}
				else {
						Time.timeScale = 1;
				}
	}
	public bool Pausedd(){
		return paused;
	}
}
