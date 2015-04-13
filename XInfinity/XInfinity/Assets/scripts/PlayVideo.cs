////////////////////////////////////////////////////////////////////////////
//                                                   41 Post                                       		//
// Created by DimasTheDriver in 19/Apr/2011                                      		//
// Part of 'Unity: How to use a GUI Texture to play fullscreen videos' post.   //
// Available at:      http://www.41post.com/?p=3687                             		//
///////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUITexture))]
[RequireComponent (typeof (AudioSource))]

public class PlayVideo : MonoBehaviour 
{
	//the GUI texture
	private GUITexture videoGUItex;
	//the Movie texture
	private MovieTexture mTex;
	public MovieTexture test;
	//the AudioSource
	private AudioSource movieAS;
	//the movie name inside the resources folder
	
	void Awake()
	{
		//get the attached GUITexture
		videoGUItex = this.GetComponent<GUITexture>();
		//get the attached AudioSource
		movieAS = this.GetComponent<AudioSource>();
		//load the movie texture from the resources folder

		//set the AudioSource clip to be the same as the movie texture audio clip
		movieAS.clip = test.audioClip;
		//anamorphic fullscreen
		videoGUItex.pixelInset = new Rect(Screen.width/2, -Screen.height/2,0,0);
	}

	//On Script Start
	/*void Start()
	{


	}*/
	IEnumerator Start()
	{  //set the videoGUItex.texture to be the same as mTex
		//videoGUItex.texture = mTex;
		videoGUItex.texture = test;
		//Plays the movie
		test.Play ();
		//plays the audio from the movie
		movieAS.Play();

		yield return new WaitForSeconds (91);
		Application.LoadLevel ("MainMenuScense");
		
		//Application.LoadLevel("Main Menu");
	}
	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel("MainMenuScense");
		}
	}
}
