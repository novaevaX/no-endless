using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed = 2.5f;
    private float direction = -1f;
    private float life = 3f;

    private float strengthAttack = 1f;
    private float addAttack = .5f;
    private int shipattack;

    private void Start()
    {
        shipattack = PlayerPrefs.GetInt("shipattack");
    }
    void FixedUpdate()
    {
        Movement();
        EnemyLife();
    }

    private void Movement()
    {
        this.transform.position += new Vector3(0, enemySpeed * direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("fire"))
        {
            life -= ( strengthAttack + addAttack * shipattack );
        }
    }

    private void EnemyLife()
    {
        if(life < 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
