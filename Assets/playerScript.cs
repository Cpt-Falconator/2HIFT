using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerScript : MonoBehaviour
{
    public enum Lane
    {
        Bottom, BottomMiddle, TopMiddle, Top
    }
    enum Inversion
    {
        Lower, Upper
    }
    
    Inversion playerOrientation;
    public Lane playerPosition;
    public Image playerSprite;
    public GameObject topPanel, topMiddlePanel, bottomMiddlePanel, bottomPanel;
    public GameObject bulletPrefab;
    float SHOTCOOLDOWN = 3.0f;
    bool shotReady;
    // Start is called before the first frame update

    void Start()
    {
        playerPosition = Lane.TopMiddle;
        playerOrientation = Inversion.Lower;
        shotReady = true;
    }

    // Update is called once per frame
    void Update()
    {

        //if (!shotReady)
        //{
        //    SHOTCOOLDOWN -= Time.deltaTime * 1;
        //}
        //if (SHOTCOOLDOWN <= 0)
        //{
        //    shotReady = true;
        //}

        InputCheck();

        switch (playerPosition)
        {
            case Lane.Top:
                switch(playerOrientation)
                {
                    case Inversion.Upper:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, topPanel.GetComponent<LanePositions>().upperCoord, 0);
                        
                        break;

                    case Inversion.Lower:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, topPanel.GetComponent<LanePositions>().lowerCoord, 0);
                        break;
                }
                
                break;

            case Lane.TopMiddle:
                switch (playerOrientation)
                {
                    case Inversion.Upper:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, topMiddlePanel.GetComponent<LanePositions>().upperCoord, 0);

                        break;

                    case Inversion.Lower:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, topMiddlePanel.GetComponent<LanePositions>().lowerCoord, 0);
                        break;
                }

                break;

            case Lane.BottomMiddle:
                switch (playerOrientation)
                {
                    case Inversion.Upper:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, bottomMiddlePanel.GetComponent<LanePositions>().upperCoord, 0);

                        break;

                    case Inversion.Lower:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, bottomMiddlePanel.GetComponent<LanePositions>().lowerCoord, 0);
                        break;
                }

                break;

            case Lane.Bottom:
                switch (playerOrientation)
                {
                    case Inversion.Upper:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, bottomPanel.GetComponent<LanePositions>().upperCoord, 0);

                        break;

                    case Inversion.Lower:
                        playerSprite.rectTransform.localPosition = new Vector3(-470, bottomPanel.GetComponent<LanePositions>().lowerCoord, 0);
                        break;
                }

                break;
        }


    }

   public void ArmBullet()
    {
        shotReady = true;
    }

    void InputCheck()
    {
        //Left Shift moves the player up
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (playerOrientation)
            {
                case Inversion.Lower:
                    playerOrientation = Inversion.Upper;
                    break;

                case Inversion.Upper:
                    if (playerPosition != Lane.Top)
                    {
                        playerOrientation = Inversion.Lower;
                        playerPosition += 1;
                    }
                    break;
            }
        }

        //Right Shift moves the player down
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            switch (playerOrientation)
            {
                case Inversion.Lower:
                    if (playerPosition != Lane.Bottom)
                    {
                        playerOrientation = Inversion.Upper;
                        playerPosition -= 1;
                    }
                    
                    break;

                case Inversion.Upper:
                    playerOrientation = Inversion.Lower;
                    break;

             
            }
        }

        //Case for action... May end up being firing a beam of some sort to clear obstacles.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shotReady)
            {
                Instantiate(bulletPrefab, transform.parent);
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(GameObject.FindObjectOfType<GameLogic>().BulletFire, 1.0f);
                SHOTCOOLDOWN = 3;
                shotReady = false;
            }
        }
    }
}
