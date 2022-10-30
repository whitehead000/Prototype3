using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject busPrefab;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameClear;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject[] obstaclePrefabs;
    
    public bool isGameActive;

    
    private float spawnRangeX = 7.0f;
    private float minSpawnPosZ = -180.0f;
    private float maxSpawnPosZ = 580.0f;
    private float spawnInterval = 4.0f;
    private float gameClearRestartInterval = 4.0f;

    private PlayerController playerController;
=======

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;

    private float startDelay = 2;
    private float repeatRate = 2;
>>>>>>> origin/master

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        playerController = GameObject.Find("Vehicle").GetComponent<PlayerController>();
        
=======
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
>>>>>>> origin/master
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
    

    IEnumerator SpawnRandomBus()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPos;

            //Spawn bus three times
            for (int i = 0; i < 3; i++)
            {
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(minSpawnPosZ, maxSpawnPosZ));
                Instantiate(busPrefab, spawnPos, busPrefab.transform.rotation);
            }

            //Spawn obstacle
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(minSpawnPosZ, maxSpawnPosZ));
            int obstacleIndex = Random.Range(0, 3);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;

        spawnInterval /= difficulty;
        playerController.speed /= difficulty;

        StartCoroutine(SpawnRandomBus());
        titleScreen.gameObject.SetActive(false);
    }

    public void GameClear()
    {
        gameClear.gameObject.SetActive(true);
        isGameActive = false;

        StartCoroutine(GameClearRestartGame());
        
    }

    IEnumerator GameClearRestartGame()
    {
        yield return new WaitForSeconds(gameClearRestartInterval);
        RestartGame();
=======
    void spawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
            
        }
      
>>>>>>> origin/master
    }
}
