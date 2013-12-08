using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		Destroy(gameObject);
	}
}
