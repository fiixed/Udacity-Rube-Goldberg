using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTarget : MonoBehaviour {

    private SteamVR_LoadLevel levelLoader;

    private void Start() {
        levelLoader = GameObject.FindObjectOfType<SteamVR_LoadLevel>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Throwable")) {
            if (BallReset.collectiblesCount == 0) {
                SteamVR_LoadLevel.Begin("Level " + (SceneManager.GetActiveScene().buildIndex + 2));
                
            }
        }
    }
}
