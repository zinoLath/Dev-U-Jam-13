using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _menu;
    private bool opened = false;

    private MenuMap _menuMap;

    void Awake()
    {
        _menuMap = new MenuMap();
    }

    void OnEnable()
    {
        _menuMap.Enable();
        _menuMap.Menu.Open.performed += OpenMenu;
        _menuMap.Menu.Open.canceled += OpenMenu;
        _menuMap.Menu.Close.performed += CloseMenu;
        _menuMap.Menu.Close.canceled += CloseMenu;

    }

    void OnDisable()
    {
        _menuMap.Menu.Close.performed -= OpenMenu;
        _menuMap.Menu.Open.canceled -= OpenMenu;
        _menuMap.Menu.Close.performed -= CloseMenu;
        _menuMap.Menu.Close.canceled -= CloseMenu;
        _menuMap.Disable();
    }

    public void BackButton()
    {
        if(opened)
        {
            _menu.SetActive(false);
            opened = false;
        }
    }

    public void OpenMenu(InputAction.CallbackContext ctx)
    {
        if(!opened)
        {
            _menu.SetActive(true);
            opened = true;
        }
    }

    public void CloseMenu(InputAction.CallbackContext ctx)
    {
        if(opened)
        {
            _menu.SetActive(false);
            opened = false;
        }
    }

    public void ControlSound(float value)
    {
        _audio.volume = value;
    }
}
