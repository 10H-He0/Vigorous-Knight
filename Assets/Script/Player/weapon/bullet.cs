using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rd;
    // Start is called before the first frame update
    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rd.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "bullet" && collision.tag != "room" && collision.tag != "bulletenemy" && collision.tag != "collection")
        {
            Object_Poll.Instance.pushObject(gameObject);
        }
    }
}
