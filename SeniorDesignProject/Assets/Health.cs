using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float infectionScore = 0;
    
    private void OnTriggerStay2D(Collider2D infected)
    {
        if(infected.tag == "Enemy")
        {
            infectionScore+=(float) 0.02;
            //infectionScore = Mathf.Floor(infectionScore);
            //print("Infection Score " + Mathf.Floor(infectionScore));
            //print("Infection Score " + infectionScore);
        }
    }

    private void OnTriggerExit(Collider infected) 
    {
        infectionScore+=0;
        
    }
}
