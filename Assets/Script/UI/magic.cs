using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    public Vector2 player_position;
    public float distance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ToPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MagicBar.magic += 10;
            MagicBar.magic = MagicBar.magic < MagicBar.max ? MagicBar.magic : MagicBar.max;
            Destroy(gameObject);
        }
    }

    void ToPlayer()
    {
        player_position = new Vector2(PlayerControl.x, PlayerControl.y);
        distance = Vector2.Distance(player_position, transform.position);
        if (distance <= 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_position, speed * Time.deltaTime);
        }
    }
}
