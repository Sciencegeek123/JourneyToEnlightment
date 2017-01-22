using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider))]
public class ZoneGateway : MonoBehaviour {

	[SerializeField] ZoneController controller;
	[SerializeField] ZoneController.ZoneEnum zoneEntry;

	void OnTriggerEnter() {
		controller.SetZone(zoneEntry);
	}
}
