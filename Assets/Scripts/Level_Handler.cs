using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets up the levels on level load

// ORDER OF MANAGERS - LEVEL HANDLER > GAMEPLAY MANAGER > UI HANDLER > USER

public class Level_Handler : MonoBehaviour {
    public static int coinsCollected;
    public static bool enemyHit;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerPosInit;
    [SerializeField] private int maxCoins;
    [SerializeField] private List<GameObject> coinsInMap = new List<GameObject>();
    [SerializeField] private List<GameObject> enemiesInMap = new List<GameObject>();

    //@TODO should probably make a custom event in here

    //on enable - setup level
    private void OnEnable() {
        player.SetActive(true);
        player.transform.position = playerPosInit.position;

        Time.timeScale = 1f;
    }

    //on disable - reset level
    private void OnDisable() {
        for (int i = 0; i < coinsInMap.Count; i++) {
            coinsInMap[i].SetActive(true);
        }

        //for loop to reset enemy position

        player.SetActive(false);

        coinsCollected = 0;
    }
    private void Start() {
        maxCoins = 0;
        coinsCollected = 0;

        GetCoinsInLevel();
        GetEnemiesInLevel();
    }

    // Update is called once per frame
    void Update() {
        // if enemy caught us
        if(enemyHit) {
            LevelFailed();
            enemyHit = !enemyHit;
        }

        if (coinsCollected >= maxCoins /* && enemy did not catch us*/) {
            LevelComplete();
        }
    }

    // on Win, level Complete, show win banner
    public void LevelComplete() {
        //set particle effect off

        Time.timeScale = 0f;
        Debug.Log("YOU WIN");

        //call the UI_Handler's Win Screen
        // tell Gameplay manager that the level is complete with the flag true, if won, false, if lost
        Gameplay_Handler.instance.levelStatus = Gameplay_Handler.CurrentLevelStatus.Won;

    }

    //on Lose, Level Failed, show retry banner
    public void LevelFailed() {
        //set particle effect off

        Time.timeScale = 0f;
        Debug.Log("YOU LOST");

        //call the UI_Handler's Fail Screen
        // tell Gameplay manager that the level is complete with the flag true, if won, false, if lost

        Gameplay_Handler.instance.levelStatus = Gameplay_Handler.CurrentLevelStatus.Lose;
    }

    private void GetCoinsInLevel() {
        coinsInMap.Clear();

        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).CompareTag("coin")) {
                coinsInMap.Add(transform.GetChild(i).gameObject);
                maxCoins++;
            }
        }
    }

    private void GetEnemiesInLevel() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).CompareTag("Enemies")) {
                enemiesInMap.Add(transform.GetChild(i).gameObject);
            }
        }
    }

}
