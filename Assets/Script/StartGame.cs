using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void onButtonClick()
    {
        SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
    }
}
