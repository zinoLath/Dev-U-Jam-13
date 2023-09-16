using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PufferFish : MonoBehaviour
{
    public float timer;
    public int times;
    IEnumerator Start()
    {
        for (int i = 0; i < times; i++)
        {
            BulletManager.Instance.SpawnBullet((Vector2)transform.position, 2, new Angle((float)i/times));
        }
        yield return new WaitForSeconds(timer);
    }
}