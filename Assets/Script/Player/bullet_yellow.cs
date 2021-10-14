using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_yellow : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rd;
    public Vector3 mouseposition;
    public Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = transform.position.z;
        direction = mouseposition - transform.position;
        transform.up = direction;
        transform.Rotate(0, 0, 90);
    }

    public void SetSpeed(Vector2 direction)
    {
        rd.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "pickgun")
            Destroy(gameObject);
    }
}