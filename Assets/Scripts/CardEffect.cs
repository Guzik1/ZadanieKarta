using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    [CreateAssetMenu(fileName = "CardEffect", menuName = "ScriptableObjects/Card Effect", order = 1)]
    public class CardEffect: ScriptableObject
    {
        public int HealthChange;
        public int ManaChange;
        public int SpeedChange;
    }
}
