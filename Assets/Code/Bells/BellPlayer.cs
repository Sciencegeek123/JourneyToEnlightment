using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPlayer : MonoBehaviour {
	[SerializeField] Player player;

	float enlightenmentBellCharge, airBellCharge, awarenessBellCharge, earthBellCharge, fireBellCharge, waterBellCharge;
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			awarenessBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha1)) {
			player.awarenessBell.Emit(Time.realtimeSinceStartup - awarenessBellCharge);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			airBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha2)) {
			player.airBell.Emit(Time.realtimeSinceStartup - airBellCharge);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			fireBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha3)) {
			player.fireBell.Emit(Time.realtimeSinceStartup - fireBellCharge);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)) {
			waterBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha4)) {
			player.waterBell.Emit(Time.realtimeSinceStartup - waterBellCharge);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)) {
			earthBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha5)) {
			player.earthBell.Emit(Time.realtimeSinceStartup - earthBellCharge);
		}
		if(Input.GetKeyDown(KeyCode.Alpha6)) {
			enlightenmentBellCharge = Time.realtimeSinceStartup;
		} else if(Input.GetKeyUp(KeyCode.Alpha6)) {
			player.enlightenmentBell.Emit(Time.realtimeSinceStartup - enlightenmentBellCharge);
		}
		
	}
}
