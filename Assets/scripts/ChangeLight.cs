using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour {

    private bool isOpen = false;
    private Light[] light;
    private InteractObj Interact;

    void Start()
    {
        light = GetComponentsInChildren<Light>();
        Interact = GetComponentInParent<InteractObj>();
        
    }


    void Update () {
        if (Interact.open) {
            for(int i = 0; i< light.Length;i++)
            light[i].intensity = 1;
        }
        else for (int i = 0; i < light.Length; i++)
                light[i].intensity = 0; 
    }
}
