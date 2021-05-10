using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Switches LEvels based on Win or lose
public class Gameplay_Handler : MonoBehaviour
{
    [SerializeField] private Level_Handler[] levels;

    //recieve value from level handler
    private bool isCurrentLevelWon;

    public bool CurrentLevelStatus
    {
        get => isCurrentLevelWon;
        set => isCurrentLevelWon = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load level
    public void LoadLevel(int level)
    {
        levels[level - 1].gameObject.SetActive(true);
    }

    //Reset level
    public void ResetLevel(int level)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        levels[level - 1].gameObject.SetActive(true);

    }
}
