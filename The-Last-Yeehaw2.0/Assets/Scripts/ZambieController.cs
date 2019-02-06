using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZambieController : MonoBehaviour
{
    Transform player;
    PlayerMovement pHealth;

    public int zStartHealth = 100; 
    public int zHealth;
    public PlayerMovement playerHealth;
    public PlayerMovement pTakeDamage;
    public GameObject Zambie;
    

    CapsuleCollider capsuleCollider;      
    bool isDead;
    public float speed = 1.0f;
    private Transform target;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        zHealth = zStartHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerMovement>();

        target = player.transform;
    }

    void Update()
    {
        if(zHealth > 0 && playerHealth.pHealth > 0)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            return;
        }
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.tag == "Pew")
        {
            TakeDamage(50);
        }
        else if (collision.gameObject.tag == "sPew")
        {
            TakeDamage(101);
        }
        else if (collision.gameObject.tag == "mPew")
        {
            TakeDamage(34);
        }
        else if (collision.gameObject.tag == "Player")
        {
            playerHealth.pTakeDamage(33);
        }


    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {

            return;
        }
        zHealth -= amount;

        if (zHealth <= 0)
        {
            zDeath();
        }
    }

    
    void zDeath()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        Destroy(gameObject);
    }

}