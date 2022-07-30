using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject explosionBig;
    [SerializeField] private GameObject shield;
    private bool isColorChange = false;

    private int lifeShield = 3;
    private float timeDestroy = 1.3f;
    private bool isDestroy = false;

    private void FixedUpdate()
    {
        if (isColorChange)
        {
            switch (lifeShield)
            {
                case 2:
                    shield.GetComponent<Renderer>().material.color = Color.cyan;
                    break;

                case 1:
                    shield.GetComponent<Renderer>().material.color = Color.red;
                    break;

                case 0:
                    Destroy(shield);
                    Instantiate(explosionBig, transform.position, transform.rotation);
                    break;
            }
            isColorChange = false;
        }

        if (lifeShield == 0)
        {
            TimerDestroy();
        }
        if (isDestroy)
        {
            SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            isColorChange = true;
            lifeShield--;

            if(lifeShield == 0)
            {
                GameObject playerObj = GameObject.Find("Player");
                Player playerPref = playerObj.GetComponent<Player>();
                int moneyCur = playerPref.moneyInRun;

                int money = PlayerPrefs.GetInt("money");
                money += moneyCur;
                PlayerPrefs.SetInt("money", money);
            }
        }
    }

    private void TimerDestroy()
    {
        if(timeDestroy >= 0)
        {
            timeDestroy -= Time.deltaTime;
        } else
        {
            isDestroy = true;
        }
    }
}
