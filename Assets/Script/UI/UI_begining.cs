using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_begining : MonoBehaviour
{
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
        Stay.start = true;
        SceneManager.LoadScene("transition");
    }
}
