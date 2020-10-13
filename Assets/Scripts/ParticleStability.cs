using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStability : MonoBehaviour
{
    public GameObject deathObject;
    public GameObject endScreen;
    private float _stability = 100;

    public Particle[] partciles;

    private void Update()
    {
        if (_stability <= 0)
        {
            Instantiate(deathObject, this.transform.position,this.transform.rotation);
            endScreen.GetComponent<Scores>().GameOver();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {        
        if (collision.gameObject.tag == "Particle")
        {
            _stability -= 100 * Time.deltaTime;
        }
        else if (!collision.gameObject.GetComponent<Controls>())
        {
            _stability -= 50 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        gameObject.GetComponent<Controls>().particle = partciles[Random.Range(0, 4)];

    }
}
