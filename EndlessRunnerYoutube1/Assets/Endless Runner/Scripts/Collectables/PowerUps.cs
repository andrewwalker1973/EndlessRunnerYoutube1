using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] bool doublePoints;   // which powerup is being activated
    [SerializeField] bool shieldMode;       // which powerup is being activated
    [SerializeField] bool magnet;         // magent powerup
    [SerializeField] bool fasterMode;       // go really fast
    [SerializeField] bool safeMode;       // go really fast
    [SerializeField] float powerupLength; // How long can it be powered up for

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBubble"))
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))                                           // if player hits object
        {
            PowerUpManager.Instance.ActivatePowerUp(doublePoints, shieldMode, magnet, fasterMode, safeMode, powerupLength);       // send all details to powerup manger
        }

        gameObject.SetActive(false);                                                        // disbale the powerup onject
    }
}
