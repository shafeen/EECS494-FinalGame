using UnityEngine;
using System.Collections;

public class PullLeverScript : MonoBehaviour {

	public Transform portcullis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		animation.Play("Pull Lever Down");
		portcullis.animation.Play("Raise Portcullis");
	}
}
