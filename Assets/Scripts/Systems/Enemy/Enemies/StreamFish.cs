using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StreamFish : MonoBehaviour
{
    public float timer1;
    public float timer2;
    public int times;
    public Sprite sprite;
    IEnumerator Start()
    {
        PlayerController player = GameManager.Instance.player;
        for (int i = 0; i < times; i++)
        {
            BulletManager.Instance.SpawnBullet(sprite,(Vector2)transform.position, 5, Angle.between((Vector2)transform.position,player.position));
            yield return new WaitForSeconds(timer2);
        }
        yield return new WaitForSeconds(timer1);
    }
}