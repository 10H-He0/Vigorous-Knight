using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_begining : MonoBehaviour
{
    public GameObject gate;
    public GameObject but;
    public GameObject beg;
    public GameObject sca;
    private void Awake()
    {
        Time.timeScale = 1;
        beg.SetActive(false);
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

    public void to()
    {
        sca.SetActive(true);
        but.SetActive(false);
        beg.SetActive(true);
    }

    public void gogogo()
    {
        gameObject.SetActive(false);
        gate.SetActive(true);
    }
}
