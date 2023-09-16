using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControl _playerControl;
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        _playerControl = new PlayerControl();
    }
    
    void OnEnable()
    {
        _playerControl.Player.Enable();
        _playerControl.Player.Move.performed += Move;
        _playerControl.Player.Move.canceled += Move;
    }

    void OnDisable()
    {
        _playerControl.Player.Move.performed -= Move;
        _playerControl.Player.Move.canceled -= Move;
        _playerControl.Player.Disable();
    }
    
    void Move(InputAction.CallbackContext ctx)
    {
        _rb.velocity = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y) * speed;
    }
}
