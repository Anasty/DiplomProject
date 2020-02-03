using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class MenuControls : MonoBehaviour
    {

        private GameObject Menu;
        private GameObject MenuMain;
        private GameObject JMenu;

        public static GameObject Loading;
        public static GameObject MMmenu;
        public static bool flgContinue = false;
        public static Button LButton;


        void Start()
        {
            LButton = GameObject.Find("LatterButton1").GetComponent<Button>();
            GameObject.Find("MenuLatter").SetActive(false);
            JMenu = GameObject.Find("JurnalMenu");
            JMenu.SetActive(false);
            MMmenu = GameObject.Find("MainMenu");
            Loading = GameObject.Find("Loading");
            Menu = GameObject.Find("CanvasMenu");
            MenuMain = GameObject.Find("PanelMenu");
            Loading.SetActive(false);
        }

        public void ContinuePressed()
        { 
           
            MMmenu.SetActive(false);
            flgContinue = true;
            Debug.Log("Continue!");
        }

        public void PlayPressed()
        {

            flgContinue = true;
            MenuMain.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            MMmenu.SetActive(false);
            DontDestroyOnLoad(Menu);
            SceneManager.LoadScene("Test001");
         
        }

        public void ExitPressed()
        {
            Debug.Log("Exit pressed!");
          
            Application.Quit();

        }
    }
}