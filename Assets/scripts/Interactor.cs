using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Interactor : MonoBehaviour {

    [SerializeField] private float Range;
    [SerializeField] private AudioClip GetObjSound;
    private FirstPersonController ChangeFPS;
    private InteractObj interactObject;
    private Camera cam;
    private RaycastHit hit;
    private ReticleContoller reticleController;
    private List<int> keys = new List<int>();
    private GameObject flashlight;
    private bool statusLight = false;
    private bool statusSit = false;
    private Vector3 transform;
    private GameObject Latter;
    private GameObject LatterText;
    private bool latterFlg = false;
    

    private GameObject FPS;

    private AudioSource Audio;


    void Start () {
        cam = Camera.main;
        reticleController = GameObject.FindObjectOfType<ReticleContoller>();
        FPS = GameObject.Find("FPSController");
        keys.Add(-1);
        flashlight = GameObject.Find("Flashlight");
        flashlight.SetActive(statusLight);
        Audio = GetComponent<AudioSource>();
        ChangeFPS = FPS.GetComponent<FirstPersonController>();
        Latter = GameObject.Find("Latter");
        LatterText = GameObject.Find("LatterText");
        Latter.SetActive(false);
        
    }
	
	
	void Update () {


        transform = FPS.transform.localPosition;
        //поидеи это все реализовать в отдельном классе, либо в классе фпс.
        if (Input.GetKeyDown("c")) {
            if (statusSit == false)
            {
                FPS.transform.localScale = new Vector3(1.2f, 0.4f, 1.2f);
                transform.y = transform.y / 1.2142854804f;
                ChangeFPS.m_WalkSpeed = 1.5f;

            }
            else {
                FPS.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                transform.y = transform.y * 1.2142854804f;
                ChangeFPS.m_WalkSpeed = 3;
            }
            FPS.transform.localPosition = transform;
            statusSit = !statusSit;
        }

        if (Input.GetKeyDown("f")) {
            statusLight = !statusLight;
            flashlight.SetActive(statusLight);
            NoText();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //SceneManager.LoadScene("Menu");// тут пока так, потом поменять если плохо работает
            
        }
            
        




        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range);

        if (hit.transform)
        {
            interactObject = hit.transform.GetComponent<InteractObj>();


            if (interactObject)
            {
                if (interactObject.tag == "Hide")
                {
                    interactObject.ChangeText();

                    if (Input.GetKeyDown("e")) {
                        FPS.transform.localPosition = interactObject.hidePosition;
                        FPS.transform.localScale = new Vector3(2, 0.2f, 2);
                        ChangeFPS.m_WalkSpeed = 0;
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {

                  

                    if (interactObject.tag == "Door")
                    {
                        if (interactObject.id == -1)
                        {
                            interactObject.Action();
                            //       interactObject = null;
                        }

                        else
                            for (int i = 0; i < keys.Count; i++)
                                if (interactObject.id == keys[i])
                                {
                                    interactObject.Locked();

                                }
                        //   openDoor.ChangeText();
                    }

                    else if (interactObject.tag == "Key")
                    {
                        keys.Add(interactObject.id);
                        interactObject.GetObject();
                        Audio.clip = GetObjSound;
                        Audio.Play();
                        //           openDoor.ChangeText();
                        //           openDoor = null;                        
                    }
                    else if(interactObject.tag == "Latter")
                    {
                        MenuControls.LButton.interactable = true;
                        Latter.SetActive(true);
                        latterFlg = true;
                        LatterText.GetComponent<Text>().text = interactObject.Text1;
                        interactObject.GetObject();

                    }
                    if(interactObject.tag != "Latter")
                        interactObject.ChangeText();
                    interactObject = null;
                    Invoke("NoText", 3);
                }
            }
            
        }
        if(!hit.transform && interactObject)
        {
            interactObject = null;
            NoText();
        }
        if (latterFlg && Input.GetMouseButtonDown(1))
        {
            Latter.SetActive(false);
            latterFlg = false;
        }
        
        reticleController.ShowIcon(interactObject);

        
    }

    private void NoText()
    {
        if (GameObject.Find("Text").GetComponent<Text>().text != "")
            GameObject.Find("Text").GetComponent<Text>().text = "";
    }
}
