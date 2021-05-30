using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public GameObject RespawnPoint;

    public float StartingHealth = 100f;

    public float HealthPoints {
        get => _HealthPoints;
        set {
            _HealthPoints = Mathf.Clamp(value, 0f, 100f);

            if (_HealthPoints <= 0f) {
                Level_Handler.enemyHit = true;
            }
        }
    }

    [SerializeField]
    private float _HealthPoints;

    // Start is called before the first frame update
    void Start() {
        HealthPoints = StartingHealth;
    }
}
