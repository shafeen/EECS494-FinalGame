using UnityEngine;
using System.Collections;

public class PushCart : MonoBehaviour {
	private Vector3 cartCenter = Vector3.zero;
	private bool attached = false;
	private RaycastHit hit;
	private Vector3 fwd;
	public float attachRange;
	private Transform cartTransform;
	void cartCheck(){
		if(attached){
			attached = false;
		}
		else if(Physics.Raycast(transform.position, fwd, out hit, attachRange)) {
			if(hit.collider.gameObject.tag == "cart"){
				attached = true;
				cartTransform = hit.collider.gameObject.transform;
			}
		}
	}
	void Update(){
		fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd, Color.red, 0.0f, false);
		if(Input.GetMouseButtonDown(0)){
			cartCheck();
		}
		if(attached){
			cartTransform.position = transform.position;
		}

	}
}
