using UnityEngine;
using System.Collections;

public class GrabTeddy : MonoBehaviour {

	public void ChildTeddy() {
		GameObject.FindWithTag("Teddy").transform.parent = transform;
	}

	public void ReleaseTeddy() {
		GameObject.FindWithTag("Teddy").transform.parent = null;
	}
}
