using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{
    [Header("Background Panels")]
    public Image topPanel;
    public Image topMiddlePanel;
    public Image bottomMiddlePanel;
    public Image bottomPanel;

    [Header("Hazards")]
    public GameObject blackWall;
    public GameObject whiteWall;
    public GameObject blackSpike;
    public GameObject whiteSpike;

    [Header("Misc")]
    public float spawnTimer;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        topPanel.color = Color.white;
        topMiddlePanel.color = Color.black;
        bottomMiddlePanel.color = Color.white;
        bottomPanel.color = Color.black;

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(timer >= spawnTimer)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    CreateWall("BLACK");
                    break;

                case 1:
                    CreateWall("WHITE");
                    break;

                case 2:
                    CreateSpike("BLACK");
                    break;

                case 3:
                    CreateSpike("WHITE");
                    break;

            }
            timer = 0;
        }
        timer += 1 * Time.deltaTime;
    }

    void CreateWall(string COLOUR)
    {
        int spawnLane = Random.Range(0, 2);
        GameObject wall;
        switch (COLOUR)
        {
            case "BLACK":
                if (spawnLane == 0)
                {
                    wall = Instantiate(blackWall, transform);
                    wall.transform.position = new Vector3(500.0f, 150.0f, 0.0f);
                }
                else
                {
                    wall = Instantiate(blackWall, transform);
                    wall.transform.position = new Vector3(500.0f, -50.0f, 0.0f);
                }
                break;

            case "WHITE":
                if (spawnLane == 0)
                {
                    wall = Instantiate(whiteWall, transform);
                    wall.transform.position = new Vector3(500.0f, 50.0f, 0.0f);
                }
                else
                {
                    wall = Instantiate(whiteWall, transform);
                    wall.transform.position = new Vector3(500.0f, -150.0f, 0.0f);
                }
                break;
        }
        
    }

    void CreateSpike(string COLOUR)
    {
        int spawnLane = Random.Range(0, 2);
        int lanePosition = Random.Range(0, 2);
        GameObject spike;
        switch (COLOUR)
        {

            case "BLACK":
                if (spawnLane == 0)
                {
                    if(lanePosition == 0)
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, topPanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.position = new Vector3(500.0f, topPanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }

                }
                else
                {
                    if(lanePosition == 0)
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }
                }
                break;

            case "WHITE":
                if (spawnLane == 0)
                {
                    if (lanePosition == 0)
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, topMiddlePanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.position = new Vector3(500.0f, topMiddlePanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }

                }
                else
                {
                    if (lanePosition == 0)
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }
                }
                break;
        }
    }
}
