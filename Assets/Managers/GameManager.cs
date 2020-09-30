using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Making a singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The Game Manager is null.");
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;
    }
    public GameObject powerup;
    public bool powerUp = false;

    //UI manipulation
    public Text scoreText;
    public int playerScore, tempScore;

    private void Update()
    {
        playerScore += tempScore;
        tempScore = 0;
        scoreText.text = "SCORE - " + playerScore;
        PowerUpSpawn();
    }
    //Adding score
    public void AddScore(int score)
    {
        tempScore = score;
    }

    //Enemies control
    private const int _maxEnemies = 7;
    public int enemiesSpawned = 0;

    public void PowerUpSpawn()
    {
        if(playerScore > 300 && powerUp == false)
        {
            Instantiate(powerup, new Vector2(Random.Range(-10, 10), 7), Quaternion.identity);
            powerUp = true;
        }
    }
}
