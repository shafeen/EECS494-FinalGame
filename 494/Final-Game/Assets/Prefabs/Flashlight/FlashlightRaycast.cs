using UnityEngine;
using System.Collections;

public class FlashlightRaycast : MonoBehaviour {
	public float ray_range;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset;
		RaycastHit hit;
		Ray lightRay = new Ray(transform.position, transform.forward);

		for (float i = -0.13f; i < 0.13f; i += 0.05f) {
			for (float j = -0.13f; j < 0.13f; j += 0.05f) {
				offset = new Vector3(transform.forward.x + i, transform.forward.y + j, transform.forward.z);
				Debug.DrawRay(transform.position, offset * ray_range);
				lightRay = new Ray(transform.position, offset);

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
	}
}
