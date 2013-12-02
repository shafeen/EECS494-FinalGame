using UnityEngine;
using System.Collections;

public class CollisionHelper : MonoBehaviour {
	private ControllerColliderHit hit;
	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "cart"){
			hit.transform.SendMessage("OnCollisionStay", collider);
		}
	}
}
