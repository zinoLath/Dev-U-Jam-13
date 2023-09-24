using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AmmoControl : MonoBehaviour
{
    private PlayerControl _playerControl;
    [SerializeField] private float _ammo = 10f;
    [SerializeField] private Image _ammoFiller;
    [SerializeField] private Transform _shootingPosition;
    [SerializeField] private GameObject _bullet;

    void Awake()
    {
        _playerControl = new PlayerControl();
    }

    void OnEnable()
    {
        _playerControl.Player.Enable();
        _playerControl.Player.Shoot.performed += Shoot;
    }

    void OnDisable()
    {
        _playerControl.Player.Disable();
        _playerControl.Player.Shoot.performed -= Shoot;
    }

    void Update()
    {
        _ammoFiller.fillAmount = _ammo/10;
    }
    
    void Shoot(InputAction.CallbackContext ctx)
    {
        if(_ammo > 0)
        {
            AudioManager.PlaySound("Shot");
            Instantiate(_bullet, _shootingPosition.position, _shootingPosition.rotation);
            _ammo--;
        }
    }
}
