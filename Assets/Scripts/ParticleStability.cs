using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleStability : MonoBehaviour
{
    public GameObject deathObject;
    public GameObject endScreen;
    public  float _stability = 100;

    public Particle[] partciles;

    public Image image;

    private void Update()
    {

        image.fillAmount = _stability / 100;




        if (_stability <= 0)
        {
            _stability = 0;
            Instantiate(deathObject, this.transform.position,this.transform.rotation);
            endScreen.GetComponent<Scores>().GameOver();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {        
        if (collision.gameObject.tag == "Particle")
        {
            _stability -= 30 * Time.deltaTime;
        }
        else if (!collision.gameObject.GetComponent<Controls>())
        {
            _stability -= 15 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Controls>().particle = partciles[Random.Range(0, 4)];
        GameObject.FindGameObjectWithTag("TypeCanvas").GetComponent<StartController>().Change(gameObject.GetComponent<Controls>().particle.type, gameObject.GetComponent<Controls>().player);

    }
}
