using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //TestingSingleton.Instance.Register(this.transform, Ping);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Complete() { }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Destroying Puzzle...");
        Destroy(this.gameObject);
    }
}
