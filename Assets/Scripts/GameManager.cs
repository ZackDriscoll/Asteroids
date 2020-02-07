using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject starShipPrefab;
    public GameObject player;
    public GameObject enemy;
    public static GameManager instance;
    public int lives = 3;
    public int score = 0;
    public bool isPaused = false;

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
    }

    public void Respawn()
    {
        Instantiate(playerPrefab);
    }
}
