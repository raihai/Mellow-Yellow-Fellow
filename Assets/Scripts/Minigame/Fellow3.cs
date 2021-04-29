using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fellow3 : MonoBehaviour
{
    public Text progressUI;
    public int Keys = 0;
    public int KeyLimit = 7;

    public GameObject gate;


    public Rigidbody rigid;
    public float horizontal;
    public float vertical;
    public float speed = 15;

    // Start is called before the first frame update
    void Start()
    {

        progressUI.text = "Keys Taken: 0\nKeys Remaining: " + KeyLimit;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody b = GetComponent<Rigidbody>();
        Vector3 velocity = b.velocity;

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z = -speed;
        }
        b.velocity = velocity;



    }

    public void CheckLimt()
    {
        progressUI.text = "Keys: " + Keys + "\nKeys Remaining: " + (KeyLimit - Keys);

        if (Keys >= KeyLimit)
        {
            gate.SetActive(false);
        }
    }
}