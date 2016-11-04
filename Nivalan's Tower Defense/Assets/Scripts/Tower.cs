using UnityEngine;
using System.Collections;

public class Tower {

    public enum TowerType
    {
        Wall,
        Air,
        Ground,
        Both
    }

    public string ownedByPlayer;
    public TowerType towerType;
    public float attackDamage;
    public float hitPoints;
    public int towerLevel;

    public Tower() { }
    public Tower(string playerName, TowerType tt)
    {
        ownedByPlayer = playerName;
        towerType = tt;
        switch (towerType)
        {
            case TowerType.Air:
                break;
            case TowerType.Ground:
                break;
            case TowerType.Both:
                break;
            default:
                Debug.Log("Creating a wall.");
                attackDamage = 0;
                hitPoints = 10;
                towerLevel = 1;
                break;
        }
    }
}
