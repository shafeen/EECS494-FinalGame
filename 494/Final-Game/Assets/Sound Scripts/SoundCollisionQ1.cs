using UnityEngine;
using System.Collections;

public class SoundCollisionQ1 : MonoBehaviour 
{

	// Can set this via drag and drop
	public GameObject soundSrcObj;
	private float initialVolume;
	private float finalVolume;
	private float fadeSpeed;

	// Indicates beginning of the fade in/out
	bool fadeIn;
	bool fadeOut;

	// Use this for initialization
	void Start () {

		fadeIn  = false;
		fadeOut = false;

		initialVolume = 0.0f;
		finalVolume   = 0.5f;
		fadeSpeed     = 0.01f; // 1% per update
	}
	
	// Update is called once per frame
	void Update () {

		// Ramps up the volume per frame until
		// the desired volume is attained
		if (fadeIn) 
		{
			if(initialVolume < finalVolume)
				initialVolume += fadeSpeed;
			else
				fadeIn = false; // end fadeIn
			soundSrcObj.audio.volume = initialVolume;
		}



	
	}


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Sound Queued!!\n");
		//GameObject.Find ("SoundSource1").audio.Play();
		soundSrcObj.audio.volume = initialVolume;
		soundSrcObj.audio.Play ();
		fadeIn = true;


	}
		
}
