using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorLight : MonoBehaviour {

    private Light light;
    public AudioClip BlinkSound;
    public int NeedTime = 0;

    private AudioSource Audio;
    private float time = 0;
    private bool CheckTrigger;
    private int rnd;
    private int tick = -1;
    private bool checkedflag = false;

    private bool checkedTrigger;

    // Use this for initialization
    void Start() {
        light = GetComponentInChildren<Light>();
        Audio = GetComponent<AudioSource>();
        
    }


    private void Blink() {

        Audio.clip = BlinkSound;
        Audio.Play();
    }

    // Update is called once per frame
    void Update () {
        

        if(!checkedflag)
            checkedTrigger = GetComponentInParent<HorrorTrigger>().checkTrigger;
        
        if (checkedTrigger) {
            checkedflag = true;

            if (time < NeedTime)
            {
                if (tick == -1) Blink();
                if (tick == 5)
                {
                    rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        light.intensity = 0;
                    }
                    if (rnd == 1)
                    {
                        light.intensity = 1;
                    }
                    tick = 0;
                }
                else tick++;
                time += 0.1f;
              
               // Debug.Log(time);
            }
            else {light.intensity = 0; checkedTrigger = false; }
        }
	}

}
