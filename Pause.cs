using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseThisGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseThisGame()
    {
        Time.timeScale = 1;
    }

}