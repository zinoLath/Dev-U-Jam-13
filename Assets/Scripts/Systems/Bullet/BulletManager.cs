using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    [SerializeField]
    private int instanceCount;

    [SerializeField]
    private Bullet bulletPrefab;

    private Bullet[] bulletArray;
    
    private int arrayCursor = 0;

    void Awake()
    {
        BulletManager.Instance = this;
        
        bulletArray = new Bullet[instanceCount];
        for (int i = 0; i < instanceCount; i++)
        {
            bulletArray[i] = Instantiate(bulletPrefab,transform);
            bulletArray[i].gameObject.SetActive(false);
            bulletArray[i]._id = i;
        }
    }

    void FixedUpdate()
    {
        Vector2 playerpos = GameManager.Instance.player.position;
        
        for (int i = 0; i < instanceCount; i++)
        {
            float x = (playerpos.x - bulletArray[i].position.x), y = (playerpos.y - bulletArray[i].position.y);
            if(x*x + y*y <= bulletArray[i].hitboxSizeSq)
            {
                GameManager.Instance.player.GetHit();
                break;
            }
        }
    }

    public Bullet SpawnBullet(Vector2 position, float speed, Angle angle)
    {
        Bullet obj = bulletArray[arrayCursor];

        obj.gameObject.SetActive(true);
        obj.SetPosition(position);
        obj.SetVelocity(speed, angle);
        obj.SetAcceleration(0);

        arrayCursor++;
        arrayCursor = arrayCursor % instanceCount;

        return obj;
    }

    public void KillBullets()
    {   
        for (int i = 0; i < instanceCount; i++)
        {
            bulletArray[i].gameObject.SetActive(false);
        }
    }
}