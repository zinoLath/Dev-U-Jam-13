using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -88.8)
        {
            
            transform.position = _startPosition;
        }
    }
}
