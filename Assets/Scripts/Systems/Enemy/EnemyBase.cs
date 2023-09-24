using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health = 2f;
    public float maxhealth = 2f;
    public Rect deleteRect;

    void Update()
    {
        if (health <= 0f)
        {
            Kill();
        }

    }

    public void Kill()
    {
        gameObject.SetActive(false);
        
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
        Destroy(other.gameObject);
    }
}