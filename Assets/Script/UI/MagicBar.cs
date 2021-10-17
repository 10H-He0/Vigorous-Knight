using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    public Text text;
    public static int magic;
    public static int max = 200;
    public Image magicbar;
    // Start is called before the first frame update
    void Start()
    {
        magic = max;
    }

    // Update is called once per frame
    void Update()
    {
        magicbar.fillAmount = (float)magic / (float)max;
        text.text = magic.ToString() + "/" + max.ToString();
    }
}
