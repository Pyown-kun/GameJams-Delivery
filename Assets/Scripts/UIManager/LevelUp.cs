using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private int numberScene;

    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(numberScene);
    }
}
