using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3; 
    public Image[] hearts;

    public Sprite fullHeart; 
    public Sprite emptyHeart; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = 3; 
    }

    // Update is called once per frame
    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }


    // void Update()
    // {
    //     foreach (Image img in hearts)
    //     {
    //         img.sprite = emptyHeart; 
    //     }
    //     for (int i = 0; i < health; i++)
    //     {
    //         hearts[i].sprite = fullHeart;
    //     }
    // }
}
