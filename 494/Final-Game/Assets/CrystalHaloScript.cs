using UnityEngine;
using System.Collections;

public class CrystalHaloScript : MonoBehaviour {
	private Light pointLight;
	public float maxHaloSize = 5.0F;
	public float minHaloSize = 0.4F;
	void Start() {
		pointLight = transform.parent.Find("Point light").GetComponent<Light>();
		animation["Halo"].speed = 0.0F;
		animation.Play("Halo");
	}
	// Update is called once per frame
	void Update () {
		animation["Halo"].time = Mathf.Clamp((pointLight.intensity-minHaloSize)/(maxHaloSize-minHaloSize),0,1);
		animation["Halo"].speed = 0.0F;
		animation.Play ("Halo");
	}
}
