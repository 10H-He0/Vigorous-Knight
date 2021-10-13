using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_begining : MonoBehaviour
{
    public GameObject gate;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        gate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void gogogo()
    {
        gameObject.SetActive(false);
        gate.SetActive(true);
    }
}
