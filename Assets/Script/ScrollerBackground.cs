using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerBackground : MonoBehaviour
{
    [SerializeField] private RawImage backgroung;
    [SerializeField] private float x, y;
    private void Update()
    {
        //backgroung.uvRect = new Rect(backgroung.uvRect.position + new Vector2(x, y) * Time.deltaTime, backgroung.uvRect.size);
        backgroung.uvRect = new Rect(backgroung.uvRect.position.x + x * Time.deltaTime, backgroung.uvRect.position.y + y * Time.deltaTime, backgroung.uvRect.width, backgroung.uvRect.height);
    }
}
