using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainParametrs : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    void Start()
    {
        audio.Play();
    }



}
