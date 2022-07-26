using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPREFS : MonoBehaviour
{
    //script not use
    //it's how use full save/load parametr

    private int money; // for current money
    private int shipLife; // for upgrade life
    private int speedAttack; // for upgrade speed attack
    private int superAttack; // for upgrade bonus speed attack
    private int shipSpeed; // for upgrade horizontal ship speed
    private int shipattack; // for upgrade strength ship attack

    private void Update()
    {
        PlayerPrefs.SetInt("money", money);
        money = PlayerPrefs.GetInt("money");
    }

}
