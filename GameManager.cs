using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image fadeInScreen;
    private float alpha;
    public float fadeInTime = 1.5f;
    private float timer;

    public GameObject canvas;
    public GameObject pauseMenu;
    
    public Text winText, restartText;

    private Color startColor, endColor;
    private Color textStartColor, textEndColor;

    private bool victory;
    public MusicManager audio;


    private void Start()
    {
        canvas.SetActive(true);
    }

    private void OnEnable()
    {
        Reset();
    }

    private void Reset()
    {
        alpha = 1f;
        timer = 0;
        victory = false;

        startColor = Color.black;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        textEndColor = winText.color;
        textStartColor = new Color(textEndColor.r, textEndColor.g, textEndColor.b, 0);

        winText.color = textStartColor;
        restartText.color = textStartColor;

        audio.SetState(MusicState.NORMAL);
    }

    public void Update()
    {
        if(!victory)
        {
            timer += Time.deltaTime;

            if (timer < fadeInTime)
            {
                fadeInScreen.color = Color.Lerp(startColor, endColor, timer / fadeInTime);
            }
        }
        else
        {
            pauseMenu.SetActive(false);
            timer += Time.deltaTime;

            if (timer < fadeInTime)
            {
                fadeInScreen.color = Color.Lerp(endColor, startColor, timer / fadeInTime);
                winText.color = Color.Lerp(textStartColor, textEndColor, timer / fadeInTime);
                restartText.color = Color.Lerp(textStartColor, textEndColor, timer / fadeInTime);
            }
            else
            {
                if (Input.GetKey(KeyCode.R)) Restart();
                if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Victory()
    {
        victory = true;
        timer = 0;

        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        audio.SetState(MusicState.VICTORY);
    }
}
