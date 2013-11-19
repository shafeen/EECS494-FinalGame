using UnityEngine;
using System.Collections;

public class CheckInspectRange : MonoBehaviour {
	private float ray_range = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray lightRay = new Ray(transform.position, transform.forward);
		Debug.DrawRay(transform.position, ray_range * transform.forward, Color.yellow, 0.0f, false);
		if (Physics.Raycast(lightRay, out hit, ray_range)) {
			
			if (hit.collider.tag == "focusObject") {
				MoveCamera mv = hit.collider.transform.GetComponent<MoveCamera>();
				if (mv) {
					mv.activate();
				}
			}
		}
	}
}
