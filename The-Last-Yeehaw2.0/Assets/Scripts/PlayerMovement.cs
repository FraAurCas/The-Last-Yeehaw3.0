using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int playerHealth = 99;
    public int pHealth;
    public float speed;

    public int ammoShot = 0;
    public int ammoMachine = 0;


    public GameObject EndCanvas;

    bool isDead;

    public GameObject ShotPickup;
    public GameObject MachinePickup;
    public GameObject HealthPickup;
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
    public Text shotPewT;
    public Text machinePewT;
    public Text healthT;
    CapsuleCollider capsuleCollider;

    public float spawnTimeS = 10f;
    public float spawnTimeZ = 3f;
    public float spawnTimeM = 7f;
    public float spawnTimeH = 15f;
    public Transform[] spawnPoints;
    public Transform[] ammoSpawns;

    private float nextFireS;
    private float nextFireP;
    private float nextFireM;

    void Awake()
    {
        pHealth = playerHealth;
    }

    void Start()
    {
        InvokeRepeating("SpawnZ", spawnTimeZ, spawnTimeZ);
        InvokeRepeating("SpawnS", spawnTimeS, spawnTimeS);
        InvokeRepeating("SpawnM", spawnTimeM, spawnTimeM);
        InvokeRepeating("SpawnH", spawnTimeH, spawnTimeH);
        SetHUDText();

    }

    public void pTakeDamage(int damage)
    {
        pHealth -= damage;
        if (pHealth <= 0)
        {
            isDead = true;
            Death();
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireP)
        {
            nextFireP = Time.time + pFireRate;
            Instantiate(Pew, shotSpawn.position, shotSpawn.rotation);

        }
        else if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFireS && ammoShot > 0)
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

            ammoShot -= 1;
            SetHUDText();
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Time.time > nextFireM && ammoMachine > 0)
        {
            nextFireM = Time.time + mFireRate;
            Instantiate(MachinePew, machinePew.position, machinePew.rotation);
            ammoMachine -= 1;
            SetHUDText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.tag == "sPickup")
        {
            ammoShot += 4;
            SetHUDText();
        }
        else if (collision.gameObject.tag == "mPickup")
        {
            ammoMachine += 10;
            SetHUDText();
        }
        else if (collision.gameObject.tag == "hPickup" && pHealth <99)
        {
            pHealth += 33;
            SetHUDText();
        }
    }
    

    void SpawnZ()
    {
        if (pHealth <= 0f)
        {
            return;
        }
        else if (pHealth > 0f)
        {
            int spawnPointIndexZ = Random.Range(0, spawnPoints.Length);
            Instantiate(Zambie, spawnPoints[spawnPointIndexZ].position, spawnPoints[spawnPointIndexZ].rotation);
        }
    }
    void SpawnS()
    {
        if (pHealth <= 0f)
        {
            return;
        }
        else if (pHealth > 0f)
        {
            int spawnPointIndexS = Random.Range(0, ammoSpawns.Length);
            Instantiate(ShotPickup, ammoSpawns[spawnPointIndexS].position, ammoSpawns[spawnPointIndexS].rotation);
        }
    }
    void SpawnM()
    {
        if (pHealth <= 0f)
        {
            return;
        }
        else if (pHealth > 0f)
        {
            int spawnPointIndexS = Random.Range(0, ammoSpawns.Length);
            Instantiate(MachinePickup, ammoSpawns[spawnPointIndexS].position, ammoSpawns[spawnPointIndexS].rotation);
        }
    }
    void SpawnH()
    {
        if (pHealth <= 0f)
        {
            return;
        }
        else if (pHealth > 0f)
        {
            int spawnPointIndexS = Random.Range(0, ammoSpawns.Length);
            Instantiate(HealthPickup, ammoSpawns[spawnPointIndexS].position, ammoSpawns[spawnPointIndexS].rotation);
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
    public void SetHUDText()
    {
        healthT.text = "Health: " + pHealth.ToString();
        machinePewT.text = "Machine Pew: " + ammoMachine.ToString();
        shotPewT.text = "Shot Pew: " + ammoShot.ToString();
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