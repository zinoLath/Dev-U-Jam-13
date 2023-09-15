using UnityEngine;

public class EnemyBase : ZPhysicsEntity
{
    private float _health;
    private float _maxhealth;

    void Update()
    {
        if (_health <= 0f)
        {
            Kill();
        }
    }

    void Kill()
    {
        
    }
}