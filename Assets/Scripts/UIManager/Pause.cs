using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public bool IsPause;
    private InputControlsManager inputControlManager;

    private void Awake()
    {
        inputControlManager = new InputControlsManager();
    }

    private void OnEnable()
    {
        inputControlManager.Enable();
    }

    private void Update()
    {
        inputControlManager.UI.Pause.started += _ => PauseMenu();
    }


    private void PauseMenu()
    {
        if (IsPause)
        {
            Resume();
        }
        else
        {
            IsPause = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        IsPause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
