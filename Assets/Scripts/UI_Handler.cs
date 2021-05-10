using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will handle when to show the Main Menu
//send a callback to the gameplay manager when to switch levels
public class UI_Handler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Gameplay_Handler gm_manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Main Menu - Play Button
    public void Play()
    {

    }

    //Main Menu - Exit Button
    public void ExitApp()
    {

    }

    //UI Handler Call Level
}
