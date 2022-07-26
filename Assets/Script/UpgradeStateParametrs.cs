using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStateParametrs : MonoBehaviour
{

    [SerializeField] private GameObject[] life;
    private bool updateLife = false;

    [SerializeField] private GameObject[] speedAttack;
    private bool updateSpeedAttack = false;

    [SerializeField] private GameObject[] superSpeed;
    private bool updateSuperSpeed = false;

    [SerializeField] private GameObject[] shipSpeed;
    private bool updateShipSpeed = false;

    [SerializeField] private GameObject[] shipAttackStrength;
    private bool updateShipAttackStrength = false;

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

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            life[i].SetActive(false);
            speedAttack[i].SetActive(false);
            superSpeed[i].SetActive(false);
            shipSpeed[i].SetActive(false);
            shipAttackStrength[i].SetActive(false);
        }
    }
}
