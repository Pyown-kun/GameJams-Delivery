using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private InputControlsManager inputControlsManager;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        inputControlsManager = new InputControlsManager();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        PlayerRotateControls();
    }

    private void RotateUp()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void RotateDown()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180f);
    }
    private void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90f);
    }
    private void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90f);
    }

    private void OnEnable()
    {
        inputControlsManager.Enable();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * moveSpeed);
    }

    private void PlayerRotateControls()
    {
        inputControlsManager.Player.Up.started += _ => RotateUp();
        inputControlsManager.Player.Down.started += _ => RotateDown();
        inputControlsManager.Player.Right.started += _ => RotateRight();
        inputControlsManager.Player.Left.started += _ => RotateLeft();
    }

}
