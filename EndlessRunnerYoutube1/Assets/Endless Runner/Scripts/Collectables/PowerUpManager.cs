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
    public GameObject coinDetectorObj;
    public GameObject PowerUpMagentImage;
    public Slider Magnetslider;


    private bool doublePoints;          // which powerup is being activated
    private bool shieldMode;              // which powerup is being activated
    private bool magnet;                // magnet powerup
    [SerializeField] bool magnetActive;
    private bool fasterMode;            // Go reallly fast
    private float powerUpLenghtTime; // How long is it active for

    private float magnetDuration;
    private float fasterDuration;
    private float doubleDuration;

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
    }

    public void ActivatePowerUp(bool points, bool shield, bool mag, bool fasterM,  float time)     // get values from powerup scripts
    {

        doublePoints = points;              // set value to be local value
        shieldMode = shield;                    // set value to be local value
        magnet = mag;                       // set value to be local value
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
}
