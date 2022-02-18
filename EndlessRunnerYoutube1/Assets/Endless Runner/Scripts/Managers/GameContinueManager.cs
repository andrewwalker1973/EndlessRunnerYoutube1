using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameContinueManager : MonoBehaviour
{

    [SerializeField] int safeModeTime = 5;
    private int safeModeTime_temp;
    private int continueCounter = 0;                    // How many times are we restarting
    private int CrystaltoContinue = 0;               // How many crystals to continue
    private bool continueSelected = false;          // Has the continue button been pressed
    [SerializeField] int TotalcountDownTime;                  // How long to wait for countdown to main menu
    private int countDownTime;                      // Int for contdown
    private int giftSelector;
    private float ReturnToMainScreenDuration_temp;
    [SerializeField] float ReturnToMainScreenDuration;            // How long before we return to main screen
    [SerializeField] GameObject SafeModeImage;
    [SerializeField] GameObject GameContinueScreen;                // refernec the death screen
    [SerializeField] GameObject ObstacleRemover;

    [SerializeField] TextMeshProUGUI CrystaltoContinueText;           // Crystals to spend display Text  
    [SerializeField] TextMeshProUGUI CrystalTotalText;           // Crystals to spend display Text
    [SerializeField] TextMeshProUGUI countDownDisplay;           // Count down display Text

    [SerializeField] Button CrystalContinueBuyButton;             // button to click to spend cyrsyatls to continue

    [SerializeField] Image OnContinueTimer;                   // Image to show screen timer
    [SerializeField] Image ReturnToMainScreenfillImage;           // Radial image for fill bar
    [SerializeField] Image PowerUpContinueGift;                   // Gift powerup when contiue with Vid

    [SerializeField] string MainMenu;                    // refeence for main menu

    [SerializeField] Sprite Magnetgift;
    [SerializeField] Sprite doublegift;

    [SerializeField] bool doublePoints;   // which powerup is being activated
    [SerializeField] bool shieldMode;       // which powerup is being activated
    [SerializeField] bool magnet;         // magent powerup
    [SerializeField] bool fasterMode;       // go really fast
    [SerializeField] bool safeMode;       // go really fast
    [SerializeField] float powerupLength; // How long can it be powered up for

    [SerializeField] PlayerMotor thePlayerMotor;              // reference to player object
    

    // Start is called before the first frame update
    void Start()
    {
        thePlayerMotor = FindObjectOfType<PlayerMotor>(); // Find the Camera Switcher script in the world and call it theCameraSwitcher
        ObstacleRemover.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDiedContinueOption()
    {
        PowerUpContinueGift.gameObject.SetActive(false);
        safeModeTime_temp = safeModeTime ;                                   // Safe modetime for when we go back into game
        PowerUpManager.Instance.SetMaxSafePower(safeModeTime_temp);         // Set Safe Mode time on Safe power up
        PowerUpManager.Instance.clearAllPowerUpDurations();       // Restarting from death, so clear any powerup on player

        // bring up the gamecontinue screen
        GameContinueScreen.gameObject.SetActive(true);          // bring up the contunue Menu screen
        CrystalTotalText.text = ScoreManager.Instance.totalCrystalScore.ToString();   //Display total number of crustals we have

        // check how many Crystals we need to continue
        CrystalsToContinue();
        ReturnToMainScreenDuration_temp = ReturnToMainScreenDuration;       // Reset duration back to beginning
        StartCoroutine(ReturnToMainScreenTimer(ReturnToMainScreenDuration_temp));    // Set the duration of the timer
        // determine if we have enogh crystals
        if (CrystaltoContinue > ScoreManager.Instance.totalCrystalScore)
        {
            // Disable the crystal purchase option
            CrystalContinueBuyButton.gameObject.SetActive(false);

            OnContinueTimer.gameObject.SetActive(true);             // Start the countdoewn on retunr to main menu
           // StartCoroutine(ReturnToMainScreenTimer(ReturnToMainScreenDuration));    // Set the duration of the timer
            giftSelector = 0;
            PowerUpContinueGift.gameObject.SetActive(false);

        }
        Debug.Log("Contuinue " + continueCounter);
        if (continueCounter > 2)
        {
            // Display gift powerup
            PowerUpContinueGift.gameObject.SetActive(true);
            giftSelector = Random.Range(1, 3);
            if (giftSelector == 1)
            {
                //Magent as powerup
                PowerUpContinueGift.GetComponent<Image>().sprite = Magnetgift;
            }
            if (giftSelector == 2)
            {
                //Double points as powerup
                PowerUpContinueGift.GetComponent<Image>().sprite = doublegift;
            }

        }

    }

    private void CrystalsToContinue()
    {
        // count how many times we are restarting
        // incrrease count based on count
        continueCounter++;
        if (continueCounter == 1)
        {
            // Set crystals by 2
            CrystaltoContinue = 1;
            CrystaltoContinueText.text = CrystaltoContinue.ToString();
        }

        if (continueCounter == 2)
        {
            // Set crystals by 2
            CrystaltoContinue = 2;
            CrystaltoContinueText.text = CrystaltoContinue.ToString();
        }
        if (continueCounter > 2)
        {
            // Set crystals by 4
            CrystaltoContinue = CrystaltoContinue + 2;
            CrystaltoContinueText.text = CrystaltoContinue.ToString();

        }

    }

    public IEnumerator ReturnToMainScreenTimer(float ReturnToMainScreenDuration)        // Return to main screen timer
    {
        ReturnToMainScreenfillImage.gameObject.SetActive(true);
        float startTime = Time.time;                // what si the time
        float time = ReturnToMainScreenDuration;        // how long to wait before opening main screen
        float value = 0;                                // set value to 0

        while (Time.time - startTime < ReturnToMainScreenDuration)      // while time is less than duration
        {
            time -= Time.deltaTime;                                     // decrease time
            value = time / ReturnToMainScreenDuration;
            ReturnToMainScreenfillImage.fillAmount = value;             // Update fill amount
            yield return null;                                          // break out of while loop

        }

        if (!continueSelected)              // if continue not selected
        {
            // TODO ADD THIS IN
            ScoreManager.Instance.SaveCrystalCount();
            ScoreManager.Instance.SaveTotalCoinCount();
            ScoreManager.Instance.SaveHighScore();
            ScoreManager.Instance.SaveRunningTime(ScoreManager.Instance.runningTime);

            // Check for HiScore
         //   if (theScoreManager.highScoreAchieved)
          //  {
           //     theContinueScreen.gameObject.SetActive(false);
           //     OnContinueTimer.gameObject.SetActive(false);
            //    theHiScoreMenu.gameObject.SetActive(true);
          //  }
          //  else
          //  {
                SceneManager.LoadScene(MainMenu);      // reload main menu // AW maybe a better way to di this.
          //  }
        }
    }

    public void ContinueGameCrystals()
    {
        // code to check for crystal purchase
        // Slow the speed down a bit 

        ScoreManager.Instance.totalCrystalScore = ScoreManager.Instance.totalCrystalScore - CrystaltoContinue;
        ScoreManager.Instance.SaveCrystalCount();
        ScoreManager.Instance.SaveTotalCoinCount();
        ScoreManager.Instance.SaveHighScore();                          // AW save high score but dont open screen until back at main menu
        ScoreManager.Instance.SaveRunningTime(ScoreManager.Instance.runningTime);
        giftSelector = 0;
        continueSelected = true;                                // Selected continue, so stop return to main menu
        GameContinueScreen.gameObject.SetActive(false);          // stop  the contunue Menu screen
        OnContinueTimer.gameObject.SetActive(false);            // disable the countdown timer

        StartCoroutine(CountDownToStart());         // show countd down on screen     
    }

    IEnumerator CountDownToStart()
    {
        ObstacleRemover.gameObject.SetActive(true);
        thePlayerMotor.PlayerIdle();
        countDownTime = TotalcountDownTime;         // Set the countdown timer
        countDownDisplay.gameObject.SetActive(true);    // Display the  countdown timer
       // thePlayer.SetPlayerIdle();
        while (countDownTime > 0)
        {

            countDownDisplay.text = countDownTime.ToString();       // dispaly text and convert to string
            yield return new WaitForSeconds(1f);                    // Wait for 1 sec
            countDownTime--;                                        // decrease by 1 sec
        }


        countDownDisplay.gameObject.SetActive(false);           // Disable the countdown display game object
        thePlayerMotor.StartRunning();
        SafeModeImage.SetActive(true);
        //thePlayer.IsSafe();                                     // Set safe mode for player
      //PowerUpManager.Instance.ActivatePowerUp(false, false, false, false, true, safeModeTime);       // send all details to powerup manger
        //thePlayerMotor.isRunning = true;                                        // Start runnig
                                                                                //    safeslider.maxValue = safeModeTime;
                                                                                //    safeslider.value = safeModeTime;

        thePlayerMotor.gameObject.SetActive(true);                     // enable the player/
        
        //thePlayerMotor.StartRunning();

        if (giftSelector == 1)
        {
            //Magent as powerup
            // thepowerUpManager.ActivatePowerUp(bool points, bool shield, bool mag, bool fasterM, float time);
            PowerUpManager.Instance.ActivatePowerUp(false, false, true, false, 6f);
        }
        if (giftSelector == 2)
        {
            //Double as powerup
           // PowerUpContinueGift.GetComponent<Image>().sprite = doublegift;   // Why this here TODO
            PowerUpManager.Instance.ActivatePowerUp(true, false, false, false, 6f);
        }



        StartCoroutine(StopSafeModeRoutine());                  // Stop Safe Mode after a few sec


    }

    IEnumerator StopSafeModeRoutine()
    {
        // AW would be nice to have a visual refernce for this
        // yield return new WaitForSeconds(5f);            // Wait 5 seconds
        while (safeModeTime_temp > 0)
        {

            // countDownDisplay.text = countDownTime.ToString();       // dispaly text and convert to string
            PowerUpManager.Instance.SetSafePower(safeModeTime_temp);         // Display progress bar and convert float to int
           // Debug.Log("Safe time " + safeModeTime);
            yield return new WaitForSeconds(1f);                    // Wait for 1 sec
            safeModeTime_temp--;                                        // decrease by 1 sec
        }
        ObstacleRemover.gameObject.SetActive(false);
        SafeModeImage.SetActive(false);
       // thePlayer.IsNotSafe();                          // Turn safe mode off   TODO HOW to handle this - turn off safe mode in obstabcle area ??
        continueSelected = false;                       // rest continue back to false so that next check will be false

    }

    public void ContinueGameVideo()
    {
        // code to check for crystal purchase

        // Slow the speed down a bit 
        // AW code her to play vids

        ScoreManager.Instance.SaveCrystalCount();
        ScoreManager.Instance.SaveTotalCoinCount();
        ScoreManager.Instance.SaveHighScore();                          // AW save high score but dont open screen until back at main menu
        ScoreManager.Instance.SaveRunningTime(ScoreManager.Instance.runningTime);

        continueSelected = true;                                // Selected continue, so stop return to main menu
        GameContinueScreen.gameObject.SetActive(false);          // stop  the contunue Menu screen
        OnContinueTimer.gameObject.SetActive(false);            // disable the countdown timer
     /*      if (giftSelector == 1)
           {
            //Magent as powerup
            // thepowerUpManager.ActivatePowerUp(doublePoints, shieldMode, magnet, fasterMode, slowerMode, powerupLength);
            PowerUpManager.Instance.ActivatePowerUp(false, false, true, false, 6f);
        }
           if (giftSelector == 2)
           {
               //Double as powerup
            //   PowerUpContinueGift.GetComponent<Image>().sprite = doublegift;
            PowerUpManager.Instance.ActivatePowerUp(true, false, false, false, 6f);
        }
        */
        StartCoroutine(CountDownToStart());         // show countd down on screen     
    }
}

