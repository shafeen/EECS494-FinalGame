using UnityEngine;
using System.Collections;

public class MonsterSparkScript : MonoBehaviour {

	public GameObject light1;
	public GameObject light2;
	public GameObject light3;

	private bool inFlash = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		int light_num = Random.Range(1,4);

		Debug.Log(light_num);
		if (!inFlash) {
		switch (light_num) {
			case 1:
				StartCoroutine(Flash (light1));
				break;

			case 2:
				StartCoroutine(Flash (light2));
				break;

			case 3:
				StartCoroutine(Flash (light3));
				break;

			default:
				break;

			}
		}

	}

	IEnumerator Flash(GameObject light) {
		inFlash = true;
		yield return new WaitForSeconds(Random.Range(0.3f, 1.0f));
		light.active = true;
		yield return new WaitForSeconds(0.05f);
		light.active = false;
		inFlash = false;
	}
}
