using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float health = 3f;
	void OnCollisionEnter2D(Collision2D info)
    {
        Debug.Log(info.relativeVelocity.magnitude);
        if (info.relativeVelocity.magnitude > health)
        {
            die();
        }

    }
    void die()
    {
        Destroy(gameObject);
    }
}
