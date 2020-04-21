using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int playIndex;
    public int optionIndex;
    public int creditIndex;
    public AudioSource btnSfx;
    public AudioClip clickFx;
    
    public void PlayBtn()
    {
        btnSfx.PlayOneShot(clickFx);
        SceneManager.LoadScene(playIndex);
    }
    
    public void Options()
    {
        btnSfx.PlayOneShot(clickFx);
        SceneManager.LoadScene(optionIndex);
    }
    
    public void Credits()
    {
        btnSfx.PlayOneShot(clickFx);
        SceneManager.LoadScene(creditIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
