using UnityEngine;
using System.Collections;

public class CrystalLightScript : MonoBehaviour {

	private Light crystal_light;
	private float min_light_intensity = 0.5f;
	public static float max_light_intensity = 5;
	public float local_max_light_intensity = 4;
	public float light_charge_delta = 0.05f;
	private float light_discharge_delta = 0.01f;
	private float charge_neighbor_threshold = 2.0f;
	private float neighbor_charge_step = 0.20f;
	public bool is_being_charged_by_flashlight = false;
	public bool is_being_charged_by_radiance = false;
	private bool safe = true;
	private CaveChecker caveChecker;
	private RespawnTimer respawn;
	// Use this for initialization
	void Start () {
		crystal_light = transform.GetChild(0).GetComponent<Light>();
		respawn = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
		caveChecker = GameObject.FindWithTag("caveTrigger").GetComponent<CaveChecker>();
	}
	
	// Update is called once per frame
	void Update () {
		print(caveChecker.inCave);
		if(caveChecker.inCave) {
			safe = false;
			print("unsafe");
		}
		else {
			safe = true;
			print("safe");

		}
		//The only difference between being charged by the flashlight and by another crystal, is that
		//the flashlight will reset your max brightness to the full allowed
		//local max brightness is how bright a particular crystal is allowed to be
		//max brightness is more like a constant, the brightest any crystal can be
		if (is_being_charged_by_flashlight) {
			local_max_light_intensity = max_light_intensity;
			if (crystal_light.intensity < local_max_light_intensity) {
				crystal_light.intensity += light_charge_delta;
			}
		} else if (is_being_charged_by_radiance) {
			if (crystal_light.intensity < local_max_light_intensity) {
				crystal_light.intensity += light_charge_delta;
			}
		} else {
			if (crystal_light.intensity > min_light_intensity) {
				crystal_light.intensity -= light_discharge_delta;
			}
		}

		if (crystal_light.intensity > charge_neighbor_threshold) {
			ChargeNeighbors();
		}

		if (crystal_light.intensity > 0) {
			ProtectPlayer();
		}
		
		// Reset at the end of every update so the flashlight has to be kept on the crystal to set this true
		is_being_charged_by_flashlight = false;
		is_being_charged_by_radiance = false;
	}

	void ChargeNeighbors() {
		//Get a list of all objects within our light radius
		Collider[] colliders = Physics.OverlapSphere(transform.position, transform.GetChild(0).GetComponent<Light>().range);

		//Filter by the tag "Crystal"
		//If the neighboring crystal is dimmer than you, charge him up, but set his max brightness to a little less
		//than yours
		foreach(Collider col in colliders) {
			if (col.tag == "Crystal" && col.gameObject != gameObject) {
				CrystalLightScript neighbor_crystal = col.transform.GetComponent<CrystalLightScript>();
				Light neighbor_crystal_light = col.transform.GetChild(0).GetComponent<Light>();
				if (neighbor_crystal_light.intensity < crystal_light.intensity) {
					neighbor_crystal.local_max_light_intensity = local_max_light_intensity - neighbor_charge_step;
					neighbor_crystal.is_being_charged_by_radiance = true;
				}
			}
		}
	}

	void ProtectPlayer() {

		//Get a list of all objects within our light radius
		Collider[] colliders = Physics.OverlapSphere(transform.position, transform.GetChild(0).GetComponent<Light>().range);

		//If the player is within our light radius, protect him from baddies
		foreach (Collider col in colliders) {
			if (col.tag == "Player") {
				//Notify the player that he is safe
				safe = true;
			}
		}
		if(!safe){
			respawn.startTimer();
		}
		else {
			respawn.stopTimer();
			respawn.resetTimer();
		}

	}
}
