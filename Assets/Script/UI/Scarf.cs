using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scarf : MonoBehaviour
{
    public float num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num <= 1)
        {
            num += Time.deltaTime;
            transform.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, num);
        }
    }
}
