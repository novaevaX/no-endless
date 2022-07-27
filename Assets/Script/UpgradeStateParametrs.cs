using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStateParametrs : MonoBehaviour
{
    [SerializeField] private Text textForCurrentMoney;
    [SerializeField] private Text textForNextUpgrade;


    [SerializeField] private GameObject[] lifeObj;
    private bool updateLife = false;

    [SerializeField] private GameObject[] speedAttackObj;
    private bool updateSpeedAttack = false;

    [SerializeField] private GameObject[] superSpeedObj;
    private bool updateSuperSpeed = false;

    [SerializeField] private GameObject[] shipSpeedObj;
    private bool updateShipSpeed = false;

    [SerializeField] private GameObject[] shipAttackStrengthObj;
    private bool updateShipAttackStrength = false;

    private int money; // for current money
    private int shipLife; // for upgrade life
    private int speedAttack; // for upgrade speed attack
    private int superAttack; // for upgrade bonus speed attack
    private int shipSpeed; // for upgrade horizontal ship speed
    private int shipattack; // for upgrade strength ship attack
    private int costUpgrade; //cost next upgrade

    //update start parametrs
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        costUpgrade = PlayerPrefs.GetInt("costUpgrade");

        textForCurrentMoney.text = ("Current money : " + money);
        textForNextUpgrade.text = ("Cost next upgrade : " + costUpgrade);

        shipLife = PlayerPrefs.GetInt("shipLife");
        speedAttack = PlayerPrefs.GetInt("speedAttack");
        superAttack = PlayerPrefs.GetInt("superAttack");
        shipSpeed = PlayerPrefs.GetInt("shipSpeed");
        shipattack = PlayerPrefs.GetInt("shipattack");


        for(int i = 1; i < 5; i++)
        {
            if(i <= shipLife)
            {
                lifeObj[i-1].SetActive(true);
            } else
            {
                lifeObj[i-1].SetActive(false);
            }

            if (i <= speedAttack)
            {
                speedAttackObj[i - 1].SetActive(true);
            }
            else
            {
                speedAttackObj[i - 1].SetActive(false);
            }

            if (i <= superAttack)
            {
                superSpeedObj[i - 1].SetActive(true);
            }
            else
            {
                superSpeedObj[i - 1].SetActive(false);
            }

            if (i <= shipSpeed)
            {
                shipSpeedObj[i - 1].SetActive(true);
            }
            else
            {
                shipSpeedObj[i - 1].SetActive(false);
            }

            if (i <= shipattack)
            {
                shipAttackStrengthObj[i - 1].SetActive(true);
            }
            else
            {
                shipAttackStrengthObj[i - 1].SetActive(false);
            }        
        }
    }


    // Button click
    public void UpdateLife()
    {
        updateLife = true;
    }

    public void UpdateSpeedAttack()
    {
        updateSpeedAttack = true;
    }

    public void UpdateSuperSpeed()
    {
        updateSuperSpeed = true;
    }

    public void UpdateShipSpeed()
    {
        updateShipSpeed = true;
    }

    public void UpdateShipAttackStrength()
    {
        updateShipAttackStrength = true;
    }

}
