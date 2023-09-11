using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    public void StarButton()
    {
        Debug.Log("Iniciou");
        //SceneManager.LoadScene(_levelName);
    }

    public void OptionsButton()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        _optionsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Debug.Log("Quitei");
        //Application.Quit();
    }
}
