using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState { NORMAL, BOSSBATTLE, VICTORY }

public class MusicManager : MonoBehaviour
{
    public AudioSource src;
    public AudioSource bossSrc;
    public AudioClip normalClip, bossClip, winClip;

    private void Start()
    {
    }

    public void SetState(MusicState state)
    {
        if(src == null) src = GetComponent<AudioSource>();

        if (state == MusicState.NORMAL)
        {
            bossSrc.Stop(); src.clip = normalClip;
        }
        
        else if (state == MusicState.BOSSBATTLE)
        {
            src.Stop(); bossSrc.Play();
        }

        else
        {
            bossSrc.Stop(); src.Play(); src.clip = winClip;
        }

        src.Play();
    }
}
