using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets up the levels on level load
public class Level_Handler : MonoBehaviour
{
    public static int coinsCollected;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerPosInit;
    [SerializeField] private int maxCoins;

    //on enable - setup level
    private void OnEnable()
    {
        player.SetActive(true);
        player.transform.position = playerPosInit.position;
    }

    //on disable - reset level
    private void OnDisable()
    {
        
    }
    private void Start()
    {
        maxCoins = 0;
        coinsCollected = 0;

        GetCoinsInLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(coinsCollected >= maxCoins)
        {
            LevelComplete();
        }
    }

    // on Win, level Complete, show win banner
    public void LevelComplete()
    {
        //set particle effect off

        Time.timeScale = 0f;

        Debug.Log("YOU WIN");
            
    }

    private void GetCoinsInLevel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("coin"))
            {
                maxCoins++;
            }
        }
    }

}
