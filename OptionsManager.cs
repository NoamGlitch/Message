using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public AudioMixer audioMixer;

    public string audioTag;

    public void MasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }
    
    public void SfxVolume(float volume)
    {
        audioMixer.SetFloat("SfxVol", volume);
    }
    
    public void EntitiesVolume(float volume)
    {
        audioMixer.SetFloat("EntitiesVol", volume);
    }
    
    public void MusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVol", volume);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        /* float value;
        slider = GetComponent<Slider>();
        
        bool isValue = audioMixer.GetFloat(audioTag, out value);

        if (isValue)
        {
            slider.value = value;
        }
        else
        {
            Debug.Log("no " + audioTag);
        } */
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
