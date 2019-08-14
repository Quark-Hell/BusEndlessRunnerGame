using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void ButtonStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetDifficulty(Slider difficultySlider)
    {
        GameSettings.Difficulty = difficultySlider.value;
    }

    public void SwitchIronMode()
    {
        if(GameSettings.IronMode != true)
        {
            GameSettings.IronMode = true;
        }
        else
        {
            GameSettings.IronMode = false;
        }
        Debug.Log($"{GameSettings.IronMode}");
    }
}
