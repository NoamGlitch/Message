using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoss : MonoBehaviour
{
    private Collider2D coll;
    public LayerMask ground;
    public LayerMask player;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouchingLayers(ground))
        {
            Destroy(gameObject);
        }

        if (coll.IsTouchingLayers(player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Debug.Log("you need to die");
        } 
    }

     private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Debug.Log("you need to die");
        }
    } 
}
