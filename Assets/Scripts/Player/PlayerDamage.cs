using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class PlayerDamage : MonoBehaviour
{
    [HideInInspector] public float _score;
    [HideInInspector] public float _maxTime = 60f;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] public TextMeshProUGUI _kill;
    [SerializeField] public TextMeshProUGUI _death;
    private FinalSceneScript _finalSceneScript;
    private Animator _anim;
    private float _life = 8f;

    void Start()
    {
        _score = 0f;
        _maxTime = 60f;
        _anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        _life--;
    }

    void Update()
    {
        //Debug.Log(_maxTime);

        _healthBar.fillAmount = _life/8;
        _maxTime -= Time.deltaTime;

        if(_life <= 0)
        {
            _anim.Play("Death");
            _maxTime -= 30;
            _life = 8f;
            _death.DOFade(1, 0);
            _death.DOFade(0, 2);
        }

        RaycastHit2D _hit = Physics2D.Raycast(_firePoint.position, transform.up);

        if(Input.GetMouseButtonDown(1))
        {
            AudioManager.PlaySound("Laser");
            if(_hit)
            {
                if(_hit.collider.gameObject.tag == "Enemy")
                {
                    _hit.collider.gameObject.GetComponent<EnemyDamage>()._enemyLife -= 2;
                }
                if(_hit.collider.gameObject.GetComponent<EnemyDamage>()._enemyLife <= 0)
                {
                    Destroy(_hit.collider.gameObject);
                    _score += 10;
                    _finalSceneScript._finalScore += 10;
                    _maxTime += 5;
                    _kill.DOFade(1, 0);
                    _kill.DOFade(0, 1);
                }
            }
            
        }
        

        //_scoreDisplay.text = _score.ToString();

        if(_maxTime <= 0)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}
