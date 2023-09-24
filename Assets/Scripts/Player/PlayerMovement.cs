using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControl _playerControl;
    private PlayerController _pc;
    [SerializeField] private float speed = 10f;

    private Vector2 velocity;

    void Start()
    {
        _pc = GetComponent<PlayerController>();
    }

    void Awake()
    {
        _playerControl = new PlayerControl();
    }

    void FixedUpdate()
    {
        _pc.position += velocity * Time.fixedDeltaTime;
        GameManager gm = GameManager.Instance;
        _pc.position = new Vector2(Mathf.Clamp(_pc.position.x,gm.playingField.xMin,gm.playingField.xMax),
                                   Mathf.Clamp(_pc.position.y,gm.playingField.yMin,gm.playingField.yMax));
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
        velocity = new Vector2(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y) * speed;
    }
}
