using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamestarTEXIT : MonoBehaviour
{
    public void Gamestart()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
