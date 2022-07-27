using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    private int lifeShield = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            lifeShield--;

            if(lifeShield == 0)
            {
                GameObject playerObj = GameObject.Find("Player");
                Player playerPref = playerObj.GetComponent<Player>();
                int moneyCur = playerPref.moneyInRun;

                int money = PlayerPrefs.GetInt("money");
                money += moneyCur;
                PlayerPrefs.SetInt("money", money);

                SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
            }
        }
    }
}
