using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSingleton {

	private static InputSingleton instance = null;

	enum KeyEvents {
		MoveForward,
		MoveBackwards,
		MoveLeft,
		MoveRight,
		TurnLeft,
		TurnRight,
		BellFire,
		BellLeft,
		BellRight,
		Pause
	}

	public static InputSingleton Instance { 
		get {
			if(instance == null) {
				instance = new InputSingleton();
			} 
			return instance;
		}
	}

	public void Update() {
		
	}
}
