using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rd;
    public float speed = 1;
    public Animator anim;
    public GameObject pyr;
    public GameObject[] weapons;
    public int WeaponNum;

    // Start is called before the first frame update
    void Start()
    {
        weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Switchgun();
    }

    public GameObject FindChild(GameObject parent, string na)
    {
        GameObject obj = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.name == na)
            {
                obj = parent.transform.GetChild(i).gameObject;
                break;
            }
        }
        return obj;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pickgun" && Input.GetKey(KeyCode.Space))
        {
            string na = collision.name;
            GameObject change = FindChild(pyr, na);
            weapons[WeaponNum].SetActive(false);
            weapons[WeaponNum] = change;
            weapons[WeaponNum].SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void Movement() 
    {
        // 人物是否死亡
        if(HealthBar.health == 0)
        {
            anim.SetBool("die", true);
        }
        else
        {
            // 控制人物行动
            float horizontalmove = Input.GetAxis("Horizontal");
            float verticalmove = Input.GetAxis("Vertical");
            float H = Mathf.Abs(horizontalmove), V = Mathf.Abs(verticalmove);
            float move = H > V ? H : V;

            rd.velocity = new Vector2(horizontalmove * speed, verticalmove * speed);
            // 播放行走动画
            anim.SetFloat("running", Mathf.Abs(move));
            // 控制人物朝向鼠标
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = mouseposition - transform.position;
            if (dir.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (dir.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void Switchgun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapons[WeaponNum].SetActive(false);
            if (--WeaponNum < 0)
            {
                WeaponNum = weapons.Length - 1;
            }
            weapons[WeaponNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapons[WeaponNum].SetActive(false);
            if (++WeaponNum > weapons.Length - 1)
            {
                WeaponNum = 0;
            }
            weapons[WeaponNum].SetActive(true);
        }
    }
}
