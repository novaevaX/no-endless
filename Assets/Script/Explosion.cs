using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]private float timeDestriy = .7f;
    private void FixedUpdate()
    {
        Destroy(this.gameObject, timeDestriy);
    }
}
