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

    private int coinScore, crystalScore, spinnerCredits, beatHighScore;
    private float scoreCount, pointsPerSecond=1, hiScoreCount;
    public int totalCoinScore, totalCrystalScore;
    public float runningTime;

    public bool scoreIncreasing, highScoreAchieved;                // is score increasing ? dont want to increase while dead

    private PlayerMotor thePlayerMotor;     

    private void Start()
    {
        thePlayerMotor = FindObjectOfType<PlayerMotor>();
        //Set HUD to defualt values to start
        scoreText.text = "" + Mathf.Round(0);
        coinScoreText.text = "" + Mathf.Round(0);
        crystalScoreText.text = "" + Mathf.Round(0);

        // Testing
        AddCrystals(50);
    }

    private void Update()
    {
        if (scoreIncreasing && thePlayerMotor.isRunning)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;     // how much to increase by per second
        }

        scoreText.text = "" + Mathf.Round(scoreCount);           // set the scorecout on screen rount to solid number
        coinScoreText.text = "" + Mathf.Round(coinScore);           // set the scorecout on screen rount to solid number
        crystalScoreText.text = "" + Mathf.Round(totalCrystalScore);           // set the scorecout on screen rount to solid number

    }

    public void LoadPlayervalues()
    {
        if (PlayerPrefs.HasKey("HighScore"))                // if highscore exists in playprefs
        {
            // pull from player prefs
            hiScoreCount = PlayerPrefs.GetFloat("HighScore", 0); // pull from player prefs and set to 0 if not found

        }
        if (PlayerPrefs.HasKey("Crystals"))                // if highscore exists in playprefs
        {
            // pull from player prefs
            totalCrystalScore = PlayerPrefs.GetInt("Crystals", 0); // pull from player prefs and set to 0 if not found

            // AW tesmp to play with crystals in purchasing ---- remove
            //crystalCount = 10;
        }

        if (PlayerPrefs.HasKey("TotalCoinScore"))                // if highscore exists in playprefs
        {
            // pull from player prefs

            totalCoinScore = PlayerPrefs.GetInt("TotalCoinScore", 0); // pull from player prefs and set to 0 if not found


            // AW tesmp to play with coins in purchasing ---- remove
            //totalCoinScore = 4994;
        }

        if (PlayerPrefs.HasKey("TotalSpinnerCredits"))
        {

            spinnerCredits = PlayerPrefs.GetInt("TotalSpinnerCredits", 0); // pull from player prefs and set to 0 if not found

        }

        if (PlayerPrefs.HasKey("RunningTime"))      // how long the player has been running
        {

            runningTime = PlayerPrefs.GetFloat("RunningTime", 0); // pull from player prefs and set to 0 if not found

            // runningTime = 71980;
        }
        if (PlayerPrefs.HasKey("BeatHighScore"))      // how long the player has been running
        {

            beatHighScore = PlayerPrefs.GetInt("BeatHighScore", 0); // pull from player prefs and set to 0 if not found


        }
    }

    public void AddCoins(int coinsToAdd)
    {
        if (PowerUpManager.Instance.doubleCoinsActive)
        {
            coinsToAdd = coinsToAdd * 2;  // double the points
        }
        coinScore += coinsToAdd;      // Add coins 
        totalCoinScore += coinsToAdd;    // Add to total coin score to be used for achievemnt matching
        coinScoreText.text = "" + Mathf.Round(totalCoinScore);           // set the coin count on screen rount to solid number
    }


    public void AddCrystals(int crystalsToAdd)
    {
        crystalScore += crystalsToAdd;             // add crystals
        totalCrystalScore += crystalsToAdd;      // add to total crystal score to be used for achievemnt matchin
        crystalScoreText.text = "" + Mathf.Round(crystalScore);           // set the Crystal count on screen rount to solid number
        PlayerPrefs.SetInt("Crystals", totalCrystalScore);
    }

    public void SaveHighScore()
    {

        if (scoreCount > hiScoreCount)                      // if score > hghscore update highscore
        {
            Debug.Log("Save high score");

            hiScoreCount = scoreCount;                      // update highscor
            highScoreAchieved = true;
            beatHighScore += 1;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);            // AW save highscore to playerPrefs may not be the best place for it as this happens while player is runnin
            PlayerPrefs.SetInt("BeatHighScore", beatHighScore);

            SaveRunningTime(runningTime);
        }
    }

    public void SaveCrystalCount()
    {
        // TODO. update crystal count
        //GameData.Gems = crystalCount;
        PlayerPrefs.SetInt("Crystals", totalCrystalScore);
    }

    public void SaveTotalCoinCount()
    {
        // GameData.Coins = totalCoinScore;
        PlayerPrefs.SetInt("TotalCoinScore", totalCoinScore); // pull from player prefs and set to 0 if not found
    }

    public void SaveRunningTime(float runningTime)
    {


        PlayerPrefs.SetFloat("RunningTime", runningTime); // pull from player prefs and set to 0 if not found
    }

    public void UpdateCoinsTextUI()
    {
       // TotalCoinScoreText.text = GameData.Coins.ToString();
    }

    public void UpdateGemsTextUI()
    {
       // gemsText.text = GameData.Gems.ToString();

    }
}
