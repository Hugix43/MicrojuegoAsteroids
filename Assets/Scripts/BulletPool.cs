using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 10;

    private List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
             bullet.SetActive(false);
             bullets.Add(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, Vector3 direction)
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.transform.rotation = Quaternion.identity;
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.targetVector = direction;
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
    
}
