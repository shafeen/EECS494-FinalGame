using UnityEngine;
using System.Collections;

public class SoundRoomEnterExit : MonoBehaviour 
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

	void OnTriggerExit(Collider other)
	{
		Debug.Log("Sound Queued!!\n");
		//GameObject.Find ("SoundSource1").audio.Stop();
		soundSrcObj.audio.Stop(); // This is prety abrupt!
	}

}
