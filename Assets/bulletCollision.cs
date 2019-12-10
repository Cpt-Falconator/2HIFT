using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hazard")
        {
            if(other.gameObject.GetComponent<Hazard>().breakable == true)
            {
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(GameObject.FindObjectOfType<GameLogic>().WallBreak, 1.0f);
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
