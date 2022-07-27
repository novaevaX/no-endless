using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStateParametrs : MonoBehaviour
{
    [SerializeField] private Text textForCurrentMoney;
    [SerializeField] private Text textForNextUpgrade;


    [SerializeField] private GameObject[] lifeObj;
    [SerializeField] private GameObject lifeBut;
    private bool updateLife = false;

    [SerializeField] private GameObject[] speedAttackObj;
    [SerializeField] private GameObject speedAttackBut;
    private bool updateSpeedAttack = false;

    [SerializeField] private GameObject[] superSpeedObj;
    [SerializeField] private GameObject superSpeedBut;
    private bool updateSuperSpeed = false;

    [SerializeField] private GameObject[] shipSpeedObj;
    [SerializeField] private GameObject shipSpeedBut;
    private bool updateShipSpeed = false;

    [SerializeField] private GameObject[] shipAttackStrengthObj;
    [SerializeField] private GameObject shipAttackStrengthBut;
    private bool updateShipAttackStrength = false;

    private int money; // for current money
    private int costUpgrade; //cost next upgrade
    private bool costCheck = false;
    private bool isUpgrade = true;

    private int shipLife; // for upgrade life
    private int speedAttack; // for upgrade speed attack
    private int superAttack; // for upgrade bonus speed attack
    private int shipSpeed; // for upgrade horizontal ship speed
    private int shipattack; // for upgrade strength ship attack

    //load start parametrs
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
    }

    //after right click - upgrade state parametr
    private void FixedUpdate()
    {
        UpgradePlayerParametr();
        if (isUpgrade)
        {
            SaveParametr();
            UpdateUIParametr();
            isUpgrade = false;
        } 
    }

    //check - true -> upgrade parametr
    private void UpgradePlayerParametr()
    {
        if (costCheck)
        {
            if (updateLife)
            {
                shipLife++;
                updateLife = false;
            }
            if (updateSpeedAttack)
            {
                speedAttack++;
                updateSpeedAttack = false;
            }
            if (updateSuperSpeed)
            {
                superAttack++;
                updateSuperSpeed = false;
            }
            if (updateShipSpeed)
            {
                shipSpeed++;
                updateShipSpeed = false;
            }
            if (updateShipAttackStrength)
            {
                shipattack++;
                updateShipAttackStrength = false;
            }
            costCheck = false;
            isUpgrade = true;
            UpdateCurrentMoney();
            UpdateNextCost();
            
        }
    }

    //update next cost
    private void UpdateNextCost()
    {
        costUpgrade = costUpgrade * 2 + 1;
    }
    private void UpdateCurrentMoney()
    {
        money -= costUpgrade;
    }

    private void SaveParametr()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("costUpgrade", costUpgrade);

        textForCurrentMoney.text = ("Current money : " + money);
        textForNextUpgrade.text = ("Cost next upgrade : " + costUpgrade);

        PlayerPrefs.SetInt("shipLife", shipLife);
        PlayerPrefs.SetInt("speedAttack", speedAttack);
        PlayerPrefs.SetInt("superAttack", superAttack);
        PlayerPrefs.SetInt("shipSpeed", shipSpeed);
        PlayerPrefs.SetInt("shipattack", shipattack);
    }

    private void UpdateUIParametr()
    {
        for (int i = 1; i < 5; i++)
        {
            //life
            if (i <= shipLife)
            {
                lifeObj[i - 1].SetActive(true);
            }
            else
            {
                lifeObj[i - 1].SetActive(false);
            }
            if(shipLife == 5)
            {
                lifeBut.SetActive(false);
            }

            //speed attack
            if (i <= speedAttack)
            {
                speedAttackObj[i - 1].SetActive(true);
            }
            else
            {
                speedAttackObj[i - 1].SetActive(false);
            }
            if (speedAttack == 5)
            {
                speedAttackBut.SetActive(false);
            }

            //bonus speed
            if (i <= superAttack)
            {
                superSpeedObj[i - 1].SetActive(true);
            }
            else
            {
                superSpeedObj[i - 1].SetActive(false);
            }
            if (superAttack == 5)
            {
                superSpeedBut.SetActive(false);
            }

            //horizontal speed
            if (i <= shipSpeed)
            {
                shipSpeedObj[i - 1].SetActive(true);
            }
            else
            {
                shipSpeedObj[i - 1].SetActive(false);
            }
            if (shipSpeed == 5)
            {
                shipSpeedBut.SetActive(false);
            }

            //attack strength
            if (i <= shipattack)
            {
                shipAttackStrengthObj[i - 1].SetActive(true);
            }
            else
            {
                shipAttackStrengthObj[i - 1].SetActive(false);
            }
            if (shipattack == 5)
            {
                shipAttackStrengthBut.SetActive(false);
            }
        }
    }

    // Button click
    public void UpdateLife()
    {
        CostCheck();
        updateLife = true;
    }

    public void UpdateSpeedAttack()
    {
        CostCheck();
        updateSpeedAttack = true;
    }

    public void UpdateSuperSpeed()
    {
        CostCheck();
        updateSuperSpeed = true;
    }

    public void UpdateShipSpeed()
    {
        CostCheck();
        updateShipSpeed = true;
    }

    public void UpdateShipAttackStrength()
    {
        CostCheck();
        updateShipAttackStrength = true;
    }

    //if money > cost
    private void CostCheck()
    {
        if(money - costUpgrade >= 0)
        {
            costCheck = true;
        }
    }
}
