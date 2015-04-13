using UnityEngine;
using System.Collections;

public class AboutSence : MonoBehaviour {
	public string scene;
	public Texture image;
	public GUIStyle test;
	private Rect bottom1 = new Rect(10,400,150,100);
	private Rect bottom4 = new Rect(0,0,Screen.width,Screen.height);
	// Use this for initialization
	
	void OnGUI () {
		GUI.DrawTexture (bottom4,image);
		if(GUI.Button (bottom1,"Back",test)){
			Application.LoadLevel(scene);
		}
	}
	// Update is called once per frame
	void Update()
	{
		// Make a background box
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel(scene);
		}
	}
}
