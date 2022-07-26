using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLife : MonoBehaviour
{

    private float speed = 3f;
    private float direction = -1f;

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, speed * direction * Time.deltaTime, 0);
        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
