using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will handle when to show the Main Menu
//send a callback to the gameplay manager when to switch levels
public class UI_Handler : MonoBehaviour {
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Lose;

    #region Singleton

    public static UI_Handler instance = null;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    #endregion

    //Main Menu - Play Button
    public void Play() {
        Gameplay_Handler.instance.LoadLevel(1);
    }

    //Main Menu - Exit Button
    public void ExitApp() {
        Application.Quit();
    }

    //UI Handler Call Level
    public void OpenNextLevel() {
        Gameplay_Handler.instance.LoadLevel(Gameplay_Handler.currentLevelNumber++);
    }

    public void RetryLevel() {
        Gameplay_Handler.instance.LoadLevel(Gameplay_Handler.currentLevelNumber, true);
    }

    //UI Handler show Win screen
    public void CallWin() {
        Win.SetActive(true);
    }

    //UI Handler show Lose screen
    public void CallLose() {
        Lose.SetActive(true);
    }

}
