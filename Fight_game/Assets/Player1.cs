﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {
    public float maxspeed = 9f;
    public float speed = 2f;
    public bool grounded;
    public float jumpForce = 6.5f;
    public GameObject healthbar;
    public GameManager gm;
    public GameObject Poder1;
    public GameObject salida;
    float hp, maxhp;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        salida = GameObject.Find("Salida_poderes");
        Poder1 = GameObject.Find("Fuego");
        maxhp = 100;
        hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.U) && grounded)
        {
            jump = true;
        }
        if (isdead())
        {
            anim.SetBool("Died", true);
            FindObjectOfType<GameManager>().gameover();
        }
    }
    private void FixedUpdate()
    {
        //MOVERSE
        bool izq = Input.GetKey("h");
        bool der = Input.GetKey("k");

        if (izq == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb2d.AddForce(Vector2.left * speed * 5);
        }
        if (der == true)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb2d.AddForce(Vector2.right * speed * 5);
        }

        float limitedspeed = Mathf.Clamp(rb2d.velocity.x, -maxspeed, maxspeed);
        rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);

        //ATACAR
        bool atack1 = Input.GetKey("z");
        bool atack2= Input.GetKey("x");

        if (atack1 == true)
        {
            anim.SetBool("Isatack", atack1);
        }
        else
        {
            anim.SetBool("Isatack", false);
        }

        if (atack2 == true )
        {
            Instantiate(Poder1, salida.transform.localPosition, Quaternion.identity);
        }
        else
        {
            atack2 = false;
        }

        //SALTAR
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce * 1.3f, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ataque")
        {
            healthbar.SendMessage("takedamage", 50);
            hp -= 50;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    public bool isdead()
    {
        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
