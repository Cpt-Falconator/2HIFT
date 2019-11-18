using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hazard")
        {
            this.gameObject.SetActive(false);
            GetComponentInParent<GameLogic>().EndGame();
        }
        if(other.tag == "Collectible")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            GetComponentInParent<GameLogic>().IncreaseSpeed();
            GetComponent<playerScript>().ArmBullet();
        }
    }
}
