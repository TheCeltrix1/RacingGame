using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStability : MonoBehaviour
{
    public GameObject deathObject;
    private float _stability = 100;

    public Particle[] partciles;

    private void Update()
    {
        Debug.Log(_stability);
        if (_stability <= 0)
        {
            Instantiate(deathObject, this.transform.position,this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {        
        if (collision.gameObject.tag == "Particle")
        {
            _stability -= 10 * Time.deltaTime;
        }
        else if (!collision.gameObject.GetComponent<Controls>())
        {
            _stability -= 3 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        gameObject.GetComponent<Controls>().particle = partciles[Random.Range(0, 4)];

    }
}
