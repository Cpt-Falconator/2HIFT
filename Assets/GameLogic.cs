using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{

    public Image topPanel, topMiddlePanel, bottomMiddlePanel, bottomPanel;
    public float shiftTimer;
    private float timer;
    private int state;
    // Start is called before the first frame update
    void Start()
    {
        topPanel.color = Color.white;
        topMiddlePanel.color = Color.black;
        bottomMiddlePanel.color = Color.white;
        bottomPanel.color = Color.black;

        timer = 0;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(timer >= shiftTimer)
        {
            switch(state)
            {
                case 0:
                    state = 1;
                    topPanel.color = Color.white;
                    topMiddlePanel.color = Color.black;
                    bottomMiddlePanel.color = Color.white;
                    bottomPanel.color = Color.black;
                    timer = 0;
                    break;

                case 1:
                    state = 0;
                    topPanel.color = Color.black;
                    topMiddlePanel.color = Color.white;
                    bottomMiddlePanel.color = Color.black;
                    bottomPanel.color = Color.white;
                    timer = 0;
                    break;

            }
            
        }
      //  timer += 1 * Time.deltaTime;
    }
}
