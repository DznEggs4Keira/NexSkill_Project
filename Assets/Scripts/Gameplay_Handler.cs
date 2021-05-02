using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Switches LEvels based on Win or lose
public class Gameplay_Handler : MonoBehaviour
{
    [SerializeField] private Level_Handler[] levels;

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
}
