using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPlay : MonoBehaviour {

    public bool PlayAnimayion = false;
    public int times = 500;
    public int Needtimes = 1000;
 

    void PlayAnim() {
        this.GetComponent<Animation>().Play("Play");
    }

	
	
    void Update()
    {

        

        if (!PlayAnimayion)
            if (times == Needtimes)
            {
                PlayAnim();
                times = 0;
            }
            else
            {
                times++;
            
            }


    }


}
