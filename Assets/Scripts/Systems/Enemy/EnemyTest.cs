using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float timer = 0.2f;
    public float ang = 0;
    public Sprite sprite;
    void Update()
    {
        if(timer <= 0f)
        {
            BulletManager.Instance.SpawnBullet(sprite, transform.position, 5, new Angle(ang * 0.2f));
            timer = 0.2f;
        }
        ang += Time.deltaTime;
        timer -= Time.deltaTime;
    }
}