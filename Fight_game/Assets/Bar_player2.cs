using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_player2 : MonoBehaviour {
    public Image health;

    float hp, maxhp;
    void Start()
    {
        maxhp = 1;
        hp = maxhp;
    }

    public void takedamage(float damage)
    {
        hp = Mathf.Clamp(hp - damage/100, 0f, maxhp);
        health.transform.localScale = new Vector2(hp, 1);
    }
}
