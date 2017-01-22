using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEffect : BaseEffect{

    [SerializeField]
    public AudioClip clip;

    [SerializeField]
    public GameObject door;

    AudioSource source;


    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (clip != null)
            source.clip = clip;
        BellEventEmitterSingleton.Instance.Register(BellEventType.AirBellEvent, transform, null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        if (door != null)
        {
            source.Play();
            StartCoroutine(drawDoor());
        }
    }

    IEnumerator drawDoor()
    {
        for (int i = 0; i < 10; i++){
            door.transform.position.Set(door.transform.position.x, door.transform.position.y - 1, door.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
        Destroy(door);
    }

    public override void Complete()
    {
        Debug.Log("Air Puzzle Solved");
        //clip.Play();
        StartCoroutine(Death());
    }

}
