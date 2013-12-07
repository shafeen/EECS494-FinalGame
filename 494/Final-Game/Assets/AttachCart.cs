using UnityEngine;
using System.Collections;

public class AttachCart : MonoBehaviour {
	public float attachRange = 2;
	private GameObject player;
	private Transform flashlight;
	private RaycastHit hit;
	private Vector3 playerFwd;
	private Vector3 cartFwd;
	private GameObject handle1;
	private GameObject handle2;
	private bool is_attached = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		flashlight = player.transform.Find("Player_Cam").transform.Find("Flashlight");
		handle1 = transform.Find("Handle1").gameObject;
		handle2 = transform.Find("Handle2").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			if (is_attached) {
				//release the cart
				transform.parent = null;
			} else {
				attachToCart();
			}
		}
	}

	void attachToCart(){
		playerFwd = flashlight.TransformDirection(Vector3.forward);
		cartFwd = transform.TransformDirection(Vector3.forward);
		//Attach to front
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, attachRange)) {
			if(hit.collider.gameObject == handle1.transform.Find("HandleCollider1").gameObject) {
				Debug.Log("Hit Handle 1");
				if(Mathf.Abs(Vector3.Angle(playerFwd,cartFwd)-180) < 10){
					is_attached = true;
					//postion player behind cart
					//player.transform.parent = transform;
					//player.transform.position = new Vector3(0.0f, 0.08f, 0.25f);
					//now switch the cart to be child to the player
					//player.transform.parent = null;
					transform.parent = player.transform;
					//modify controls
				}
			//Attach to back
			} else if(hit.collider.gameObject == handle2.transform.Find("HandleCollider2").gameObject) {
				Debug.Log("Hit Handle 2");
				if(Vector3.Angle(playerFwd,cartFwd) < 10){
					is_attached = true;
					//postion player behind cart
					player.transform.parent = transform;
					player.transform.position = new Vector3(0.0f, 0.06f, -0.29f);
					//now switch the cart to be child to the player
					player.transform.parent = null;
					transform.parent = player.transform;
					//modify controls
				}
			}
		}
	}
}
