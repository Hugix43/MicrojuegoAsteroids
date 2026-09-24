using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float xBorderLimit = 9f;
    public float yBorderLimit = 5f;
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;
    public static int SCORE  = 0;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit + 1;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit - 1;
        }
        if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit + 1;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit - 1;
        }
        transform.position = newPos;

        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    else
        {
            Debug.Log(message:"He colisionado con otra cosa");
        }
    }
}
