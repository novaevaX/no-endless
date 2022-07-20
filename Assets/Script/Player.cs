using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject attack;

    private Vector2 start = new Vector2(0, -3f);
    private float horizontalspeed = 2.5f;

    private float timer = .35f;
    private bool isAttack = true;
    private void Start()
    {
        this.transform.position = start;
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        OpenAttack();
        TimerAttack(); 
    }
    private void MovementPlayer()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * horizontalspeed * Time.deltaTime, 0, 0);
            this.transform.position += movement; 
        }

        if (this.transform.position.y != -3f)
        {
            this.transform.position = start;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OpenAttack()
    {
        if (Input.GetButton("Jump") && isAttack)
        {
            AttackShip();
            isAttack = false;
            timer = .35f;
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



}
