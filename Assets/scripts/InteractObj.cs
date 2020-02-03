using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InteractObj : MonoBehaviour {

    public int id = -1;   
    public string Text1 = " ";
    public AudioClip OpenSound;
    public AudioClip CloseSound;
    public AudioClip LockedSound;
    public AudioClip GetSound;
    public Vector3 hidePosition;

    private AudioSource Audio;


    public bool open = false;


    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void ChangeText() {
        GameObject.Find("Text").GetComponent<Text>().text = Text1;
    }

    public void GetObject() {      
        Destroy(this.gameObject);
    }

    public void Locked() {
        id = -1;
        Text1 = "";
        Audio.clip = LockedSound;
        Audio.Play();
    }


     public void Action () {

        if (!open)
        {
            this.GetComponent<Animation>().Play("Open");
            Audio.clip = OpenSound;
            Audio.Play();
        }

        else
        {
            this.GetComponent<Animation>().Play("Close");
            Audio.clip = CloseSound;
            Audio.Play();
        }

            if (Input.GetMouseButtonDown(0))
        { open = !open; }

     } 
}
