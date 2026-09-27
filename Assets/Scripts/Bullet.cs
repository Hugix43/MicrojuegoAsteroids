using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifetime = 2f;
    public Vector3 targetVector;
    private float lifeTimer;

    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifetime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            Asteroids asteroid = collision.gameObject.GetComponent<Asteroids>();

            if (asteroid != null)
            {
                asteroid.Hit(targetVector);
            }
        }
        gameObject.SetActive(false);
        UpdateScoreText();
    }
    private void IncreaseScore()
    {
        Player.SCORE++;
    }
    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }
    void OnEnable()
    {
        lifeTimer = 0f;
    }

}
