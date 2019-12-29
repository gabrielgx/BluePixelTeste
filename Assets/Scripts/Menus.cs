using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject menuInicial;
    public static bool gameIsPause;
    private bool jogoComecou;
    void Start()
    {
        jogoComecou=false;
        menuInicial.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogoComecou)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPause)
                {
                    Play();
                }
                else
                {
                    Pause();
                }
            }

        }

    }

   
    public void IniciarJogo()
    {
        menuInicial.SetActive(false);
        jogoComecou = true;
        Time.timeScale = 1f;

    }
    
    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;

    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1f;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
