using UnityEngine;
using System.Collections;

public class RespawnMinecartPlacer : MonoBehaviour, IRespawn {

	public GameObject player;
	public Transform red1pos;
	public Transform red2pos;
	public Transform bluepos;
	public Transform yellowpos;

	public Transform redcart;
	public Transform bluecart;
	public Transform yellowcart;

	public GameObject respawn1;
	public GameObject respawn2;

	public void ResetMinecarts() {
		if (player.GetComponent<RespawnTimer>().respawnLocation == respawn1.transform) {
			Debug.Log("Resetting carts for pos 1");
			redcart.position = red1pos.position;
			redcart.rotation = red1pos.rotation;
		} else if (player.GetComponent<RespawnTimer>().respawnLocation == respawn2.transform) {
			Debug.Log("Resetting carts for pos 2");
			redcart.position = red2pos.position;
			redcart.rotation = red2pos.rotation;
			bluecart.position = bluepos.position;
			bluecart.rotation = bluepos.rotation;
			yellowcart.position = yellowpos.position;
			yellowcart.rotation = yellowpos.rotation;
		}
	}

	public void Respawn() {
		Debug.Log("Respawn has been called on RespawnMinecartPlacer");
		ResetMinecarts();
	}
}
