using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttainBell : MonoBehaviour {

    public int bellNum;

    public AudioClip[] bellSounds;

    public AudioSource bellSource;

    private CapsuleCollider col;
    private static StateSingleton ss;

    [SerializeField] float duration = 5;
    [SerializeField] Light crystalLight;
    [SerializeField] Material crystalSpecialMaterial;
    [SerializeField] Color PointLightColor;
    [SerializeField] AnimationCurve PointLightIntensityOverLife;
    [SerializeField] Gradient EmissionColorOverLife;
    [SerializeField] Player player;


    private Material InitialMaterial;

    float startTime = -60;

	// Use this for initialization
	void Start () {
        //col = GetComponent<CapsuleCollider>();
        ss = StateSingleton.get();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            switch (bellNum)
            {
                case 0:
                    player.awarenessBell.Emit(25f);
                    break;
                case 1:
                    player.airBell.Emit(25f);
                    break;
                case 2:
                    player.fireBell.Emit(25f);
                    break;
                case 3:
                    player.waterBell.Emit(25f);
                    break;
                case 4:
                    player.earthBell.Emit(25f);
                    break;
                case 5:
                    player.enlightenmentBell.Emit(25f);
                    break;
                default:
                    break;

            }
            bellSource.clip = bellSounds[bellNum];
            bellSource.Play();
            Debug.Log("Bell Attained");
            ss.bells[bellNum] = true;
            Destroy(this.gameObject);
        }
    }
    /*void Ping(BellEventType type, Transform transform, float delay)
    {
        if (Time.realtimeSinceStartup - startTime > duration)
        {
            startTime = Time.realtimeSinceStartup + delay;
        }
    }*/
}
