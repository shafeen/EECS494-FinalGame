using UnityEngine;
using System.Collections;

public class SoundCollisionQ1 : MonoBehaviour 
{

	// set this via drag and drop
	public GameObject soundSrcObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Sound Queued!!\n");
		//GameObject.Find ("SoundSource1").audio.Play();
		soundSrcObj.audio.Play ();
	}
		
}
