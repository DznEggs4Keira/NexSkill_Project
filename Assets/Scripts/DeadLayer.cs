using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Level_Handler.enemyHit = true;
        }
    }
}
