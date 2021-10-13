using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public static int health = 10;
    public float speed;
    public Transform Player;
    public Animator anim;
    public Rigidbody2D rd;
    private bool is_hurt;
    //private float hurt_time = 0.3f;
    public Vector2 direction;
    public static float distance;
    public float time_w;
    public float time_m;

    // Start is called before the first frame update
    void Start()
    {
        rd = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            Movement();

        }
    }

    void Movement()
    {
        distance = Vector2.Distance(transform.position, Player.position);
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
        else if (distance <= 4f && distance >= 2f)
        {
            direction = new Vector2(Player.position.x, Player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, direction) > 0.1f)
        {
            anim.SetBool("running", true);
        }
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
