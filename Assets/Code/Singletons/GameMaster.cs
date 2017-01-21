using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    InputSingleton input;
    void Start() {
        input = InputSingleton.Instance;
    }

    void Update() {
    }
}