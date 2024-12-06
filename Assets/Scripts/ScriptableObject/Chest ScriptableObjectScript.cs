using UnityEngine;
using Assets.Scripts.Chest;

[CreateAssetMenu(fileName = "ChestScriptableObjectScript", menuName = "Scriptable Objects/ChestScriptableObjectScript")]
public class ChestScriptableObjectScript : ScriptableObject
{
    int minCoins;
    int maxCoins;
    int minGems;
    int maxGems;
    ChestType type;

}
