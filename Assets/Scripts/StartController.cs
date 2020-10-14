using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{

    public Text text;

    public float time = 3.4f;

    public static bool begin = false;

    private void Update()
    {

        if (time > 0 && !begin)
        {
            time -= Time.deltaTime;
            text.text = time.ToString("0");
        }
        else
        {
            begin = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
