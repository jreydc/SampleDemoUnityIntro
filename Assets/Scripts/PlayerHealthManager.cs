using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : Singleton<PlayerHealthManager>
{
    [SerializeField]
    private Stats playerHealthStats;

    [SerializeField]
    private Image playerHealthFillingUp;

    private void Start()
    {
        playerHealthFillingUp.fillAmount = playerHealthStats.maxValue;
    }

    public void PlayerDamage()
    {
        playerHealthFillingUp.fillAmount -= playerHealthStats.deductionValue;
    }

    public void PlayerPowerUp()
    {
        Debug.Log("PowerUp Method");
        //code for PowerUp
    }

    public void PlayerEnery()
    {
        Debug.Log("PowerEnergy Method");
        //code for PlayerEnergy / Stamina...
    }
}
