using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject asteroidPrefab;
    public GameObject player;
    public Transform spawnPoint;

    public static GameManager instance;
    public int lives = 3;
    public int score = 0;
    public bool isPaused = false;
    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] enemyPrefabs;

    public float waitTime = 1.0f;
    public float timer = 0.0f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second Game Manager.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            SpawnEnemies();
            timer = timer - waitTime;
        }
    }

    public void SpawnEnemies()
    {
        if (enemiesList.Count < 2)
        {
            Instantiate(asteroidPrefab, new Vector3(Random.Range(-5, 5), Random.Range(-4, 4), 0), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-10, -5), Random.Range(-4, 4), 0), Quaternion.identity);
        }
    }

    public void Respawn()
    {
        player = Instantiate(playerPrefab);
    }
}
