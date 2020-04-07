using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class playerController : MonoBehaviour
{

    // 0  = disabled
    public float border;
    private SpriteRenderer sr;
    private bool direction; // true is flipped, false is not flipped
    private Rigidbody2D rb;
    public bool isOnSurface = true;
    public float jumpForce;
    public int ladderSpeed = 10;
    private bool isOnLadder = false; // Debugs a clash between the ladder collider and the floor collider
    public Vector3 spawnpoint;
    public bool isAscending = false;
    public bool isDescending = false; // TODO: this should tell the camera when it's appropiate to go down    

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        Game game = new Game("New Game", 1, Game.Difficulty.MEDIUM);
        string json = JsonUtility.ToJson(game);
        using (StreamWriter sw = File.CreateText("/Users/patrickmenendez/Downloads/JamCraft/saves/Database.json"))
        {
            sw.WriteLine(json);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y <= -18 || 18 <= this.transform.position.y || this.transform.position.x <= -32 || 32 <= this.transform.position.x)
        {
            this.transform.position = spawnpoint;
        }
         if ((int)(border) == 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (!direction)
                {
                    sr.flipX = false;
                }

                transform.Translate(1 / 2f, 0, 0);

            }
        } else if (transform.position.x <= border) 
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (!direction)
                {
                    sr.flipX = false;
                }

                transform.Translate(1 / 2f, 0, 0);

            }
        }
        
    

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 / 2f, 0, 0);

            if (!direction)
            {
                sr.flipX = true;
            }

        }
        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnSurface && !isOnLadder)
        {
            rb.AddForce(new Vector2(0,jumpForce));
           
        }
    }




    // Not working properly 100% of the times

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            isOnSurface = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnSurface = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            isOnSurface = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            isOnSurface = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            rb.gravityScale = 0;
            isOnLadder = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            isOnLadder = true;
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(new Vector3(0, ladderSpeed, 0) * Time.deltaTime);
                isAscending = true;
                Debug.Log(isAscending);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            isOnLadder = false;
            isAscending = false;
            rb.gravityScale = 10;
            
        }
    }
}
