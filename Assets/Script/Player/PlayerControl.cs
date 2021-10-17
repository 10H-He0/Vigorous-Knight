using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rd;
    public float speed = 1;
    public Animator anim;
    public GameObject pyr, dob;
    public GameObject[] weapons;
    public int WeaponNum;
    public static float x, y, z;
    public GameObject fire;
    public float time_s = 3;
    public bool fireon, dobon = false;

    // Start is called before the first frame update
    void Start()
    {
        weapons[0].SetActive(true);
        anim.SetBool("die", false);
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
        Switchgun();
        getposition();
        skill();
    }

    void getposition()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
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

    private void OnTriggerStay2D(Collider2D collision)
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
            weapons[WeaponNum].SetActive(false);
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

    public void benn_hurt(int damageNum)
    {
        if (ShildBar.shild > 0)
        {
            if (ShildBar.shild > damageNum)
            {
                ShildBar.shild -= damageNum;
                damageNum = 0;
                return;
            }
            else
            {
                damageNum -= ShildBar.shild;
                ShildBar.shild = 0;
                HealthBar.health -= damageNum;
                if (HealthBar.health < 0) HealthBar.health = 0;
                damageNum = 0;
            }
        }
        else
        {
            HealthBar.health -= damageNum;
            if (HealthBar.health < 0) HealthBar.health = 0;
            damageNum = 0;
        }
    }

    void skill()
    {
        if (Input.GetButton("Fire2"))
        {
            fireon = true;
        }
        if (fireon) 
        {
            if (!dobon)
            {
                dob = GameObject.Instantiate(weapons[WeaponNum], weapons[WeaponNum].transform.position, Quaternion.identity);
                dob.transform.GetComponent<SpriteRenderer>().sortingLayerName = "Frontlayer";
                dob.transform.SetParent(transform);
                dob.transform.position = new Vector3(dob.transform.position.x + 0.5f, dob.transform.position.y + 0.5f, dob.transform.position.z);
                dobon = true;
            }
            fire.SetActive(true);
            if (time_s > 0)
            {
                time_s -= Time.deltaTime;
            }
            else
            {
                Destroy(dob);
                fire.SetActive(false);
                fireon = false;
                dobon = false;
                time_s = 3;
            }
        }
    }
}
