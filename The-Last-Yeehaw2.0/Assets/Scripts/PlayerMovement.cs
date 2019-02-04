using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerHealth = 99;
    public int pHealth;
    public float speed;

    public GameObject EndCanvas;

    bool isDead;

    public GameObject Zambie;
    public ZambieController zStartHealth;
    public GameObject Pew;
    public Transform shotSpawn;
    public float fireRate;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private float nextFire;

    void Awake()
    {
        pHealth = playerHealth;
    }

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Pew, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void pTakeDamage(int amount)
    {
        pHealth -= amount;
        if(pHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Spawn()
    {
        if (pHealth <= 0f)
        {
            return;
        }
        else if (pHealth > 0f)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(Zambie, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
    void Death()
    {
        isDead = true;
        Vector3 movement = new Vector3(0, 0.0f, 0);
        GetComponent<Rigidbody>().velocity = movement * 0;
        Destroy(gameObject, 0.0f);
        EndCanvas.SetActive(true);
        

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -10.0f, 10.0f), 0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, -4.0f, 4.0f)
        );
    }
}