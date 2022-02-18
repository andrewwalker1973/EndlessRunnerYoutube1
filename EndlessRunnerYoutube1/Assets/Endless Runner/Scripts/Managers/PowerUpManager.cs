using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;         // Make this s static instance so that we can call it from anywhere

    void Awake()
    {
        Instance = this;
    }
    [SerializeField] GameObject coinDetectorObj;
    [SerializeField] GameObject PowerUpMagentImage;
    [SerializeField] GameObject PowerUpShieldImage;
    [SerializeField] GameObject DoubleCoinsImage;
    [SerializeField] Slider Magnetslider;
    [SerializeField] Slider Safeslider;
    [SerializeField] Slider Shieldslider;
    [SerializeField] Slider DoubleCoinsslider;


    private bool doubleCoins;          // which powerup is being activated
    public bool shieldMode;              // which powerup is being activated
    public bool ShieldModeActive;
    private bool magnet;                // magnet powerup
   // private bool safemode;
    private bool magnetActive;
    public bool doubleCoinsActive;
    private bool fasterMode;            // Go reallly fast
    private float powerUpLenghtTime; // How long is it active for

    private float magnetDuration;
    private float fasterDuration;
    private float doubleCoinsDuration;
    private int shieldCount;

    void Start()
    {
        // find the game object that will detect coins
        coinDetectorObj.SetActive(false);
    }

    private void Update()
    {

        #region Magnet PowerUp                              // Define the begining of the mouse input region
        if (magnetActive)
        {
            
            if (magnetDuration <= 0)
            {
                coinDetectorObj.SetActive(false);
                PowerUpMagentImage.SetActive(false);
                magnetActive = false;

            }

            if (magnetDuration >= 0)
            {
                SetMagnetPower((int)magnetDuration);         // Display progress bar and convert float to int
            }
            magnetDuration -= Time.deltaTime;
        }
        #endregion

        #region DoubleCoins PowerUp                              // Define the begining of the mouse input region
        if (doubleCoinsActive)
        {
            Debug.Log("doubleCoinsDuration " + doubleCoinsDuration);

            if (doubleCoinsDuration <= 0)
            {
                DoubleCoinsImage.SetActive(false);
                doubleCoinsActive = false;

            }

            if (doubleCoinsDuration >= 0)
            {
                SetCoinsPower((int)doubleCoinsDuration);         // Display progress bar and convert float to int
            }
            doubleCoinsDuration -= Time.deltaTime;
        }
        #endregion
    }

    public void ActivatePowerUp(bool points, bool shield, bool mag, bool fasterM, float time)     // get values from powerup scripts
    {

        doubleCoins = points;              // set value to be local value
        shieldMode = shield;                    // set value to be local value
        magnet = mag;                       // set value to be local value
      //  safemode = safem;                   // Set set mode
        fasterMode = fasterM;               // set faster mode to be local value
        powerUpLenghtTime = time;        // set value to be local value

        Debug.Log(" vars " + points + shield + mag + fasterM +   time);
        if (magnet)
        {
            // work out a mothod to get values from any upgrdes done and then add to duration here
            magnetActive = true;
            CollectMagnet(powerUpLenghtTime);
            SetMaxMagentPower((int)powerUpLenghtTime);
            PowerUpMagentImage.SetActive(true);   
        }
        if (shieldMode)
        {
            if (ShieldModeActive == false)
            {
                shieldMode = true;
                ShieldModeActive = true;
                shieldCount = (int)powerUpLenghtTime;
                Debug.Log("Start SHilked" + shieldMode + shieldCount);
                //  CollectShield(powerUpLenghtTime);

                //TODO for now accept the value from powerup script. have to get it from powerup upgrader in future
                SetMaxShieldPower((int)powerUpLenghtTime);
                PowerUpShieldImage.SetActive(true);
            }
            else
            { return; }
        }

        if (doubleCoins)
        {
            // work out a mothod to get values from any upgrdes done and then add to duration here
             doubleCoinsActive = true;
            CollectDoubleCoins(powerUpLenghtTime);
            SetMaxCoinsPower((int)powerUpLenghtTime);
            DoubleCoinsImage.SetActive(true);
            Debug.Log("Double Coins");
        }


    }

    #region Setup Magnet Power                              // Define the begining of the magnet power area
    public void CollectMagnet(float time)
    {    
        magnetDuration = time;
        StartCoroutine(ActivateCoin(magnetDuration));
    }

    public void SetMaxMagentPower(int magnetpower)
    {
        Magnetslider.maxValue = magnetpower;
        Magnetslider.value = magnetpower;
    }
    public void SetMagnetPower(int magnetpower)
    {
        Magnetslider.value = magnetpower;
    }

    IEnumerator ActivateCoin(float time)
    {
        Debug.Log("CoinDetector activated" + time);
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(time);
        coinDetectorObj.SetActive(false);
    }
    #endregion


    public void SetMaxSafePower(int safepower)
    {
        Safeslider.maxValue = safepower;
        Safeslider.value = safepower;
    }
    public void SetSafePower(int safepower)
    {

        Safeslider.value = safepower;
    }



    public void SetMaxShieldPower(int shieldPower)
    {
        Shieldslider.maxValue = shieldPower;
        Shieldslider.value = shieldPower;
    }
    public void SetShieldPower(int shieldPower)
    {
        Shieldslider.value = shieldPower;
    }


    public void CollectDoubleCoins(float time)
    {
        doubleCoinsDuration = time;
        
    }
    public void SetMaxCoinsPower(int coinPower)
    {
        DoubleCoinsslider.maxValue = coinPower;
        DoubleCoinsslider.value = coinPower;
    }
    public void SetCoinsPower(int coinPower)
    {
        DoubleCoinsslider.value = coinPower;
    }

    public void ShieldHit()
    {
        shieldCount--;
        SetShieldPower(shieldCount);
            if (shieldCount == 0)
        {
            StopShieldPowerUp();
        }
    }

    private void StopShieldPowerUp()
    {
        ShieldModeActive = false;
        Debug.Log("Stop SHilked" + shieldMode + shieldCount);
        //  CollectShield(powerUpLenghtTime);

        //TODO for now accept the value from powerup script. have to get it from powerup upgrader in future
        PowerUpShieldImage.SetActive(false);
    }
    public void clearAllPowerUpDurations()
    {
        magnetDuration = 0;
        fasterDuration = 0;
        doubleCoinsDuration = 0;
    }

}
