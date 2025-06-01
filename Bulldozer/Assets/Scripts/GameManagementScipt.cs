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
    public int defaultLife = 10;

    public int pointValue = 1;
    public int stoneValue = 5;
    public int diamondValue = 10;
    public int healValue = 5;
    public int heal = 10;
    public TextMeshProUGUI counterText;

    private int life = 10;

    public static GameManagementScipt instance { get; private set; }
 
    private void Awake()
    {
        //Application.targetFrameRate = 30;

        QualitySettings.vSyncCount = 1;

        life = defaultLife;

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

    public void diamondPickedUp()
    {
        points += diamondValue;
        printDatas();
        Debug.Log(points);
    }

    public void healPickedUp()
    {
        life += healValue;
        printDatas();
    }

    private void printDatas()
    {
        counterText.text = "Life: " + life.ToString() + " Points: " + points.ToString();
    }
}
