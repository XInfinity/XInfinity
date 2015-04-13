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

public class PlayVideoLetterbox : MonoBehaviour 
{
	//the GUI texture
	private GUITexture videoGUItex;
	//the Movie texture
	private MovieTexture mTex;
	//the AudioSource
	private AudioSource movieAS;
	//the movie name inside the resources folder
	public string movieName;
	
	void Awake()
	{
		//get the attached GUITexture
		videoGUItex = this.GetComponent<GUITexture>();
		//get the attached AudioSource
		movieAS = this.GetComponent<AudioSource>();
		//load the movie texture from the resources folder
		mTex = (MovieTexture)Resources.Load(movieName);
		//set the AudioSource clip to be the same as the movie texture audio clip
		movieAS.clip = mTex.audioClip;
		//letterbox
		float newHeight = -(Screen.height-(Screen.width/(mTex.width/(float)mTex.height)));
		float yOffset = (-Screen.height-newHeight)/2;
		videoGUItex.pixelInset = new Rect(Screen.width/2, yOffset,0,newHeight);
	}

	//On Script Start
	void Start()
	{
		//set the videoGUItex.texture to be the same as mTex
		videoGUItex.texture = mTex;
		//Plays the movie
		mTex.Play();
		//plays the audio from the movie
		movieAS.Play(); 
	}
}
