using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed = 2.5f;
    private float direction = -1f;
    private int life = 3;
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
            life--;
        }
    }

    private void EnemyLife()
    {
        if(life == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
