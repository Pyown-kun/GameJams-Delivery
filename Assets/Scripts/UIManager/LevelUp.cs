using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private int numberScene;

    public void ChangeScene()
    {
        if(numberScene != 2)
        {
            AudioManager.Instance.Door.Play();
        }
        else
        {
            AudioManager.Instance.Win.Play();
            AudioManager.Instance.GamePlayBGM.Stop();
            AudioManager.Instance.GamePlayBGMLoop.Stop();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(numberScene);
        AudioManager.Instance.Button.Play();
    }
}
