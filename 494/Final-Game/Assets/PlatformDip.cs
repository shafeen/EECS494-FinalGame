using UnityEngine;
using System.Collections;

public class PlatformDip : MonoBehaviour {

	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;

	public float lerpSmoothness;

	private bool movePlatform1; 

	// Use this for initialization
	void Start () {

		movePlatform1 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(movePlatform1)
			movePlatformPosition();

	}

	void OnTriggerEnter(Collider other)
	{

		movePlatform1 = true;



	}


	void movePlatformPosition()
	{
		Vector3 positionA = new Vector3 (platform1.transform.position.x,0.0f,platform1.transform.position.z);
		Vector3 positionB = new Vector3 (platform2.transform.position.x,0.0f,platform2.transform.position.z);
		Vector3 positionC = new Vector3 (platform3.transform.position.x,0.0f,platform3.transform.position.z);
		Vector3 positionD = new Vector3 (platform4.transform.position.x,0.0f,platform4.transform.position.z);

		platform1.transform.position = Vector3.Lerp (platform1.transform.position, positionA, lerpSmoothness/1.0f * Time.deltaTime);		
		platform2.transform.position = Vector3.Lerp (platform2.transform.position, positionB, lerpSmoothness/1.0f * Time.deltaTime);
		platform3.transform.position = Vector3.Lerp (platform3.transform.position, positionC, lerpSmoothness/1.0f * Time.deltaTime);
		platform4.transform.position = Vector3.Lerp (platform4.transform.position, positionD, lerpSmoothness/1.0f * Time.deltaTime);
	}



}
