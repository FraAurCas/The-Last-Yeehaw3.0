using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public PlayerMovement pHealth;
    public PlayerMovement ammoShot;
    public PlayerMovement ammoMachine;
    public Text shotPew;
    public Text machinePew;
    public Text health;



    // Start is called before the first frame update
    void SetHUDText()
    {
        health.text = "Health: " + pHealth.ToString();
        shotPew.text = "Health: " + ammoShot.ToString();
        machinePew.text = "Machine Pew: " + ammoMachine.ToString();
    }
}
