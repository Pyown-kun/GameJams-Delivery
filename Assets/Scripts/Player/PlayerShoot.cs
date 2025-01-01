using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Pause Pause;
    public Text BulletText;

    [SerializeField] private Rigidbody2D bulletPrefeb;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float power;
    [SerializeField] private float bulletAmount;

    private InputControlsManager inputControlsManager;

    private void Awake()
    {
        inputControlsManager = new InputControlsManager();
    }

    private void Start()
    {
        inputControlsManager.Player.Shoot.started += _ => PlayerShootBullet();    
    }

    private void OnEnable()
    {
        inputControlsManager.Enable();
    }

    private void Update()
    {
        BulletText.text = "X " + bulletAmount;
    }

    private void PlayerShootBullet()
    {
        if (!Pause.IsPause)
        {
            if (bulletAmount > 0)
            {
                AudioManager.Instance.Shoot.Play();
                Rigidbody2D instance = Instantiate(bulletPrefeb, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody2D;

                instance.AddForce(bulletSpawn.up * power);

                bulletAmount -= 1;
            }
        }
    }

    public void BulletAdd(int BulletAmount)
    {
        bulletAmount += BulletAmount;
    }
}
