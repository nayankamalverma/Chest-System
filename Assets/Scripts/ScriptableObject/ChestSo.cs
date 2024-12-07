using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObject
{
    [CreateAssetMenu(fileName = "ChestSOList", menuName = "Scriptable Objects/ChestSOList")]
    public class ChestSo: UnityEngine.ScriptableObject
    {
        public List<ChestScriptableObjectScript> ChestSOList;
    }
}