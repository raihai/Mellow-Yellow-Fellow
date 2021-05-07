using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdGhost : ghost
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
            Debug.Log(" Chasing Player !");
            if (hiding)
            {
                GetComponent<Renderer>().material = normalMaterial;
                hiding = false;
            }
            if (CanSeePlayer())
            {
                Debug.Log("I can see you!");
                agent.destination = player.transform.position;
                hiding = false;
                //GetComponent<Renderer>().material = normalMaterial;
            }
            else if (agent.remainingDistance < 0.5f)
            {
                agent.destination = PickRandomPosition();
                hiding = false;
                GetComponent<Renderer>().material = normalMaterial;
            }
        }
    }


}
