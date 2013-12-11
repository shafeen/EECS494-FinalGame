using UnityEngine;
using System.Collections;

public class DieMonsterDie : MonoBehaviour {
	private float timer = 0;
	private bool activated = false;
	private GameObject explosion;
	void Start() {
		explosion = GameObject.FindWithTag("Explosion");
	}
	public void ImDead() {
		timer = Time.time;
		explosion.transform.position = transform.position;
		GameObject.FindWithTag("Teddy").transform.parent = explosion.transform;
		gameObject.SetActive(false);
		activated = true;
	}
	void Update() {
		if(activated && (Time.time - timer) > 1) {
			GameObject.FindWithTag("Teddy").transform.parent = null;
			Destroy(explosion);
			Destroy(gameObject);
		}
	}
}
