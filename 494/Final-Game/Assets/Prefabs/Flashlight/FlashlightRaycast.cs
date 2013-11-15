using UnityEngine;
using System.Collections;

public class FlashlightRaycast : MonoBehaviour {
	public float ray_range;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray lightRay = new Ray(transform.position, transform.forward);

		Debug.DrawRay(transform.position, transform.forward * ray_range);

		if (Physics.Raycast(lightRay, out hit, ray_range)) {

			if (hit.collider.tag == "Crystal") {
				CrystalLightScript crystal = hit.collider.transform.GetComponent<CrystalLightScript>();
				if (crystal) {
					crystal.is_being_charged_by_flashlight = true;
				}
			}
		}
	}
}
