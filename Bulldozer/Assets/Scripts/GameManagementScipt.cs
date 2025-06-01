using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

//SINGLETON
public class GameManagementScipt : MonoBehaviour
{

    public GameObject player;
    public Vector3 playerResetPosition = new Vector3(0, 0, 0);
    public int points = 0;
    public int life = 10;
    public int pointValue = 1;
    public int stoneValue = 5;
    public TextMeshProUGUI counterText;

    //private float nextChangeTime = 0f;

    public static GameManagementScipt instance { get; private set; }
    //public List<GameObject> fires = new List<GameObject>();

    /*private void ChanegeFire()
    {
        nextChangeTime = Time.time + 5f; // Change fire position every 2 seconds
        foreach (GameObject fire in fires)
        {
            if (fire.activeSelf)
            {
                fire.SetActive(false);
            }
            else
            {
                fire.SetActive(true);
            }
        }
    }*/

    public void Update()
    {
        /*if (Time.time >= nextChangeTime)
        {
            ChanegeFire();
        }*/
    }
 
    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void resetPlayer()
    {
        player.transform.position = playerResetPosition;
        points = 0;
        life--;
        printDatas();
        Debug.Log("Player reset.");
    }

    public void pointPickedUp()
    {
        points += pointValue;
        printDatas();
        Debug.Log(points);
    }

    public void stonePickedUp()
    {
        points += stoneValue;
        printDatas();
        Debug.Log(points);
    }

    private void printDatas()
    {
        counterText.text = "Life: " + life.ToString() + " Points: " + points.ToString();
    }
}
