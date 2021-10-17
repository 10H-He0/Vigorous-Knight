using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_goblin : MonoBehaviour
{
    public Animator anim;
    public int damageNum = 4;
    public BoxCollider2D col;
    public float time_w = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goblin.health > 0)
        {
            if (goblin.distance <= 4f)
            {
                weapon_toward();
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (goblin.distance <= 2.5f)
            {
                Attack();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().benn_hurt(damageNum);
        }
    }

    void weapon_toward()
    {
        Vector3 direction = transform.position - new Vector3(PlayerControl.x, PlayerControl.y, PlayerControl.z);
        transform.up = direction;
        transform.Rotate(0, 0, -90);
    }

    void opencol()
    {
        col.enabled = true;
    }

    void closecol()
    {
        col.enabled = false;
    }

    void Attack()
    {
        if (time_w > 0)
        {
            time_w -= Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("attack");
            time_w = 3f;
        }
    }
}
