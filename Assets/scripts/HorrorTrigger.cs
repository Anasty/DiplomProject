using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorTrigger : MonoBehaviour {

    public bool checkTrigger = false;

    public AudioClip HorrorSound;
    private AudioSource Audio;
    public int Delay = 0;
    private int times = 0;

    void Start()
    {
        if (this.tag == "AnimHorror")
        {
            Audio = GetComponent<AudioSource>();
        }
    }

    private void BooAnimation() {
        GetComponentInChildren<Animation>().Play("Boo");

        Audio.clip = HorrorSound;
        Audio.Play();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Бу!");

        
        checkTrigger = true;
        GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (checkTrigger)
            if (this.tag == "AnimHorror")
            {
                if (Delay > 0)
                {


                    if (times > 300)
                    {
                        BooAnimation();
                        checkTrigger = false;
                    }
                    else { times++; }
                }
                else { BooAnimation(); checkTrigger = false; }


            }
    }
}
