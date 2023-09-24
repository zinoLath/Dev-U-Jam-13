using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PufferFish : MonoBehaviour
{
    public float timer;
    public int times;
    public Sprite sprite;
    IEnumerator Start()
    {
        while (true)
        {
            
            for (int i = 0; i < times; i++)
            {
                BulletManager.Instance.SpawnBullet(sprite, 
                    (Vector2)transform.position,
                    2, 
                    new Angle((float)i/times));
            }
            yield return new WaitForSeconds(timer);
        }
    }
}