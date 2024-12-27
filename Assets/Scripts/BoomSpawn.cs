using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class BoomSpawn : MonoBehaviour
{
    public Image BoomCooldownFill;

    [SerializeField] private GameObject boomPrefeb;
    [SerializeField] private float boomCooldown;

    [SerializeField] private float maxFillBoomCooldown;
    [SerializeField] private float fillBoomCooldown;

    private bool inCooldown;
    private InputControlsManager inputControlsManager;

    private void Awake()
    {
        inputControlsManager = new InputControlsManager();
    }

    private void Start()
    {
        inputControlsManager.Player.Boom.started += _ => BoomPlaced();
    }

    private void OnEnable()
    {
        inputControlsManager.Enable();
    }

    private void BoomPlaced()
    {
        if (!inCooldown)
        {
            Instantiate(boomPrefeb, transform.position, Quaternion.identity);

            maxFillBoomCooldown = boomCooldown;
            fillBoomCooldown = boomCooldown;

            StartCoroutine(BoomCooldown());
        }
    }

    private IEnumerator BoomCooldown()
    {
        inCooldown = true;

        yield return new WaitForSeconds(boomCooldown);

        inCooldown = false;
    }

    private void Update()
    {
        BoomFillCooldown();
    }

    private void BoomFillCooldown()
    {
        fillBoomCooldown -= Time.deltaTime;

        BoomCooldownFill.fillAmount = fillBoomCooldown / maxFillBoomCooldown;
    }
}
