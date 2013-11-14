using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public GameObject cam;
	private float time;
	public GameObject playerCam;
	public int posMultiplier;
	public int rotMultiplier;
	public float lookTime;
	private bool clicked = false;
	public GameObject tempObj;
	private FPSInputController fpsInput;
	private MouseLook mouseInput;
	// Use this for initialization
	void Start () {
		fpsInput = GameObject.Find ("Player").GetComponent<FPSInputController>();
		mouseInput = GameObject.Find ("Player").GetComponent<MouseLook>();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (clicked) {
			if (time > lookTime) {
				playerCam.transform.rotation = Quaternion.Lerp (playerCam.transform.rotation, tempObj.transform.rotation, rotMultiplier * Time.deltaTime);
				playerCam.transform.position = Vector3.Lerp (playerCam.transform.position, tempObj.transform.position, posMultiplier * Time.deltaTime);
				if((playerCam.transform.position - tempObj.transform.position).magnitude < 0.001){
					clicked = false;
					fpsInput.enable = true;
					mouseInput.enable = true;
					playerCam.transform.position = tempObj.transform.position;
					playerCam.transform.rotation = tempObj.transform.rotation;
				}
			}

			else {
				fpsInput.enable = false;
				mouseInput.enable = false;
				playerCam.transform.rotation = Quaternion.Lerp (playerCam.transform.rotation, cam.transform.rotation, rotMultiplier * Time.deltaTime);
				playerCam.transform.position = Vector3.Lerp (playerCam.transform.position, cam.transform.position, posMultiplier * Time.deltaTime);

			}
		}
	}
	void OnMouseDown() {
		clicked = true;
		time = 0;
		tempObj.transform.position = playerCam.transform.position;
		tempObj.transform.rotation = playerCam.transform.rotation;
	}
}
