using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        Object_Poll.instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(Stay.scene + 1);
            Stay.UI_copy.SetActive(true);
        }
    }
}
