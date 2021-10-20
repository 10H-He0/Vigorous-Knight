using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_white : MonoBehaviour
{
    public Animator anim;
    public GameObject coin;
    public GameObject magic;
    public bool isopen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        anim.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("open", true);
        if (!isopen && collision.tag == "Player")
        {
            for (int i = 0; i < Random.Range(2, 4); i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Quaternion.identity);
                Instantiate(magic, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Quaternion.identity);
            }
            isopen = true;
        }
    }
}
