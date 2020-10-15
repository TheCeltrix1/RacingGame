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

    public GameObject[] types;

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


    public void Change(int num, int player)
    {

        if(player == 1)
        {

            types[0].transform.GetChild(0).gameObject.SetActive(false);
            types[0].transform.GetChild(1).gameObject.SetActive(false);
            types[0].transform.GetChild(2).gameObject.SetActive(false);
            types[0].transform.GetChild(3).gameObject.SetActive(false);

            switch (num)
            {
                case 0:
                    types[0].transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 1:
                    types[0].transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 2:
                    types[0].transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 3:
                    types[0].transform.GetChild(3).gameObject.SetActive(true);
                    break;
            }
        }
        else if(player == 2)
        {
            types[1].transform.GetChild(0).gameObject.SetActive(false);
            types[1].transform.GetChild(1).gameObject.SetActive(false);
            types[1].transform.GetChild(2).gameObject.SetActive(false);
            types[1].transform.GetChild(3).gameObject.SetActive(false);


            switch (num)
            {
                case 0:
                    types[1].transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 1:
                    types[1].transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 2:
                    types[1].transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 3:
                    types[1].transform.GetChild(3).gameObject.SetActive(true);
                    break;
            }
        }

    
    }

}
