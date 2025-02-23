using UnityEngine;
using Assets.Scripts.Chest;

[CreateAssetMenu(fileName = "ChestScriptableObjectScript", menuName = "Scriptable Objects/ChestScriptableObjectScript")]
public class ChestScriptableObjectScript : ScriptableObject
{
    public string chestName;
    public ChestType chestType;
    public Sprite chestLockedImage;
    public Sprite chestOpenedImage;
    public float unlockTimeInSec;
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;

}
