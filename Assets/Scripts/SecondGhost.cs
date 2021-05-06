using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondGhost : ghost
{
  
    
    public override void Update()
    {

        if (player.PowerUpActive())
        {
            Debug.Log(" Hiding from Player !");
            if (!hiding || agent.remainingDistance < 0.5f)
            {
                hiding = true;
                agent.destination = PickingHidingPlace();
                GetComponent<Renderer>().material = scaredMaterial;


            }
        }
        else if (player.FreezePowerUpActive())
        {
            
           
            StartCoroutine(waitFrozen());
            hiding = false;


        }
        else
        {
            Debug.Log(" Second ghost Chasing Player !");
            if (hiding)
            {
                GetComponent<Renderer>().material = normalMaterial;
                hiding = false;
            }
        
            if (agent.remainingDistance < 0.5f)
            {
                agent.destination = player.transform.position;
                hiding = false;
                GetComponent<Renderer>().material = normalMaterial;
            }
        }

        

    }

    
}
