using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SINGLETON
public class gameManagementScipt : MonoBehaviour
{

    public GameObject playerPrefab;
    public CameraFollowScript cameraFollow;
    private float playerSpawnTime = -1;
    public float spawnTime = 2;
    public int coins = 0;

    public static gameManagementScipt instance {  get; private set; }

    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void spawnPlayer()
    {
        playerSpawnTime = Time.time + spawnTime;
    }

    public void coinPickedUp()
    {
        coins++;
        Debug.Log(coins);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpawnTime >= 0 && playerSpawnTime <= Time.time)
        {
            GameObject newPlayer = Instantiate(playerPrefab);
            cameraFollow.target = newPlayer.transform;
            playerSpawnTime = -1;
        }
    }
}
