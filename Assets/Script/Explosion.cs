using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    [SerializeField]private float timeDestriy = .7f;
    [SerializeField] private bool isPlayer = false;
    private float timeDestroy = .7f;
    private void FixedUpdate()
    {
        
        if (isPlayer)
        {
            if (timeDestroy >= 0)
            {
                timeDestroy -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
            }
        } else
        {
            Destroy(this.gameObject, timeDestriy);
        }

    }
}
