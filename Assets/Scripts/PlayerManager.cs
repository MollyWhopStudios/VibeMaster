using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class holds player data
// singleton pattern
// holds interface for player data
public class PlayerManager : MonoBehaviour
{
    // Player
    public PlayerData player = new PlayerData();

    // Singleton ------------------------------------ DONT TOUCH
    private void Awake() { SetUpSingleton(); }
    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); } 
        } // End Singleton ------------------------------ DONT TOUCH

    // Wrappers 
    public void ResetData() { player.ResetData(); }
    public void ClickUpgrade() { player.ClickUpgrade(); }
    public void CritUpgrade() { player.CritUpgrade(); }
    public void PassiveUpgrade() { player.PassiveUpgrade(); }

    public void Load() { player.Load(); }
    public void Save() { player.Save(); }
    //---------------------------------------------
}
