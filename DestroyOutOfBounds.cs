using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float lowerBound = -10.0f;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < lowerBound && !gameObject.CompareTag("Player"))
        {
            Destroy();
        }
        if (gameObject.transform.position.y < lowerBound && gameObject.CompareTag("Player"))
        {
            spawnManager.GameOver();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
