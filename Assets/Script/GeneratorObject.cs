using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObject : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;

    [SerializeField] private GameObject life;
    [SerializeField] private GameObject speed;
    [SerializeField] private GameObject gold;

    private Vector2 min;
    private Vector2 max;

    private bool isCreate = false;
    private int quantityEnemy = 1;
    private float timeUp = 40f;

    private float maxTimeCreateBonus = 40f;
    private float minTimeCreateBonus = 20f;
    private float timeBonusLife;
    private float timeBonusSpeed;
    private float timeBonusGold;
    private bool createLife = true;
    private bool createSpeed = true;
    private bool createGold = true;

    private void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
    }

    private void FixedUpdate()
    {
        CreateEnemy();
        CreateLife();
        CreateSpeed();
        CreateGoldMoney();
        TimeUp();
    }

    private void TimeUp()
    {
        timeUp -= Time.deltaTime;

        if(timeUp <= 0)
        {
            quantityEnemy++;
            timeUp = 40f;
        }
    }

    private void CreateEnemy()
    {
        //1
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length < quantityEnemy)
        {
            isCreate = true;
        }

        //2
        if (isCreate)
        {
            Instantiate(enemy1, new Vector3(Random.Range(min.x, max.x), max.y, 0), Quaternion.identity);
            isCreate = false;
        }
    }

    private void CreateLife()
    {
        //1
        GameObject[] lifeObject = GameObject.FindGameObjectsWithTag("lifeCrystal");
        if(lifeObject.Length < 1 && createLife)
        {
            timeBonusLife = Random.Range(minTimeCreateBonus, maxTimeCreateBonus);
            createLife = false;
        }

        //2
        if (!createLife)
        {
            timeBonusLife -= Time.deltaTime;
        }

        //3
        if(timeBonusLife <= 0 && !createLife)
        {
            createLife = true;
            Instantiate(life, new Vector3(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y, 0), Quaternion.identity);
        }
    }
    private void CreateSpeed()
    {
        //1
        GameObject[] speedObject = GameObject.FindGameObjectsWithTag("speedCrystal");
        if (speedObject.Length < 1 && createSpeed)
        {
            timeBonusSpeed = Random.Range(minTimeCreateBonus, maxTimeCreateBonus);
            createSpeed = false;
        }

        //2
        if (!createSpeed)
        {
            timeBonusSpeed -= Time.deltaTime;
        }

        //3
        if (timeBonusSpeed <= 0 && !createSpeed)
        {
            createSpeed = true;
            Instantiate(speed, new Vector3(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y, 0), Quaternion.identity);
        }
    }

    private void CreateGoldMoney()
    {
        //1
        GameObject[] goldObject = GameObject.FindGameObjectsWithTag("gold");
        if (goldObject.Length < 1 && createGold)
        {
            timeBonusGold = Random.Range(minTimeCreateBonus, maxTimeCreateBonus);
            createGold = false;
        }

        //2
        if (!createGold)
        {
            timeBonusGold -= Time.deltaTime;
        }

        //3
        if (timeBonusGold <= 0 && !createGold)
        {
            createGold = true;
            Instantiate(gold, new Vector3(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y, 0), Quaternion.identity);
        }
    }
}
