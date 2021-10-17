using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public int enemy_num;
    public GameObject[] enemy;
    public GameObject posi;
    // Start is called before the first frame update
    void Start()
    {
        enemy_num = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
            {
                Createnemy();
            }
        }    
    }

    void Createnemy()
    {
        if (enemy_num > 0)
        {
            for (int i = 0; i < Random.Range(4, 6); i++)
            {
                Vector2 pos = new Vector2(posi.transform.position.x + Random.Range(-7, 7), posi.transform.position.y + Random.Range(-7, 7));
                Instantiate(enemy[0], pos, Quaternion.identity);
            }
            enemy_num--;
        }
    }
}
