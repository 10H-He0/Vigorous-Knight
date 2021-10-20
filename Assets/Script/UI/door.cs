using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public BoxCollider2D col;
    public BoxCollider2D trriger;
    public static bool isin;
    // Start is called before the first frame update
    void Start()
    {
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            closewall();
            isin = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isin = true;
            openwall();
        }
    }

    public void openwall()
    {
        col.enabled = true;
        trriger.enabled = false;
    }

    void closewall()
    {
        col.enabled = false;
        trriger.enabled = true;
    }
}


