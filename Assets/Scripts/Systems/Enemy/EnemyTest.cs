using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float timer = 0.2f;
    public float ang = 0;
    void Update()
    {
        if(timer <= 0f)
        {
            BulletManager.Instance.SpawnBullet(transform.position, 5, new Angle(ang * 0.2f));
            timer = 0.2f;
        }
        ang += Time.deltaTime;
        timer -= Time.deltaTime;
    }
}