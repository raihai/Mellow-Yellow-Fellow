using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class ghost : MonoBehaviour
{
    public NavMeshAgent agent;

   [SerializeField]
    public Fellow player;

   Vector3 LeftTeleporter;
   Vector3 RightTeleporter;

    Vector3 startPosition;

    [SerializeField]
    public Material scaredMaterial;
    public Material normalMaterial;



    public bool CanSeePlayer()
    {
        Vector3 rayPos = transform.position;
        Vector3 rayDir = (player.transform.position - rayPos).normalized;

        RaycastHit info;
        if(Physics.Raycast(rayPos, rayDir, out info))
        {
            if (info.transform.CompareTag("Fellow"))
            {
                return true;
            }
        }
        return false;


    }


    // Start is called before the first frame update
    void Start()
    {

        LeftTeleporter = new Vector3(0.1f, 0.7f, 7f);
        RightTeleporter = new Vector3(14.8f, 0.7f, 7f);

        agent = GetComponent<NavMeshAgent>();
       
        agent.destination = PickRandomPosition();

        normalMaterial = GetComponent<Renderer>().material;

        startPosition = new Vector3(7.5f, 0.1f, 6.5f);

      



    }
    

    public Vector3 PickRandomPosition()
    {
        Vector3 destination = transform.position;
        Vector2 randomDirection = Random.insideUnitCircle * 8.0f;
        destination.x += randomDirection.x;
        destination.z += randomDirection.y;

        NavMeshHit navHit;
        NavMesh.SamplePosition(destination, out navHit, 8.0f, NavMesh.AllAreas);

        return navHit.position;
    }
    
    public Vector3 PickingHidingPlace()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        NavMeshHit navHit;
        NavMesh.SamplePosition(transform.position - (directionToPlayer * 8.0f), out navHit, 8.0f, NavMesh.AllAreas);

        return navHit.position;
    }

    public bool hiding = false;

    // Update is called once per frame
    public virtual void Update()
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
                GetComponent<Renderer>().material = normalMaterial;
            }
            else if (agent.remainingDistance < 0.5f)
            {
                agent.destination = PickRandomPosition();
                hiding = false;
                GetComponent<Renderer>().material = normalMaterial;
            }


        }
    
    }

   
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("RightTeleport"))
        {
            agent.Warp(LeftTeleporter);
        }

        if (other.gameObject.CompareTag("LeftTeleport"))
        {
            agent.Warp(RightTeleporter);
        }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Fellow"))
        {
            
            agent.Warp(startPosition);

        }


    }


}
