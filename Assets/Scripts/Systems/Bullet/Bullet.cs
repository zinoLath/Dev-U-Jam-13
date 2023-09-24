using System;
using UnityEngine;

public class Bullet : ZPhysicsEntity
{
    public int _id = 0;
    public float hitboxSizeSq;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}