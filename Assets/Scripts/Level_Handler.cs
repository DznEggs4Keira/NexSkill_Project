using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets up the levels on level load
public class Level_Handler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerPosInit;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
