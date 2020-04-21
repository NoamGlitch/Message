using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    public float movingPower = 17;
    public float jumpForce = 17;
    public LayerMask ground;
    public GameObject boss;

    public AudioSource stepSFX;
    public AudioSource jumpSFX;
    public AudioSource enemyDie;

    private enum State
    {
        Idle, Walking, Jumping, Falling
    }

    private State state = State.Idle;

    private bool hasPressedJump = false;
    
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
       
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            if (state == State.Falling)
            {
                enemyDie.Play();    
                Destroy(other.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                state = State.Jumping;
            }
            else
            {
                gameManager.Restart();
            }
        }
        
        if (other.collider.tag == "BossObject")
        {
            //Debug.Log("tag detected");
            transform.position = transform.position + Vector3.zero;
            gameManager.Restart();
            //Debug.Log("you are dead");
            
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            gameManager.Restart();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.tag == "BossSummon")
        {
            boss.SetActive(true);
        }
        
        if (other.tag == "PortalOut")
        {
            gameManager.Victory();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.Jumping;
        }
    }

    void FixedUpdate()
    {

        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-movingPower, rb.velocity.y);
            transform.localScale = new Vector3(1, 1);
        }
        
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(movingPower, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1);
            
        }
        else
        {
            
        }

        
        
        AnimationState();
        anim.SetInteger("state", (int) state);
    }
    

    void AnimationState()
    {
        if (state == State.Jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.Falling;
            }
        }

        else if (state == State.Falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.Idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > .1f)
        {
            state = State.Walking;
        }

        
        else
        {
            state = State.Idle;
        }
    }

    
    void Step()
    {
        stepSFX.Play();
    }
}
