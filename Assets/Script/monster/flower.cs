using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    public int health = 10;
    public Animator anim;
    public Vector2 Player_position;
    public float distance;
    public Vector2 direction;
    public float time_w = 3;
    public Transform muzzlepos;
    public GameObject bulletenemyprefab;
    public GameObject die_image;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        muzzlepos = transform.Find("Muzzle");
        anim = transform.GetComponent<Animator>();
        anim.SetBool("die", false);
    }

    // Update is called once per frame
    void Update()
    {
        Player_position = new Vector2(PlayerControl.x, PlayerControl.y);
        distance = Vector2.Distance(transform.position, Player_position);
        if (health > 0)
        {
            attack();
        }
        else
        {
            anim.SetBool("die", true);
            GameObject die_i = Instantiate(die_image, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            health -= 4;
        }
    }

    void attack()
    {
        if (distance < 20f)
        {
            if (time_w > 0)
            {
                time_w -= Time.deltaTime;
            }
            else
            {
                anim.SetTrigger("attack");
                direction = Player_position - new Vector2(muzzlepos.position.x, muzzlepos.position.y);
                GameObject bulletenemy = Instantiate(bulletenemyprefab, muzzlepos.position, Quaternion.identity);
                bulletenemy.GetComponent<bulletenemy>().SetSpeed(direction);
                time_w = 3;
            }
        }
    }
}
