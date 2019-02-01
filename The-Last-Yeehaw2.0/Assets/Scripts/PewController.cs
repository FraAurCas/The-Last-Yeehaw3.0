using UnityEngine;

public class PewController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, speed);
    }
}