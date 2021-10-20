using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_jingying : MonoBehaviour
{
    public int enemy_num;
    public GameObject[] enemy;
    public GameObject posi;
    public GameObject Box1;
    public GameObject Box2;
    public bool is_box;
    // Start is called before the first frame update
    void Start()
    {
        enemy_num = Random.Range(1, 4);
        is_box = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_num == 0 && !is_box && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            Vector2 pos = new Vector2(posi.transform.position.x + Random.Range(-6.5f, 6.5f), posi.transform.position.y + Random.Range(-6.5f, 6.5f));
            Instantiate(Box1, pos, Quaternion.identity);
            Vector2 pos2 = new Vector2(posi.transform.position.x + Random.Range(-6.5f, 6.5f), posi.transform.position.y + Random.Range(-6.5f, 6.5f));
            Instantiate(Box2, pos2, Quaternion.identity);
            is_box = true;
        }
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
                Vector2 pos = new Vector2(posi.transform.position.x + Random.Range(-6f, 6f), posi.transform.position.y + Random.Range(-6f, 6f));
                Instantiate(enemy[Random.Range(0, enemy.Length)], pos, Quaternion.identity);
            }
            enemy_num--;
        }
    }
}
