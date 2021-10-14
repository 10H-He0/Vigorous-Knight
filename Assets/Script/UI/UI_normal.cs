using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_normal : MonoBehaviour
{
    public GameObject pause;
    public GameObject die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        if (HealthBar.health == 0)
        {
            Time.timeScale = 0;
            die.SetActive(true);
        }
    }

    public void pause_UI()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
}
