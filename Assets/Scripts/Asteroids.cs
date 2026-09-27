using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public bool isFragment = false;
    public float fragmentScale = 0.5f;
    public float fragmentSpeed = 4f;
    public float separationAngle = 60f;

    public void Hit(Vector3 bulletDirection)
    {
        if(isFragment)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction1 = Quaternion.Euler(0, 0, separationAngle/2f) * bulletDirection.normalized;
        Vector3 direction2 = Quaternion.Euler(0, 0, -separationAngle / 2f) * bulletDirection.normalized;
        
        CreateFragment(direction1);
        CreateFragment(direction2);
        Destroy(gameObject);
    }
    private void CreateFragment(Vector3 direction)
    {
        GameObject fragment = Instantiate(gameObject, transform.position + direction * 1f, transform.rotation);
        fragment.name = "MiniMeteor";
        fragment.transform.localScale = new Vector3(transform.localScale.x * fragmentScale, transform.localScale.y * fragmentScale, transform.localScale.z * fragmentScale);
        Asteroids asteroid = fragment.GetComponent<Asteroids>();
        asteroid.isFragment = true;
        Rigidbody rigid = fragment.GetComponent<Rigidbody>();

        if (rigid != null)
        {
            rigid.linearVelocity = direction * fragmentSpeed;
        }
        Destroy(fragment, 4f);
    }
}
