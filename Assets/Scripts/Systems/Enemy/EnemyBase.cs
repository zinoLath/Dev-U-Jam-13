using System;
using UnityEngine;

public class EnemyBase : ZPhysicsEntity
{
    private float health;
    private float maxhealth;
    public Rect deleteRect;

    void Update()
    {
        if (health <= 0f)
        {
            Kill();
        }

        if (!IsInRect(deleteRect))
        {
            Destroy(this);
        }
    }

    public void Kill()
    {
        Destroy(this);
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void SetHealthTotal(float health)
    {
        this.health = health;
        this.maxhealth = health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage(other.gameObject.GetComponent<PlayerBullet>().damage);
    }
}