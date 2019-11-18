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

    [Header("Audio")]
    public AudioSource audioSource;
    public synthesiser synth;
    public AudioClip BulletFire, PickupCrystal, GameOver, WallBreak;

    [Header("Misc")]
    public GameObject crystalPickup;
    public float hazardSpawnTimer;
    public float hazardSpawnInterval;
    public float crystalSpawnTimer;
    public float crystalSpawnInterval;
    public float scrollSpeed;
    public int score;
    public float timeSurvived;

    private bool playing;


    // Start is called before the first frame update
    void Start()
    {
        topPanel.color = Color.white;
        topMiddlePanel.color = Color.black;
        bottomMiddlePanel.color = Color.white;
        bottomPanel.color = Color.black;

        hazardSpawnTimer = 0;
        crystalSpawnTimer = 0;
        playing = true;

        //Amplifies sound of gameover, was too quiet in engine
        float[] samplesGO = new float[GameOver.samples];
        GameOver.GetData(samplesGO, 0);

        for (int i = 0; i < samplesGO.Length; i++)
        {
            samplesGO[i] *= 5.0f;
        }
        GameOver.SetData(samplesGO, 0);


        //Reverses the pickup sound. (Reversing it in engine because only at end of development I thought it sounded better)
        float[] samplesCG = new float[PickupCrystal.samples];
        float[] samplesCGRev = new float[samplesCG.Length];
        PickupCrystal.GetData(samplesCG, 0);

        for (int i = 0; i < samplesCG.Length; i++)
        {
            samplesCGRev[samplesCG.Length - (i+1)] = samplesCG[i];
        }
        PickupCrystal.SetData(samplesCGRev, 0);
    }
    
    private void Awake()
    {
        timeSurvived = 0.0f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            HazardSpawner();
            CrystalSpawner();

            hazardSpawnTimer += 1 * Time.deltaTime;
            crystalSpawnTimer += 1 * Time.deltaTime;
            timeSurvived += 1 * Time.deltaTime;
        }
    }

    public void IncreaseSpeed()
    {
        hazardSpawnInterval -= 0.01f;
        scrollSpeed += 0.3f;
        score++;
        audioSource.PlayOneShot(PickupCrystal, 6.0f);
    }

    public void EndGame()
    {
        audioSource.Stop();
        audioSource.Play();
        audioSource.PlayOneShot(GameOver, 1.0f);
        playing = false;
        scrollSpeed = 0;
    }

    void HazardSpawner()
    {
        if (hazardSpawnTimer >= hazardSpawnInterval)
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
            hazardSpawnTimer = 0;
        }
    }

    void CrystalSpawner()
    {
        int spawnLane = Random.Range(0,2);
        GameObject crystal;
        if (crystalSpawnTimer >= crystalSpawnInterval)
        {
            crystal = Instantiate(crystalPickup, transform);
            switch (Random.Range(0, 4))
            {
                case 0:
                    if(spawnLane == 0)
                    {
                        crystal.transform.position = new Vector3(500.0f, topPanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        crystal.transform.position = new Vector3(500.0f, topPanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }
                    break;

                case 1:
                    if (spawnLane == 0)
                    {
                        crystal.transform.position = new Vector3(500.0f, topMiddlePanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                    }
                    else
                    {
                        crystal.transform.position = new Vector3(500.0f, topMiddlePanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                    }
                    break;

                case 2:
                    if (spawnLane == 0)
                    {
                        crystal.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().upperCoord + 5, 0.0f);
                    }
                    else
                    {
                        crystal.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().lowerCoord - 5, 0.0f);
                    }
                    break;

                case 3:
                    if (spawnLane == 0)
                    {
                        crystal.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().upperCoord + 5, 0.0f);
                    }
                    else
                    {
                        crystal.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().lowerCoord - 5, 0.0f);
                    }
                    break;

            }
            crystalSpawnTimer = 0;
        }
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
                    audioSource.PlayOneShot(synth.eNote, 0.1f);
                }
                else
                {
                    wall = Instantiate(blackWall, transform);
                    wall.transform.position = new Vector3(500.0f, -50.0f, 0.0f);
                    audioSource.PlayOneShot(synth.aNote, 0.1f);
                }
                break;

            case "WHITE":
                if (spawnLane == 0)
                {
                    wall = Instantiate(whiteWall, transform);
                    wall.transform.position = new Vector3(500.0f, 50.0f, 0.0f);
                    audioSource.PlayOneShot(synth.cNote, 0.1f);
                }
                else
                {
                    wall = Instantiate(whiteWall, transform);
                    wall.transform.position = new Vector3(500.0f, -150.0f, 0.0f);
                    audioSource.PlayOneShot(synth.fNote, 0.1f);
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
                        audioSource.PlayOneShot(synth.fNote, 0.1f);
                    }
                    else
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.position = new Vector3(500.0f, topPanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                        audioSource.PlayOneShot(synth.dNote, 0.1f);
                    }

                }
                else
                {
                    if(lanePosition == 0)
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                        audioSource.PlayOneShot(synth.bNote, 0.1f);
                    }
                    else
                    {
                        spike = Instantiate(blackSpike, transform);
                        spike.transform.position = new Vector3(500.0f, bottomMiddlePanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                        audioSource.PlayOneShot(synth.gNote, 0.1f);
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
                        audioSource.PlayOneShot(synth.dNote, 0.1f);
                    }
                    else
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.position = new Vector3(500.0f, topMiddlePanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                        audioSource.PlayOneShot(synth.bNote, 0.1f);
                    }

                }
                else
                {
                    if (lanePosition == 0)
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.Rotate(new Vector3(180, 0, 0));
                        spike.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().upperCoord - 5, 0.0f);
                        audioSource.PlayOneShot(synth.gNote, 0.1f);
                    }
                    else
                    {
                        spike = Instantiate(whiteSpike, transform);
                        spike.transform.position = new Vector3(500.0f, bottomPanel.GetComponent<LanePositions>().lowerCoord + 5, 0.0f);
                        audioSource.PlayOneShot(synth.eNote, 0.1f);
                    }
                }
                break;
        }
    }
}
