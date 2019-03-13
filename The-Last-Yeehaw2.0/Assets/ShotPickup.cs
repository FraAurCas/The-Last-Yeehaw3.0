using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPickup : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, speed);
        Destroy(gameObject, 30f);
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0f);
        }
    }
}