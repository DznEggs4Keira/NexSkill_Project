using UnityEngine;

//Switches Levels based on Win or lose

// ORDER OF MANAGERS - LEVEL HANDLER > GAMEPLAY MANAGER > UI HANDLER > USER

public class Gameplay_Handler : MonoBehaviour {
    [SerializeField] private Level_Handler[] levels;

    #region Singleton

    public static Gameplay_Handler instance = null;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    #endregion

    //recieve value from level handler
    private CurrentLevelStatus _levelStatus = CurrentLevelStatus.None;

    public enum CurrentLevelStatus {
        None,
        Won,
        Lose
    }

    public CurrentLevelStatus levelStatus {
        get => _levelStatus;
        set { _levelStatus = value; SendStatus(); }
    }

    private void Start() {
        Debug.Log(GameConstants.currentLevelNumber);
        LoadLevel(GameConstants.currentLevelNumber);
    }

    //Send Current Level status to UI
    private void SendStatus() {
        switch (_levelStatus) {
            case CurrentLevelStatus.Won: {
                    UI_Handler.instance.CallWin();
                    break;
                }
            case CurrentLevelStatus.Lose: {
                    UI_Handler.instance.CallLose();
                    break;
                }
        }
    }

    //load level
    public void LoadLevel(int level) {

        if(level > levels.Length) {
            Debug.Log("All Levels Completed!");
            UI_Handler.instance.BackToMain();
        } else {
            for (int i = 0; i < levels.Length; i++) {
                if (i == (level - 1)) {
                    levels[i].gameObject.SetActive(true);
                } else {
                    levels[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
