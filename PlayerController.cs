using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    public float speed = 20.0f;

    // Private Variables
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    private float jumpForce = 10000;
    private Rigidbody playerRb;
    private bool isOnGround;

    private SpawnManager spawnManager;
=======
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 10;
    public float doubleJumpForce = 50;
    public float gravityModifier;
    public int jumpCounter = 0;
    public bool isOnGround = true;
    public bool gameOver;
>>>>>>> origin/master

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
<<<<<<< HEAD
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
=======
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
>>>>>>> origin/master
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (spawnManager.isGameActive)
        {
            // This is where we get player input
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // Move the vehicle forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // We turn the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //If player is on ground road, isOnGround is true
        if(collision.gameObject.CompareTag("Ground Road"))
        {
            isOnGround = true;
        }

        //If player collides with Sensor, game is cleared!
        if (collision.gameObject.CompareTag("Sensor"))
        {
            spawnManager.GameClear();
        }
=======
        if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && jumpCounter == 1 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            isOnGround = false;
            jumpCounter++;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.3f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            jumpCounter++;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCounter = 0;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

>>>>>>> origin/master
    }
}
