using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    private float speed = 7f;
    private void FixedUpdate()
    {
        Vector3 movement = new Vector2(0, speed * Time.deltaTime);
        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
