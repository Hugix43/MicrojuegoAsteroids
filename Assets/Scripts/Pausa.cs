using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool Pausado = false;

    void Start()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausado)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }   
    }
    public void ResumeGame()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
    }
    public void PauseGame()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Player.SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
