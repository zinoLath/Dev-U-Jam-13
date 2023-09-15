using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private float _maxTime = 120f;
    [SerializeField] private Image _healthBar;
    private float _life = 5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        _life--;
    }

    void Update()
    {
        _healthBar.fillAmount = _life/5;
        _maxTime -= Time.deltaTime;

        if(_life == 0)
        {
            _maxTime -= 30;
            _life = 5f;
        }

        Debug.Log(_maxTime);

        /*if(_maxTime <= 0)
        {

        }*/
    }
}
