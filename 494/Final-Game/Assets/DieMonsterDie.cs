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
		explosion.transform.position = transform.position;
		GameObject.FindWithTag("Teddy").transform.parent = explosion.transform;
		StartCoroutine("Explode");
	}

	IEnumerator Explode() {
		yield return new WaitForSeconds(1.5f);
		GameObject.FindWithTag("Teddy").transform.parent = null;
		Destroy(explosion);
		Destroy(gameObject);
	}
}
