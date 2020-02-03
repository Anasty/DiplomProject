using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologTriggerQvest : MonoBehaviour {


    public string Mon;
    public string Qv;
    private bool onTr = false;
    private GameObject Monolog;
    private GameObject Qvest;
    private GameObject QText;


    private void Start() {
        Monolog = GameObject.Find("Monolog");
        Qvest = GameObject.Find("Qvest");
        QText = GameObject.Find("TextQ");
        Monolog.SetActive(false);
        Qvest.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!onTr)
        {
            onTr = true;
            if (this.tag == "Monolog")
            {
                Monolog.SetActive(true);
                Monolog.GetComponent<Text>().text = Mon;
            }

            else if (this.tag == "Qvest")
            {
                Qvest.SetActive(true);
                QText.GetComponent<Text>().text = Qv;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.tag == "Monolog")
        {
            Monolog.SetActive(false);

        }

        else if (this.tag == "Qvest")
        {
            Qvest.SetActive(false);
  


        }
    }
}
