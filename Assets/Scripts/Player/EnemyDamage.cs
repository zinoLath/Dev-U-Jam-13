using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyDamage : MonoBehaviour
{
    [HideInInspector] public float _enemyLife = 5f;
    [SerializeField] private PlayerDamage _player;
    private FinalSceneScript _finalSceneScript;

   private void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.tag == "PlayerShot")
        {
            _enemyLife--;
            Destroy(other.gameObject);
            if(_enemyLife <= 0)
            {
                Destroy(gameObject.gameObject);
                _player._maxTime += 5;
                _player._score += 10;
                _finalSceneScript._finalScore += 10;
                _player._kill.DOFade(1, 0);
                _player._kill.DOFade(0, 2);
            }
        } 
   }
}
