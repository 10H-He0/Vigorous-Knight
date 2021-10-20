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
    public float time_s = 3, time_k = 0.2f;
    public bool fireon, dobon = false, pick;
    public bool handknife;
    public GameObject HK;

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
        judge();
        is_die();
    }

    void is_die()
    {
        if (HealthBar.health > 0) anim.SetBool("die", false);
    }

    void getposition()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void judge()
    {
        if (handknife)
        {
            Handknife();
        }
        else
        {
            skill();
        }
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
        pick = false;
        if (collision.tag == "enemy")
        {
            weapons[WeaponNum].SetActive(false);
            handknife = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            weapons[WeaponNum].SetActive(true);
            handknife = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "pickgun" && Input.GetKey(KeyCode.Space) && !pick)
        {
            string na = collision.name;
            GameObject change = FindChild(pyr, na);
            if (weapons[1] == null)
            {
                weapons[0].SetActive(false);
                weapons[1] = change;
                weapons[1].SetActive(true);
                WeaponNum = 1;
                Destroy(collision.gameObject);
            }
            else
            {
                GameObject ins = Instantiate(weapons[WeaponNum].transform.Find(weapons[WeaponNum].name).gameObject, collision.transform.position, Quaternion.identity);
                ins.name = ins.name.Replace("(Clone)", "");
                weapons[WeaponNum].SetActive(false);           
                weapons[WeaponNum] = change;
                weapons[WeaponNum].SetActive(true);
                Destroy(collision.gameObject);
                ins.SetActive(true);
            }
            pick = true;
        }
    }

    void Movement() 
    {
        // �����Ƿ�����
        if(HealthBar.health == 0)
        {
            anim.SetBool("die", true);
            weapons[WeaponNum].SetActive(false);
        }
        else
        {
            // ���������ж�
            float horizontalmove = Input.GetAxis("Horizontal");
            float verticalmove = Input.GetAxis("Vertical");
            float H = Mathf.Abs(horizontalmove), V = Mathf.Abs(verticalmove);
            float move = H > V ? H : V;

            rd.velocity = new Vector2(horizontalmove * speed, verticalmove * speed);
            // �������߶���
            anim.SetFloat("running", Mathf.Abs(move));
            // �������ﳯ�����
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
        if (weapons[1] == null) return;
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

    void Handknife()
    {
        if (time_k > 0)
        {
            time_k -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                HK.SetActive(true);
                time_k = 0.2f;
            }
        }
    }
}
