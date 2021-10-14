using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_begin : MonoBehaviour
{
    public float uptoward;
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(transform.position.x, transform.position.y + uptoward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
}
