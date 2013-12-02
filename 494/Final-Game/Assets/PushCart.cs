using UnityEngine;
using System.Collections;

public class PushCart : MonoBehaviour {
	private bool attached = false;
	private RaycastHit hit;
	private RaycastHit hit2;
	private Vector3 fwd;
	public float attachRange;
	private GameObject cart;
	private CharacterMotor playerChMotor;
	private MouseLook playerMLook;
	private MouseLook camMLook;
	void Start(){
		playerChMotor = GetComponent<CharacterMotor>();
		playerMLook = GetComponent<MouseLook>();
		camMLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();

	}
	void cartCheck(){
		if(attached){
			attached = false;
		}
		else if(Physics.Raycast(transform.position, fwd, out hit, attachRange)) {
			if(hit.collider.gameObject.tag == "cart"){

				attached = true;

			}
		}
	}
	void Update(){
		fwd = transform.TransformDirection(Vector3.forward);
		Vector3 fwdC = GameObject.FindWithTag("cart").transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd, Color.red, 0.0f, false);
		Debug.DrawRay(GameObject.FindWithTag("cart").transform.position, fwdC*20, Color.red, 0.0f, false);
		Debug.DrawRay(GameObject.FindWithTag("cart").transform.position, fwdC*-20, Color.red, 0.0f, false);
		if(Input.GetMouseButtonDown(0)){
			cartCheck();
		}

	}
}
