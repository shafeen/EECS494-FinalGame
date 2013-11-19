
using UnityEngine;
using System.Collections;

public class SFXFadeInOut : MonoBehaviour 
{
	
	// Can set this via drag and drop
	public GameObject soundSrcObj;

	private const float initialVolume = 0.0f;
	private const float finalVolume   = 1.0f;
	private const float fadeSpeed     = 0.1f;  // 10% increase per update
	private const float fadeOutAtClip = 0.85f; // fade out at 85% elapsed time

	// These need to be set externally
	public bool loopSFX;
	private bool fadeSFX; // this should be true
	
	// Indicates beginning of the fade in/out
	private bool fadeIn;
	private bool fadeOut;
	private bool stopSFX; // << currently unused


	// Needed for fade logic use
	private float audioClipLength;
	private float fadeOutStartTime;

	// Use this for initialization
	// NOTE: This overrides UI settings of publics
	void Start () 
	{
		loopSFX = true; // this will override user UI setting!
		fadeSFX = true;

		fadeIn  = false;
		fadeOut = false;
		stopSFX = false;

		audioClipLength = soundSrcObj.audio.clip.length;
		fadeOutStartTime = fadeOutAtClip * audioClipLength; // fade out starts here
		soundSrcObj.audio.loop = loopSFX;
	}





	// Update is called once per frame
	void Update () 
	{
		// FADES IN
		// Ramps up the volume per frame until volume = 1.0f
		if(fadeIn) 
		{
			Debug.Log("SFX Fading In!");

			if(soundSrcObj.audio.volume < finalVolume)
				soundSrcObj.audio.volume += fadeSpeed;
			else
				fadeIn = false; // end fadeIn

		}

		// Logic to indicate beginning of fade out 
		// ^^ this will be redundant later when the property will be
		// used to fade out a sound instead
		if (!loopSFX && !fadeIn && soundSrcObj.audio.time >= fadeOutStartTime )
			fadeOut = true; 


		// FADES OUT (or continues the sound loop)
		// Ramps down the volume per frame until volume = 0.0f
		if(fadeOut) 
		{
			Debug.Log("SFX Fading Out!");

			if(soundSrcObj.audio.volume <= 0.0f)
				soundSrcObj.audio.volume -= fadeSpeed;
			else
			{
				fadeOut = false; // end fadeOut
			}
		}


	}
	
	
	void OnTriggerEnter(Collider other)
	{
		// Do nothing if this has already been triggered
		if (soundSrcObj.audio.isPlaying)
			return;

		Debug.Log("Sound Cued!!\n");

		soundSrcObj.audio.volume = initialVolume;
		soundSrcObj.audio.Play ();


		// Fade logic
		if (fadeSFX == true) 
		{
			fadeIn = true;
			fadeSFX = false; // to prevent being triggered twice
		}

	}


	// This property FORCES a fade out!
	// this will be used externally by the player to stop SFX
	public bool StopSFX
	{
		set
		{ 
			Debug.Log("Sound FX is being stopped externally!");
			fadeOut = (stopSFX = value)? true : false; // << yes this is on purpose
			fadeIn = (fadeOut)? false : fadeIn; // defensive
		}
		get{ return stopSFX;}
	}


	void fadeInSound()
	{

	}
	void fadeOutSound()
	{
		
	}
	
}
