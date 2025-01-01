using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        AudioManager.Instance.MainMenuBGM.Stop();
        AudioManager.Instance.MainMenuBGMLoop.Stop();
        AudioManager.Instance.GamePlayBGM.Play();
        AudioManager.Instance.Button.Play();
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        AudioManager.Instance.GamePlayBGM.Play();
        AudioManager.Instance.Button.Play();
        AudioManager.Instance.Lose.Stop();
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);
        AudioManager.Instance.Button.Play();
        AudioManager.Instance.MainMenuBGM.Play();
        AudioManager.Instance.Lose.Stop();
        AudioManager.Instance.Win.Stop();
        AudioManager.Instance.GamePlayBGMLoop.Stop();
        AudioManager.Instance.GamePlayBGM.Stop();

    }

    public void Exit()
    {
        Application.Quit();
    }
}
