using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShildBar : MonoBehaviour
{
    public Text text;
    public static int shild;
    public static int max = 6;
    public Image shildbar;
    // Start is called before the first frame update
    void Start()
    {
        shild = max;
    }

    // Update is called once per frame
    void Update()
    {
        shildbar.fillAmount = (float)shild / (float)max;
        text.text = shild.ToString() + "/" + max.ToString();
    }
}
