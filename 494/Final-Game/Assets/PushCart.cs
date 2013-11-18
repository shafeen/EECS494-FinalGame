using UnityEngine;
using System.Collections;

public class PushCart : MonoBehaviour {
	private bool attached = false;
	private RaycastHit hit;
	private RaycastHit hit2;
	private Vector3 fwd;
	private Vector3 fwdC;
	public float attachRange = 1;
	public bool xbox = false;
	private GameObject cart;
	void cartCheck(){
		if(attached){
			attached = false;
			transform.parent = null;
			cart.GetComponent<MouseLook>().enabled = false;
			cart.GetComponent<CharacterMotor>().enabled = false;
			cart.GetComponent<CharacterMotor>().canControl = false;
			GetComponent<MouseLook>().sensitivityX = 15.0f;
			GetComponent<MouseLook>().sensitivityY = 15.0f;
			GetComponent<CharacterMotor>().enabled = true;
			GetComponent<CharacterMotor>().canControl = true;
			GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityX = 10.0f;
			//GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityY = 10.0f;
		}
		else if(Physics.Raycast(transform.position, fwd, out hit, attachRange)) {
			if(hit.collider.gameObject.tag == "cart") {
				if(Vector3.Angle(fwd,fwdC) < 5){
					attached = true;
					cart = hit.collider.gameObject;
					cart.transform.rotation = transform.rotation;
					transform.parent = cart.transform;
				}
			}
		}
	}

	void Update(){
		fwd = transform.TransformDirection(Vector3.forward);
		fwdC = GameObject.FindWithTag("cart").transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd, Color.red, 0.0f, false);
		Debug.DrawRay(GameObject.FindWithTag("cart").transform.position, fwdC*20, Color.red, 0.0f, false);
		//Debug.DrawRay(GameObject.FindWithTag("cart").transform.position, fwdC*-20, Color.red, 0.0f, false);
		if((xbox) ? Input.GetButtonDown("A_1") : Input.GetMouseButtonDown(0)) {
			cartCheck();
		}
		if(attached){
			cart.GetComponent<MouseLook>().enabled = true;
			cart.GetComponent<CharacterMotor>().enabled = true;
			cart.GetComponent<CharacterMotor>().canControl = true;
			GetComponent<MouseLook>().sensitivityX = 0.0f;
			GetComponent<MouseLook>().sensitivityY = 0.0f;
			GetComponent<CharacterMotor>().enabled = false;
			GetComponent<CharacterMotor>().canControl = false;
			GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityX = 0.0f;
			//GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityY = 0.0f;
		}
	}

}