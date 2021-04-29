using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_trigger : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Fellow3>().Keys++;
            other.GetComponent<Fellow3>().CheckLimt();
            Destroy(gameObject);

        }
    }

}
