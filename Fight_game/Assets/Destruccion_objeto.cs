using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruccion_objeto : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
