using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {
    public bool lanzado = false;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lanzado == true)
        {
            anim.SetBool("lanzado", true);
        }		
	}
}
