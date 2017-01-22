using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentIcons : MonoBehaviour {


	[SerializeField] Image iconLocation;
	[SerializeField] Sprite[] Icons;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		StateSingleton instance = StateSingleton.get();

		if(instance!=null) {
			iconLocation.sprite = Icons[instance.curBell]; 
		}
	}
}
