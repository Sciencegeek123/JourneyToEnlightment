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
	[SerializeField] Light directionalLight;

	public enum ZoneEnum {
		Start,
		Wind,
		Fire,
		Water,
		Earth
	}

	ZoneEnum targetZone = ZoneEnum.Start;
	float targetTime = 0;
	Color oldFogColor, oldLightColor;

	public void SetZone(ZoneEnum zone) {
		targetZone = zone;
		targetTime = Time.realtimeSinceStartup;
		oldFogColor = RenderSettings.fogColor;
		oldLightColor = RenderSettings.ambientLight;
	}

	void Update() {
		switch(targetZone) {
			case ZoneEnum.Start:
			{
				float delta = (Time.realtimeSinceStartup - targetTime) / 0.5f;
				RenderSettings.fogColor = Color.Lerp(oldFogColor, StartFogColor, delta);
				directionalLight.color = Color.Lerp(oldLightColor, StartLightColor, delta);
				break;
			}
			case ZoneEnum.Wind:
			{
				float delta = (Time.realtimeSinceStartup - targetTime) / 0.5f;
				RenderSettings.fogColor = Color.Lerp(oldFogColor, WindFogColor, delta);
				directionalLight.color = Color.Lerp(oldLightColor, WindLightColor, delta);
				break;
			}
			case ZoneEnum.Water:
			{
				float delta = (Time.realtimeSinceStartup - targetTime) / 0.5f;
				RenderSettings.fogColor = Color.Lerp(oldFogColor, WaterFogColor, delta);
				directionalLight.color = Color.Lerp(oldLightColor, WaterLightColor, delta);
				break;
			}
			case ZoneEnum.Earth:
			{
				float delta = (Time.realtimeSinceStartup - targetTime) / 0.5f;
				RenderSettings.fogColor = Color.Lerp(oldFogColor, EarthFogColor, delta);
				directionalLight.color = Color.Lerp(oldLightColor, EarthLightColor, delta);
				break;
			}
			case ZoneEnum.Fire:
			{
				float delta = (Time.realtimeSinceStartup - targetTime) / 0.5f;
				RenderSettings.fogColor = Color.Lerp(oldFogColor, FireFogColor, delta);
				directionalLight.color = Color.Lerp(oldLightColor, FireLightColor, delta);
				break;
			}
		}
	}


}
