using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform spawnBullet;
    public GameObject bullet;
    public GameObject explosion;
    public int life;
    public int score;
    public int record;

    private void Awake()
    {
        record = 0;
        
        if (PlayerPrefs.HasKey("score"))
        {
            record = PlayerPrefs.GetInt("score");
        }
    }
    private void Start()
    {
        life = 5;
        score = 0;
    }
    void Update()
    {
        //quando a tecla espaço for pressionada, a bala sera instanciada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        Record();
            
    }

    void Record()   
    {
        if (score > record)
        {
            record = score;
            PlayerPrefs.SetInt("score", record);
        }
    }
    void Fire()
    {
        Instantiate(bullet, spawnBullet.position, spawnBullet.rotation );

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            
            if (life == 0)
            {
                Invoke("ReloadLevel", 2f);
                Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
                
                
               
            }
        }
        

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Fase1");
    }
}
