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
    public GameObject ShotPew;
    public GameObject MachinePew;
    public Transform shotSpawn;
    public Transform shottySpawn1;
    public Transform shottySpawn2;
    public Transform shottySpawn3;
    public Transform shottySpawn4;
    public Transform shottySpawn5;
    public Transform shottySpawn6;
    public Transform shottySpawn7;
    public Transform shottySpawn8;
    public Transform shottySpawn9;
    public Transform shottySpawn10;
    public Transform machinePew;
    public float pFireRate;
    public float sFireRate;
    public float mFireRate;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private float nextFireS;
    private float nextFireP;
    private float nextFireM;

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
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireP)
        {
            nextFireP = Time.time + pFireRate;
            Instantiate(Pew, shotSpawn.position, shotSpawn.rotation);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFireS)
        {
            nextFireS = Time.time + sFireRate;
            Instantiate(ShotPew, shottySpawn1.position, shottySpawn1.rotation);
            Instantiate(ShotPew, shottySpawn2.position, shottySpawn2.rotation);
            Instantiate(ShotPew, shottySpawn3.position, shottySpawn3.rotation);
            Instantiate(ShotPew, shottySpawn4.position, shottySpawn4.rotation);
            Instantiate(ShotPew, shottySpawn5.position, shottySpawn5.rotation);
            Instantiate(ShotPew, shottySpawn6.position, shottySpawn6.rotation);
            Instantiate(ShotPew, shottySpawn7.position, shottySpawn7.rotation);
            Instantiate(ShotPew, shottySpawn8.position, shottySpawn8.rotation);
            Instantiate(ShotPew, shottySpawn9.position, shottySpawn9.rotation);
            Instantiate(ShotPew, shottySpawn10.position, shottySpawn10.rotation);
        }
        else if (Input.GetKey(KeyCode.LeftAlt) && Time.time > nextFireM)
        {
            nextFireM = Time.time + mFireRate;
            Instantiate(MachinePew, machinePew.position, machinePew.rotation);
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