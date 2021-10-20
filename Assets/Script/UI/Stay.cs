using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stay : MonoBehaviour
{
    public static int scene;
    public static bool start;
    public GameObject pistol;
    public GameObject player;
    public GameObject UI;
    public static GameObject UI_copy;

    private void Awake()
    {
        HealthBar.health = HealthBar.max;
        ShildBar.shild = ShildBar.max;
        MagicBar.magic = MagicBar.max;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("begining");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UI_copy = UI;
        if (start)
        {
            HealthBar.health = HealthBar.max;
            ShildBar.shild = ShildBar.max;
            MagicBar.magic = MagicBar.max;
            CoinUI.CurrentCoinNum = 0;
            player.transform.position = new Vector3(0, 0, 0);
            pistol = player.GetComponent<PlayerControl>().FindChild(player, "pistol");
            player.GetComponent<PlayerControl>().weapons[0] = pistol;
            player.GetComponent<PlayerControl>().weapons[0].SetActive(true);
            player.GetComponent<PlayerControl>().weapons[1] = null;

            if (SceneManager.GetActiveScene().name == "1-1")
            {
                UI.SetActive(true);
                player.SetActive(true);
                start = false;
            }
        }

        if (SceneManager.GetActiveScene().name != "transition")
        {
            scene = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            UI.SetActive(false);
        }
    }
}
