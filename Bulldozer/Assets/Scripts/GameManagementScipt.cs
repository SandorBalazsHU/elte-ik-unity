using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public bool pointLoss = true;
    public TextMeshProUGUI counterText;

    private int life = 10;
    private bool isGameover = false;

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

        printDatas();
    }

    public void resetPlayer()
    {
        player.transform.position = playerResetPosition;
        if (pointLoss) points = 0;
        life--;
        if (life <= 0) gameOver();
        printDatas();
        Debug.Log("Player reset.");
    }

    public void gameOver()
    {
        PlayerMovementScript playerMovementScript = player.GetComponent<PlayerMovementScript>();
        playerMovementScript.gameOver();
        isGameover = true;
        life = 0;
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
        if (isGameover) counterText.text += " - !!! GAME OVER !!!";
    }
}
