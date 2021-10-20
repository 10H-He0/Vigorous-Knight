using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public static int health = 10;
    public int Heal = 10;
    public float speed;
    public Vector2 Player_position;
    public Animator anim;
    public Rigidbody2D rd;
    public Vector2 direction;
    public static float distance;
    public float time_w;
    public float time_m;
    public BoxCollider2D col;
    public GameObject weapon;
    public GameObject die_image;
    public GameObject coin;
    public GameObject magic;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        rd = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        col = transform.GetComponent<BoxCollider2D>();
        anim.SetBool("die", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Heal > 0)
        {
            Movement();
        }
        else
        {
            anim.SetBool("die", true);
            GameObject die_i = Instantiate(die_image, transform.position, Quaternion.identity);
            for (int i = 0; i < Random.Range(2, 4); i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Quaternion.identity);
                Instantiate(magic, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z), Quaternion.identity);
            }
            die_i.transform.localScale = transform.localScale;
            Destroy(gameObject);
            col.enabled = false;
            weapon.SetActive(false);
            rd.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Heal -= 4;
        }
    }

    void Movement()
    {
        Player_position = new Vector2(PlayerControl.x, PlayerControl.y);
        distance = Vector2.Distance(transform.position, Player_position);
        if (distance > 4f)
        {
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            if (time_m > 0)
            {
                if (Vector2.Distance(transform.position, direction) < 0.5f)
                {
                    if (time_w >= 0)
                    {
                        time_w -= Time.deltaTime;
                        anim.SetBool("running", false);

                    }
                    else
                    {
                        direction = new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10));
                        time_m = 3f;
                        time_w = 2;
                    }
                }
            }
            else
            {
                direction = new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10));
                time_m = 3f;
            }
            time_m -= Time.deltaTime;
        }
        else if (distance <= 4f && HealthBar.health > 0)
        {
            direction = Player_position;
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, direction) > 2f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            direction = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            anim.SetBool("running", false);
        }
        toward();
    }

    void toward()
    {
        if (transform.position.x < direction.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x > direction.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
