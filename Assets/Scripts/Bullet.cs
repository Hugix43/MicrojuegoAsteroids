using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifetime = 3f;
    public Vector3 targetVector;
    void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
transform.Translate(speed * targetVector *Time.deltaTime);
    }
}
