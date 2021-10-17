using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text text;
    public static int health;
    public static int max = 5;
    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health = max;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)health / (float)max;
        text.text = health.ToString() + "/" + max.ToString();
    }
}
