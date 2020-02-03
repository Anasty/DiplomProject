using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer am;

    private bool isFullScreen = true;
    private Resolution[] rsl;
    private List<string> resolutions;
    public Dropdown dropdown;

    public void Awake()
    {
        
        resolutions = new List<string>();
        List<string> resolutionsUp = new List<string>();
        int len = 0;
        var availableResolutions = Screen.resolutions.Distinct().ToArray();
        rsl = availableResolutions;
        
        foreach(var i in rsl)
        {
            resolutionsUp.Add(i.width + "x" + i.height);
            len++;
        }
        for (int i = 0; i < len; i++) {
            resolutions.Add(resolutionsUp[resolutionsUp.Count - 1]);
            resolutionsUp.RemoveAt(resolutionsUp.Count - 1);
        }
        Debug.Log(len);
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("MasterVolume", sliderValue);
    }


    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
}
