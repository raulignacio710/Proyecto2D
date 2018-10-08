using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_fuego : MonoBehaviour {

    public bool lanzado = false;

    private Animator anim;
    private Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb2d.transform.Translate(new Vector3(-4, 4, 0) * Time.deltaTime);
    }
}