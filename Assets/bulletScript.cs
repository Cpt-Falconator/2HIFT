using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    GameObject player;
    public GameObject blackBullet, whiteBullet;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.transform.localPosition = new Vector3(-350, player.transform.localPosition.y, 0);
        if (player.GetComponent<playerScript>().playerPosition == playerScript.Lane.Bottom || player.GetComponent<playerScript>().playerPosition == playerScript.Lane.TopMiddle)
        {
            blackBullet.SetActive(false);
            whiteBullet.SetActive(true);
        }
        else
        {
            blackBullet.SetActive(true);
            whiteBullet.SetActive(false);
        }
    }

    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = new Vector3(transform.position.x + (Time.deltaTime * speed), transform.position.y, transform.position.z);
    }
}
