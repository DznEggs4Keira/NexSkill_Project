using UnityEngine;
using UnityEngine.SceneManagement;

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

    #region Main Menu Routines

    //Main Menu - Play Button
    public void Play() {
        GameConstants.currentLevelNumber = 1;
        SceneManager.LoadScene(1);
    }

    //Main Menu - Exit Button
    public void ExitApp() {
        Application.Quit();
    }

    #endregion

    #region Game Menu Routines

    //Back to Main Menu
    public void BackToMain() {
        SceneManager.LoadScene(0);
    }

    //UI Handler Call Level
    public void OpenNextLevel() {
        Gameplay_Handler.instance.LoadLevel(GameConstants.currentLevelNumber++);
    }

    public void RetryLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //UI Handler show Win screen
    public void CallWin() { if (Win != null) Win.SetActive(true); }

    //UI Handler show Lose screen
    public void CallLose() { if (Lose != null) Lose.SetActive(true); }

    //open a specific level
    public void OpenLevel(int level) {
        GameConstants.currentLevelNumber = level;
        SceneManager.LoadScene(1);
    }

    #endregion

}
