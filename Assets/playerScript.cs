using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerScript : MonoBehaviour
{
    enum Positions
    {
        Top,
        TopMiddle,
        BottomMiddle,
        Bottom
    }
    //Position 0 = Up, 1 = Down;
    Positions playerPosition;
    public Image playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = Positions.TopMiddle;
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();

        switch (playerPosition)
        {
            case Positions.Top:
                playerSprite.rectTransform.localPosition = new Vector3(-390, 170, 0);
                break;

            case Positions.TopMiddle:
                playerSprite.rectTransform.localPosition = new Vector3(-390, 55, 0);

                break;

            case Positions.BottomMiddle:
                playerSprite.rectTransform.localPosition = new Vector3(-390, -55, 0);

                break;

            case Positions.Bottom:
                playerSprite.rectTransform.localPosition = new Vector3(-390, -170, 0);

                break;
        }


    }

    void InputCheck()
    {
        //Left Shift moves the player up the scale
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (playerPosition)
            {
                case Positions.Top:
                    //Already at top, do nothing.
                    break;

                case Positions.TopMiddle:
                    playerPosition = Positions.Top;
                    break;

                case Positions.BottomMiddle:
                    playerPosition = Positions.TopMiddle;
                    break;

                case Positions.Bottom:
                    playerPosition = Positions.BottomMiddle;
                    break;
            }
        }

        //Right Shift moves the player down the scale
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            switch (playerPosition)
            {
                case Positions.Top:
                    playerPosition = Positions.TopMiddle;
                    break;

                case Positions.TopMiddle:
                    playerPosition = Positions.BottomMiddle;
                    break;

                case Positions.BottomMiddle:
                    playerPosition = Positions.Bottom;
                    break;

                case Positions.Bottom:
                    //Already at bottom, do nothing.
                    break;
            }
        }

        //Case for jumping / action... May end up being firing a beam of some sort to clear obstacles.
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }
}
