using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ZPhysicsEntity
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputMove = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        position += inputMove * speed * Time.deltaTime;
    }

    public void GetHit()
    {
        Debug.Log("o jogador for atingido");
    }
}
