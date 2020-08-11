using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "OffScreen")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

       
    }
}
