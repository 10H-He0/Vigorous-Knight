using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qiandui : MonoBehaviour
{
    public int health = 30;
    public bool isdie = false;
    public GameObject coin;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isdie)
        {
            anim.SetBool("die", true);
            for (int i = 0; i < Random.Range(10, 15); i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Quaternion.identity);
            }
            isdie = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            health -= 4;
        }
    }
}
