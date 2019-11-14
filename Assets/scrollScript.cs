using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScript : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Awake()
    {
        speed = GetComponentInParent<GameLogic>().scrollSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        speed = GetComponentInParent<GameLogic>().scrollSpeed;
        this.transform.position = new Vector3(transform.position.x - (Time.deltaTime * speed), transform.position.y, transform.position.z);
        if (transform.localPosition.x <= -550.0f)
        {
            Destroy(gameObject);
        }
    }
}
