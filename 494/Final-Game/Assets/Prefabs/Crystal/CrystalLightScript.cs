using UnityEngine;
using System.Collections;

public class CrystalLightScript : MonoBehaviour {

	private AudioSource[] audios;

	public enum LIGHT_COLOR {
		RED,
		BLUE,
		YELLOW,
		PURPLE,
		GREEN,
		ORANGE }

	public LIGHT_COLOR my_light_color;
	private Light crystal_light;
	private float min_light_intensity = 0.4f;
	public static float max_light_intensity = 5;
	public float local_max_light_intensity = 4;
	private float light_charge_delta = 4.0f;
	private float light_discharge_delta =0.8f;
	private float charge_neighbor_threshold = 1.0f;
	private float neighbor_charge_step = 0.01f;
	public bool is_being_charged_by_flashlight = false;
	public bool is_being_charged_by_radiance = false;

	//Variables for combination gems
	private float mixed_color_threshold = 2.0f;
	private float color_1_intensity = 0.0f;
	private float color_2_intensity = 0.0f;
	private bool charge_color_1 = false;
	private bool charge_color_2 = false;
	private bool kill_charge = false;

	// Use this for initialization
	void Start () {
		crystal_light = transform.GetChild(0).GetComponent<Light>();
		crystal_light.intensity = 0.4f;
		audios = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		audios[0].volume = crystal_light.intensity / (max_light_intensity - min_light_intensity);

		//The only difference between being charged by the flashlight and by another crystal, is that
		//the flashlight will reset your max brightness to the full allowed
		//local max brightness is how bright a particular crystal is allowed to be
		//max brightness is more like a constant, the brightest any crystal can be
		switch (my_light_color) {
		case LIGHT_COLOR.RED:
		case LIGHT_COLOR.BLUE:
		case LIGHT_COLOR.YELLOW:

			if (is_being_charged_by_flashlight) {
				local_max_light_intensity = max_light_intensity;
				if (crystal_light.intensity < local_max_light_intensity) {
					crystal_light.intensity = Charge(crystal_light.intensity); 
				}
			} else if (is_being_charged_by_radiance) {
				if (crystal_light.intensity < local_max_light_intensity) {
					crystal_light.intensity = Charge(crystal_light.intensity);
				}
			} else {
				if (crystal_light.intensity > min_light_intensity) {
					crystal_light.intensity = Discharge(crystal_light.intensity);
				}
			}

			if (crystal_light.intensity > charge_neighbor_threshold) {
				ChargeNeighbors();
			}

			break;
		
		case LIGHT_COLOR.GREEN:
		case LIGHT_COLOR.PURPLE:
		case LIGHT_COLOR.ORANGE:
			if (charge_color_1 && !kill_charge) {
				if (color_1_intensity < max_light_intensity) {
					color_1_intensity = Charge(color_1_intensity);
				}
			} else {
				if (color_1_intensity > min_light_intensity) {
					color_1_intensity = Discharge(color_1_intensity, 5);
				}
			}

			if (charge_color_2 && !kill_charge) {
				if (color_2_intensity < max_light_intensity) {
					color_2_intensity = Charge(color_2_intensity);
				}
			} else {
				if (color_2_intensity > min_light_intensity) {
					color_2_intensity = Discharge(color_2_intensity, 5);
				}
			}

			if (color_1_intensity > mixed_color_threshold && color_2_intensity > mixed_color_threshold) {
				if (crystal_light.intensity < local_max_light_intensity) {
					crystal_light.intensity = Charge(crystal_light.intensity);
				}
			} else {
				if (crystal_light.intensity > min_light_intensity && crystal_light.intensity < mixed_color_threshold) {
					crystal_light.intensity = Discharge(crystal_light.intensity, 5);
				}
			}

			break;

		default:

			break;
		}
		
		// Reset at the end of every update so the flashlight has to be kept on the crystal to set this true
		charge_color_1 = false;
		charge_color_2 = false;
		kill_charge = false;
		is_being_charged_by_flashlight = false;
		is_being_charged_by_radiance = false;
	}

	public bool TestIncomingLight(LIGHT_COLOR incoming_color) {

		bool ret_value = false;

		switch (my_light_color) {
			case LIGHT_COLOR.RED:
			case LIGHT_COLOR.BLUE:
			case LIGHT_COLOR.YELLOW: 
				if (incoming_color == my_light_color) {
					is_being_charged_by_radiance = true;
					ret_value =  true;
				}
			break;

			case LIGHT_COLOR.GREEN: {
				if (incoming_color == LIGHT_COLOR.YELLOW) {
					charge_color_1 = true;
					ret_value =  true;
				} else if (incoming_color == LIGHT_COLOR.BLUE) {
					charge_color_2 = true;
					ret_value =  true;
				} else if (incoming_color == my_light_color) {
					is_being_charged_by_radiance = true;
					ret_value =  true;
				} else {
					if (IsPrimaryColor(incoming_color)) {
						kill_charge = true;
					}
				}
				break;
				}

			case LIGHT_COLOR.PURPLE: {
				if (incoming_color == LIGHT_COLOR.RED) {
					charge_color_1 = true;
					ret_value =  true;
				} else if (incoming_color == LIGHT_COLOR.BLUE) {
					charge_color_2 = true;
					ret_value =  true;
				} else if (incoming_color == my_light_color) {
					is_being_charged_by_radiance = true;
					ret_value =  true;
				} else {
					if (IsPrimaryColor(incoming_color)) {
						kill_charge = true;
					}
				}
				break;
			}


			case LIGHT_COLOR.ORANGE: {
				if (incoming_color == LIGHT_COLOR.YELLOW) {
					charge_color_1 = true;
					ret_value =  true;
				} else if (incoming_color == LIGHT_COLOR.RED) {
					charge_color_2 = true;
					ret_value =  true;
				} else if (incoming_color == my_light_color) {
					is_being_charged_by_radiance = true;
					ret_value =  true;
				} else {
					if (IsPrimaryColor(incoming_color)) {
						kill_charge = true;
					}
				}
				break;
			}

			default:
			ret_value =  false;
				break;

		}

		return ret_value;
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
				if (neighbor_crystal_light.intensity < crystal_light.intensity && neighbor_crystal.TestIncomingLight(my_light_color)) {
					neighbor_crystal.local_max_light_intensity = local_max_light_intensity - neighbor_charge_step;
				}
			}
		}
	}

	public float GetMixedColorThreshold() {
		return mixed_color_threshold;
	}

	bool IsPrimaryColor(LIGHT_COLOR color) {
		switch (color) {
		case LIGHT_COLOR.RED:
		case LIGHT_COLOR.BLUE:
		case LIGHT_COLOR.YELLOW:
			return true;
			break;
		}
		return false;
	}

	private float Charge(float intensity) {
		return intensity += Time.deltaTime * light_charge_delta;
	}

	private float Charge(float intensity, float multiplier) {
		return intensity += Time.deltaTime * light_charge_delta * multiplier;
	}

	private float Discharge(float intensity) {
		return intensity -= Time.deltaTime * light_discharge_delta;
	}

	private float Discharge(float intensity, float multiplier) {
		return intensity -= Time.deltaTime * light_discharge_delta * multiplier;
	}
}
