﻿using UnityEngine;
using System.Collections;

public class FadeScene : MonoBehaviour {
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public string targetScene = "";
	public bool sceneEnding = false;
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.

	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(Screen.width/2f*-1f, Screen.height/2*-1f, Screen.width, Screen.height);
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
		if(sceneEnding)
			EndScene();
	}
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.white, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.05f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		// If the screen is almost black...
		if(guiTexture.color.a >= 0.4f)
			// ... reload the level.
			Application.LoadLevel(targetScene);
	}
}
