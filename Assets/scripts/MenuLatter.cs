using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLatter : MonoBehaviour {

    public string TextLatter;
    private Text MenuTextLatter;


    private void Awake()
    {
        MenuTextLatter = GameObject.Find("MenuTextLatter").GetComponent<Text>();
       
    }

    public void NewTextMenuLatter()
    {
        MenuTextLatter.text = TextLatter;

        }

}
