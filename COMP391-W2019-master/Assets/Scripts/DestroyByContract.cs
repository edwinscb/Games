using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContract : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        if(other.tag == "Player")
        {
            // Trigger game over logic in here
            GameObject temp = Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            Destroy(temp, 2.0f);
            Destroy(other.gameObject);
        }

        // Debug.Log(other.gameObject.name);

        // Instantiate asteroid explosion animation
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        Destroy(other.gameObject);  // Laser
        Destroy(this.gameObject);   // Asteroid
    }
}
