using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject WalkingGhost;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(WalkingGhost, transform.position, Quaternion.identity);

        
    }

    
}
