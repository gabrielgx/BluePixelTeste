using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Sprite[] lifeSprites;
    public Text score;
    public Text record;
    public Image lifeUI;
    private PlayerController player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        lifeUI.sprite = lifeSprites[player.life];
        score.text = player.score.ToString();
        record.text = player.record.ToString();
    }
}
