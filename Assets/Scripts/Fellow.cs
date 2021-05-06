using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fellow : MonoBehaviour
{  
    
    [SerializeField]
    float speed = 0.05f;

    int score = 0;
    int pelletEaten = 0;
    [SerializeField]
    int pointsPerPellet = 100;


    [SerializeField]
    float powerupDuration = 5.0f;

    float powerupTime = 0.0f;
    float powerupTimeFroze = 0.0f;

    Vector3 leftTeleporter;
    Vector3 rightTeleporter;

    Vector3 startPosition;

    public GameObject[] hearts;
    public int livesRemaining;
    public bool dead;

    public Text scoreCount;
    public int currentScore;

    public GameObject[] ghosts;
    public string savedScore;
    public AudioSource deathSound;






    void Start()
    {
        string nname = SceneManager.GetActiveScene().name;

        leftTeleporter = new Vector3(0.1f, 0.7f, 7f);
        rightTeleporter = new Vector3(14.8f, 0.7f, 7f);

        livesRemaining = hearts.Length;

        startPosition = transform.position;

        scoreCount.text = "Score: 0";

        if(nname == "Level1")
        {
            PlayerPrefs.SetInt(savedScore, 0);
        }
        else { score = PlayerPrefs.GetInt(savedScore); }
    

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pellet"))
        {
            pelletEaten++;
            score += pointsPerPellet;
            Debug.Log("Score is" + score);
            scoreCount.text = "Score:\n" + score;
        }

        if (other.gameObject.CompareTag("Powerup"))
        {
            powerupTime = powerupDuration;
        }

        if (other.gameObject.CompareTag("FreezePowerup"))
        {
            powerupTimeFroze = powerupDuration;
            
        }

        if (other.gameObject.CompareTag("RightTeleport"))
        {
            transform.position = leftTeleporter;
        }

        if (other.gameObject.CompareTag("LeftTeleport"))
        {
            transform.position = rightTeleporter;
        }
    }

    public bool PowerUpActive()
    {
       
        return powerupTime > 0.0f;
    }

    public bool FreezePowerUpActive()
    {

        return powerupTimeFroze > 0.0f;
    }

    public int PelletsEaten()
    {
        return pelletEaten;
    }

    private void Update()
    {
        powerupTime = Mathf.Max(0.0f, powerupTime - Time.deltaTime);

        powerupTimeFroze = Mathf.Max(0.0f, powerupTime - Time.deltaTime);


        if (dead == true)
        {
            print("Back to the start!");

           
        }

       
    }
    

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

        PlayerPrefs.SetInt(savedScore, score);
    }

 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            ghosts = GameObject.FindGameObjectsWithTag("Ghost");
            foreach (GameObject ghosts in ghosts)
            {
                ghosts.transform.position = new Vector3(7.5f , 0f, 6.5f);
                
            }

            if (PowerUpActive() || FreezePowerUpActive())
            {
                print("");

            }          
            else if(livesRemaining >= 1)
            {
               
                transform.position = startPosition;
                    
                livesRemaining --;
                Destroy(hearts[livesRemaining].gameObject);

                if (livesRemaining < 1) 
                {
                    deathSound.Play();
                    dead = true;
                    currentScore = score;
                    PlayerPrefs.SetInt(savedScore, 0);
                }
            
                
            }
    
        }

       
    }
    
}
       

