using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    Image HealthBar;
    float maxHealth = 100f;
    public static float health;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        health = maxHealth;
    }

    void Update()
    {
        HealthBar.fillAmount = health / maxHealth;
    }
}
