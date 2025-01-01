
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("BGM")]
    public AudioSource MainMenuBGM;
    public AudioSource MainMenuBGMLoop;
    public AudioSource GamePlayBGM;    
    public AudioSource GamePlayBGMLoop;    

    [Header("SFX")]
    public AudioSource Button;
    public AudioSource Door;
    public AudioSource Explosion;
    public AudioSource FootStep;
    public AudioSource Knife;
    public AudioSource Lose;
    public AudioSource Shoot;
    public AudioSource Win;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (MainMenuBGM.isPlaying)
        {
            if (MainMenuBGM.time == 0)
            {
                MainMenuBGMLoop.Play();
                Debug.Log("playLoop");
            }
        }
        
        if (GamePlayBGM.isPlaying)
        {

            if (GamePlayBGM.time == 0)
            {
                GamePlayBGMLoop.Play();
                Debug.Log("playLoop");
            }
        }
    }

    public void SoundMute()
    {

        if (MainMenuBGM.mute == true)
        {
            MainMenuBGM.mute = false;
            MainMenuBGMLoop.mute = false;
            GamePlayBGM.mute = false;
            GamePlayBGMLoop.mute = false;

            Button.mute = false;
            Door.mute = false;
            Explosion.mute = false;
            FootStep.mute = false;
            Knife.mute = false;
            Lose.mute = false;
            Shoot.mute = false;
            Win.mute = false;
        }
        else
        {
            MainMenuBGM.mute = true;
            MainMenuBGMLoop.mute = true;
            GamePlayBGM.mute = true;
            GamePlayBGMLoop.mute = true;

            Button.mute = true;
            Door.mute = true;
            Explosion.mute = true;
            FootStep.mute = true;
            Knife.mute = true;
            Lose.mute = true;
            Shoot.mute = true;
            Win.mute = true;
        }
    }
}

