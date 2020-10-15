using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{

    public Image image;

    public float time = 4.4f;

    public static bool begin = false;

    public Sprite[] nums;

    private void Update()
    {

        if (time > 0 && !begin)
        {
            time -= Time.deltaTime;

            if (time > 3.4f) { }
            else if (time > 2.4f) image.sprite = nums[2];
            else if (time > 1.4f) image.sprite = nums[1];
            else if (time > 0.4f) image.sprite = nums[0];


            //text.text = time.ToString("0");
        }
        else
        {
            begin = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
