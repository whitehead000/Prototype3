using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;

    // Private Variables
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    private float jumpForce = 10000;
    private Rigidbody playerRb;
    private bool isOnGround;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
