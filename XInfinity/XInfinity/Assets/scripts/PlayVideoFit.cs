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

public class PlayVideoFit : MonoBehaviour 
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
		//fullscreen with vertical borders
		float newWidth = -(Screen.width-(Screen.height*(mTex.width/(float)mTex.height)));
		float xOffset = (Screen.width - newWidth)/2;
		videoGUItex.pixelInset = new Rect(xOffset, -Screen.height/2,newWidth,0);
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
