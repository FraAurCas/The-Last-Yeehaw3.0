using UnityEngine;

public class PewController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, speed);
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Destroy(gameObject, 0.75f);
    }
}