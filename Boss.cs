using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public float spawningTime = 3;
    public GameObject MainCam;
    public GameObject BossCam;
    public int objectNumToSpawnToWin = 8;
    public float yHeight = 3.8f;
    
    public GameObject[] objectsToFall;
    public GameObject player;
    public GameObject afterBossPlatform;

    public MusicManager audio;

    public AudioSource bossVoice;
    public AudioClip talkingVoice;
    public AudioClip nothappyVoice;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        
        MainCam.SetActive(false);
        BossCam.SetActive(true);

        audio.SetState(MusicState.BOSSBATTLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StopCoroutine(ObjectSpawner());
            anim.SetInteger("state", 2);
        }

        
        
    }
    
    IEnumerator ObjectSpawner()
    {
        for (int i = 0; i < objectNumToSpawnToWin; i++)
        {
            int randObject = Random.Range(0, objectsToFall.Length);
            //int randPos = Random.Range(-2.15f, 3.68f);
            if(i != 0) yield return new WaitForSeconds(spawningTime);
            else yield return new WaitForSeconds(1);
            Instantiate(objectsToFall[randObject], new Vector3(player.transform.position.x, yHeight),
                Quaternion.identity);

            
        }
        
        anim.SetInteger("state", 2);
        
    }
    

    void ToRegular()
    {
        anim.SetInteger("state", 1);
        StartCoroutine(ObjectSpawner());
    }

    void OpenWay()
    {
        MainCam.SetActive(true);
        BossCam.SetActive(false);
        
        afterBossPlatform.SetActive(true);

        audio.SetState(MusicState.NORMAL);
    }

    void FirstTalk()
    {
        print("First Talk");
        bossVoice.PlayOneShot(talkingVoice);
    }

    void SecondTalk()
    {
        bossVoice.PlayOneShot(nothappyVoice);
    }
    
    
}
