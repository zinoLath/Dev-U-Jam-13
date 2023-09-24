using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _player;
    private bool opened = false;
    private bool _playerActive = true;

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
       // -189.1 -122.1 189.13 118.6
        Time.timeScale = 1;
        if(!_playerActive)
        {
            _player.SetActive(true);
            _playerActive = true;
        }
    }

    public void OpenMenu(InputAction.CallbackContext ctx)
    {
        if(!opened)
        {
            _menu.SetActive(true);
            opened = true;
        }
        Time.timeScale = 0;

        _player.SetActive(false);
        _playerActive = false;
    }

    

    public void CloseMenu(InputAction.CallbackContext ctx)
    {
        if(opened)
        {
            _menu.SetActive(false);
            opened = false;
        }
        Time.timeScale = 1;
        if(!_playerActive)
        {
            _player.SetActive(true);
            _playerActive = true;
        }
    }

    public void ControlSound(float value)
    {
        _audio.volume = value;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
