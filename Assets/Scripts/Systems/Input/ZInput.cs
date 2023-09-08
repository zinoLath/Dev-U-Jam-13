using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Arcade input system, made to have complete parity between real-time and replay
public class ZInput : MonoBehaviour
{
    [Flags]
    public enum Keys : byte
    {
        None = 0,
        Up  = 1 << 0,
        Down = 1 << 1,
        Left  = 1 << 2,
        Right = 1 << 4,
        Shoot = 1 << 5,
        Bomb = 1 << 6,
        Hyper = 1 << 7,
    }
    public Keys KeyState
    {
        get { return _keystate; }
    }
    public Keys PreKeyState
    {
        get { return _prekeystate; }
    }
    private Keys _keystate = 0;
    private Keys _prekeystate = 0;

    private List<Keys> _sessionstates = new List<Keys>(60*180);
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _keystate = 0;
        if (Input.GetAxisRaw("Vertical") >= 0.9)
        {
            _keystate |= Keys.Up;
        }
        if (Input.GetAxisRaw("Vertical") <= -0.9)
        {
            _keystate |= Keys.Down;
        }
        if (Input.GetAxisRaw("Horizontal") >= 0.9)
        {
            _keystate |= Keys.Right;
        }
        if (Input.GetAxisRaw("Horizontal") <= -0.9)
        {
            _keystate |= Keys.Left;
        }
        if (Input.GetButton("Shoot"))
        {
            _keystate |= Keys.Shoot;
        }
        if (Input.GetButton("Bomb"))
        {
            _keystate |= Keys.Bomb;
        }
        if (Input.GetButton("Hyper"))
        {
            _keystate |= Keys.Hyper;
        }

    }

    private void LateUpdate()
    {
        _sessionstates.Add(_keystate);
        _prekeystate = Keys.None;
    }
}
