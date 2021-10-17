using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Ice : MonoBehaviour
{
    public float interval;
    public GameObject bulletprefab;
    public Transform muzzlepos;
    public Vector3 mouseposition;
    public Vector3 direction;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        muzzlepos = transform.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = transform.position.z;
        shoot();
    }

    void shoot()
    {
        direction = mouseposition - transform.position;
        transform.up = direction;
        transform.Rotate(0, 0, 90);

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (timer == 0)
            {
                Fire();
                timer = interval;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletprefab, muzzlepos.position, Quaternion.identity);
        float angle = Random.Range(-5f, 5f);
        bullet.GetComponent<Bullet_Ice>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * direction);
    }
}
