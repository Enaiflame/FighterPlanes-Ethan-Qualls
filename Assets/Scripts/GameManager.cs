using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 9.5f;
        verticalScreenSize = 5.5f;
        score = 0;
        ChangeScoreText(score);

        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateCoin", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize + 1, horizontalScreenSize - 1), verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize + 3, horizontalScreenSize - 3), Random.Range(-verticalScreenSize + 2, verticalScreenSize - 2), 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void ChangeScoreText(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;
    }
}
