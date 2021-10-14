using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void back()
    {
        SceneManager.LoadScene("begining");
    }

    public void Continue()
    {
        transform.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
