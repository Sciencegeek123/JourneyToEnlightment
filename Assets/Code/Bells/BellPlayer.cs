using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPlayer : MonoBehaviour {
	[SerializeField] Player player;

	float enlightenmentBellCharge, airBellCharge, awarenessBellCharge, earthBellCharge, fireBellCharge, waterBellCharge;
	void Update () {
		if(Input.GetKeyUp(KeyCode.Alpha1)) {
			player.awarenessBell.Emit(25);
		}
		if(Input.GetKeyUp(KeyCode.Alpha2)) {
			player.airBell.Emit(25);
		}
		if(Input.GetKeyUp(KeyCode.Alpha3)) {
			player.fireBell.Emit(25);
		}
		if(Input.GetKeyUp(KeyCode.Alpha4)) {
			player.waterBell.Emit(25);
		}
		if(Input.GetKeyUp(KeyCode.Alpha5)) {
			player.earthBell.Emit(25);
		}
		if(Input.GetKeyUp(KeyCode.Alpha6)) {
			player.enlightenmentBell.Emit(25);
		}
		
	}
}
