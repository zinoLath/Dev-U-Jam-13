using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsControl : MonoBehaviour
{
    [SerializeField] private float speed = 15f;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
