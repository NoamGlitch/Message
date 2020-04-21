using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioMenu : MonoBehaviour
{

    // Start is called before the first frame update
    /*void Start()
    {
        if (PlayerPrefs.GetInt("isPlaying") != 1 )
        {
            PlayerPrefs.SetInt("isPlaying", 1 ); // 1 - yes playing, 2 - no playing
            DontDestroyOnLoad(this.gameObject);    
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlayerPrefs.SetInt("isPlaying", 2);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.N)) PlayerPrefs.SetInt("isPlaying", 2);
    }
    
    
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("isPlaying", 2);
    }*/
}
