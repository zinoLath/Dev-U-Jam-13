using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lazer : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] private Transform _distantPoint;
    private PlayerControl _playerControl;

    void Awake()
    {
        _playerControl = new PlayerControl();
    }


    void Update()
    {
        
        if(Input.GetMouseButton(1))
        {
            _lineRenderer.enabled = true;
            ShootLaser();
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
    void ShootLaser()
    {
        
        RaycastHit2D _hit = Physics2D.Raycast(_firePoint.position, transform.up);
        _lineRenderer.SetPosition(0, _firePoint.position);
        
        if(_hit)
        {
            _lineRenderer.SetPosition(1, _hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, _distantPoint.position);
        }
    }    
}
