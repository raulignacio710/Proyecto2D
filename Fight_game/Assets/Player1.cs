using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    public float maxspeed=5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpForce = 6.5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded || Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
	}
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (h < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        rb2d.AddForce(Vector2.right* speed *h);
        float limitedspeed = Mathf.Clamp(rb2d.velocity.x, -maxspeed, maxspeed);
        rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce*1.3f, ForceMode2D.Impulse);
            jump = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
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
}
