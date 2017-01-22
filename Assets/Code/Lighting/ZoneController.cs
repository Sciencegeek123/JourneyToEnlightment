using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour {

	[SerializeField] Color StartFogColor = Color.white;
	[SerializeField] Color StartLightColor = Color.white;
	[SerializeField] Color WindFogColor = Color.white;
	[SerializeField] Color WindLightColor = Color.white;
	[SerializeField] Color FireFogColor = Color.white;
	[SerializeField] Color FireLightColor = Color.white;
	[SerializeField] Color WaterFogColor = Color.white;
	[SerializeField] Color WaterLightColor = Color.white;
	[SerializeField] Color EarthFogColor = Color.white;
	[SerializeField] Color EarthLightColor = Color.white;

	public enum ZoneEnum {
		Start,
		Wind,
		Fire,
		Water,
		Earth
	}

	public void SetZone(ZoneEnum zone) {

	}


}
