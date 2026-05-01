using PurrNet;
using UnityEngine;
using System;

namespace Entity
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private SyncVar<float> _value = new SyncVar<float>(100);

        public Action<float> ValueChanged;

        private void Awake()
        {
            _value.onChanged += _ValueChanged;
        }

        private void OnDestroy()
        {
            _value.onChanged -= _ValueChanged;
        }

        private void _ValueChanged(float value)
        {
            ValueChanged?.Invoke(value);
        }

        public Health SetValue(float value)
        {
            _value.value = value;
            return this;
        }

        public Health ApplyDamage(float damage)
        {
            _value.value -= damage;
            return this;
        }

        public Health Heal(float points)
        {
            _value.value += points;
            return this;
        }

        public float GetValue()
        {
            return _value.value;
        }

    }

}
