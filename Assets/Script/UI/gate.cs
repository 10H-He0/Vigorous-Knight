using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    public float circletime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (circletime > 0)
        {
            circletime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("1-1");
        }
    }
}
