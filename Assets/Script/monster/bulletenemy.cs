using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletenemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rd;
    public int damagenum = 4;
    // Start is called before the first frame update
    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rd.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().benn_hurt(damagenum);
            Destroy(gameObject);
        }
        if (collision.tag != "bullet" && collision.tag != "bulletenemy" && collision.tag != "room" && collision.tag != "enemy")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
