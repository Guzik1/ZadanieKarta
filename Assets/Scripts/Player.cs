using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player: MonoBehaviour, AplayableEffect
    {
        public int Health = 100;
        public int Mana = 100;
        public int Speed = 10;

        public TMP_InputField HealthInput;
        public TMP_InputField ManaInput;
        public TMP_InputField SpeedInput;

        void Start()
        {
            SetStatsValueToInputs();
        }

        public void ApplayEffect(CardEffect effect)
        {
            Health += effect.HealthChange;
            Mana += effect.ManaChange;
            Speed += effect.SpeedChange;

            SetStatsValueToInputs();
        }

        public void OnHealthValueChange(string newValue)
        {
            if (int.TryParse(newValue, out int value))
            {
                Health = value;
            }
        }

        public void OnManaValueChange(string newValue)
        {
            if (int.TryParse(newValue, out int value))
            {
                Mana = value;
            }
        }

        public void OnSpeedValueChange(string newValue)
        {
            if (int.TryParse(newValue, out int value))
            {
                Speed = value;
            }
        }

        void SetStatsValueToInputs()
        {
            HealthInput.text = Health.ToString();
            ManaInput.text = Mana.ToString();
            SpeedInput.text = Speed.ToString();
        }
    }
}
