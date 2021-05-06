using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fellow"))
        {
            gameObject.SetActive(false);
        }
    }
}
