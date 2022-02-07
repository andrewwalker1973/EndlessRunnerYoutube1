using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;         // Make this s static instance so that we can call it from anywhere

    void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI scoreText;           //TextMesh Pro Text Field for score
    public TextMeshProUGUI coinScoreText;         //TextMesh Pro Text Field for Hiscore
    public TextMeshProUGUI crystalScoreText;         //TextMesh Pro Text Field for Hiscore

    private int coinScore, crystalScore;
    private float scoreCount, pointsPerSecond=1, hiScoreCount;
    public int totalCoinScore, totalCrystalScore;

    public bool scoreIncreasing, highScoreAchieved;                // is score increasing ? dont want to increase while dead

    private PlayerMotor thePlayerMotor;     

    private void Start()
    {
        thePlayerMotor = FindObjectOfType<PlayerMotor>();
        //Set HUD to defualt values to start
        scoreText.text = "" + Mathf.Round(0);
        coinScoreText.text = "" + Mathf.Round(0);
        crystalScoreText.text = "" + Mathf.Round(0);
    }

    private void Update()
    {
        if (scoreIncreasing && thePlayerMotor.isRunning)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;     // how much to increase by per second
        }

        scoreText.text = "" + Mathf.Round(scoreCount);           // set the scorecout on screen rount to solid number


    }


    public void AddCoins(int coinsToAdd)
    {

        coinScore += coinsToAdd;      // Add coins 
        totalCoinScore += coinsToAdd;    // Add to total coin score to be used for achievemnt matching
        coinScoreText.text = "" + Mathf.Round(coinScore);           // set the coin count on screen rount to solid number
    }


    public void AddCrystals(int crystalsToAdd)
    {
        crystalScore += crystalsToAdd;             // add crystals
        totalCrystalScore += crystalsToAdd;      // add to total crystal score to be used for achievemnt matchin
        crystalScoreText.text = "" + Mathf.Round(crystalScore);           // set the Crystal count on screen rount to solid number

    }

    public void SaveHighScore()
    {

        if (scoreCount > hiScoreCount)                      // if score > hghscore update highscore
        {
            Debug.Log("Save high score");

            hiScoreCount = scoreCount;                      // update highscor
            highScoreAchieved = true;

           
        }
    }
}
