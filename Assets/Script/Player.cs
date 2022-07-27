using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject attack;
    [SerializeField] private GameObject[] life;
    [SerializeField] private GameObject speedMode;

    private Vector2 start = new Vector2(0, -3f);
    private float horizontalspeed = 2.5f;
    private float direction = 0f;
    private bool leftBut = false;
    private bool rightBut = false;

    private float timer = .35f;
    private float setTimer = .35f;
    private bool isAttack = true;

    private int playerLife = 2; // after add upgrade -> full time constant
    private int currentLife; // upgrade with time (add bonus or attack enemy)
    private int shipLife;
    private bool isEnemyAttack = true;

    private bool isSpeedCrystal = false;
    private bool returnSpeed = false;
    private bool speedParametrUpdate = false;
    private float timerStartSpeedMode = 0f;
    private bool isLifeCrystal = false;

    private int moneyInRun = 0;
    private int money;
    private void Start()
    {
        shipLife = PlayerPrefs.GetInt("shipLife");
        playerLife += shipLife;
        currentLife = playerLife;
        this.transform.position = start;
        speedMode.SetActive(false);
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        DirectionPlayer();
        OpenAttack();
        TimerAttack();
        LifeUpdate();
        SpeedModeUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            isEnemyAttack = true;
            currentLife--;
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("lifeCrystal"))
        {
            isLifeCrystal = true;
        }
        if (collision.collider.CompareTag("speedCrystal"))
        {
            isSpeedCrystal = true;
        }
        if (collision.collider.CompareTag("gold"))
        {
            moneyInRun++;
        }
    }

    private void OpenAttack()
    {
        if (isAttack)
        {
            AttackShip();
            isAttack = false;
            timer = setTimer;
        }
    }
    private void AttackShip()
    {
        Instantiate(attack,new Vector3(this.transform.position.x - .57f, this.transform.position.y + .4f, 0), Quaternion.identity);
        Instantiate(attack,new Vector3(this.transform.position.x + .57f, this.transform.position.y + .4f, 0), Quaternion.identity);
    }

    private void TimerAttack()
    {
        if (!isAttack)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                isAttack = true;
            }
        }
    }


    // Work with collection items
    private void LifeUpdate()
    {
        if (isLifeCrystal)
        {
            if (currentLife < playerLife)
            {
                currentLife++;
                isEnemyAttack = true;
            }
            isLifeCrystal = false;
        }

        if (isEnemyAttack)
        {
            isEnemyAttack = false;
            for (int i = 0; i < 6; i++)
            {
                if (i >= currentLife)
                {
                    life[i].SetActive(false);
                } else
                {
                    life[i].SetActive(true);
                } 
            }

            if (currentLife == 0)
            {
                money = PlayerPrefs.GetInt("money");
                money += moneyInRun;
                PlayerPrefs.SetInt("money", money);
                Destroy(this.gameObject);
                SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
            }  
        }
    }

    private void SpeedModeUpdate()
    {
        //1
        if (isSpeedCrystal)
        {
            isSpeedCrystal = false;
            speedParametrUpdate = true;
            setTimer = .20f;
            timerStartSpeedMode = 10f;
        }

        //2
        if (timerStartSpeedMode > 0 && speedParametrUpdate)
        {
            timerStartSpeedMode = timerStartSpeedMode - Time.deltaTime;
            speedMode.SetActive(true);
        }
        else if (timerStartSpeedMode <= 0 && speedParametrUpdate)
        {
            speedMode.SetActive(false);
            speedParametrUpdate = false;
            returnSpeed = true;
        }

        //3
         if (returnSpeed && !speedParametrUpdate)
         {
             setTimer = .35f;
             returnSpeed = false;
         }
    }
    // End work with collection items


    // movement Player
    public void ButtonLeftDown()
    {
        leftBut = true;
    }

    public void ButtonLeftUp()
    {
        leftBut = false;
    }

    public void ButtonRightDown()
    {
        rightBut = true;
    }

    public void ButtonRightUp()
    {
        rightBut = false;
    }

    private void DirectionPlayer()
    {
        if (leftBut && !rightBut)
        {
            direction = -1f;
        }
        else if (rightBut && !leftBut)
        {
            direction = 1f;
        }
        else
        {
            direction = 0f;
        }
    }

    private void MovementPlayer()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * horizontalspeed * Time.deltaTime, 0, 0);
            this.transform.position += movement;
        }

        Vector3 move = new Vector3(direction * horizontalspeed * Time.deltaTime, 0, 0);
        this.transform.position += move;

        //
        if (this.transform.position.y != -3f)
        {
            this.transform.position = new Vector2(this.transform.position.x, -3f);
        }
    }
    // End movement
}
