using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_blue : MonoBehaviour
{
    public Animator anim;
    public bool isopen = false;
    public GameObject[] weapon;
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
            GameObject ins = Instantiate(weapon[Random.Range(0, weapon.Length)], transform.position, Quaternion.identity);
            ins.name = ins.name.Replace("(Clone)", "");
            ins.SetActive(true);
            isopen = true;
        }
    }
}
