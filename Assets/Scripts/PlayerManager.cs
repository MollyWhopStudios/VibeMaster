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
    public EnemyData enemy = new EnemyData();

    // Singleton ------------------------------------ DONT TOUCH
    private void Awake() { SetUpSingleton(); }
    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); Load(); } // and Auto Load
        } // End Singleton ------------------------------ DONT TOUCH

    // Wrappers 
    public void ResetData() { player.ResetData(); }
    public void ClickUpgrade() { player.ClickUpgrade(); }
    public void CritUpgrade() { player.CritUpgrade(); }
    public void PassiveUpgrade() { player.PassiveUpgrade(); }

    public void Load() { player.Load(); LoadEnemyLevel(); }
    public void Save() { player.Save(); }
    //---------------------------------------------

    public void LevelUp()
    {
        enemy.SetLevel(enemy.GetLevel() + 1);
        player.SetLevel(player.GetLevel() + 1);
    }

    public void LoadEnemyLevel()
    {
        enemy.SetLevel(player.GetLevel());
    }
}
