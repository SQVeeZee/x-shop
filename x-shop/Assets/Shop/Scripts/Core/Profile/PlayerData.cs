using System.Collections.Generic;
using UnityEngine;

namespace Shop.Core
{
    public sealed class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance { get; private set; }

        private readonly Dictionary<string, int> _intData = new();
        private readonly Dictionary<string, float> _floatData = new();
        private readonly Dictionary<string, string> _stringData = new();

        public void Initialize() => Instance = this;

        public int GetDataInt(string key) => _intData.GetValueOrDefault(key, 0);
        public void SetDataInt(string key, int value) => _intData[key] = value;

        public string GetDataString(string key) => _stringData.TryGetValue(key, out var value) ? value : string.Empty;
        public void SetDataString(string key, string value) => _stringData[key] = value;

        public float GetDataFloat(string key) => _floatData.GetValueOrDefault(key, 0f);
        public void SetDataFloat(string key, float value) => _floatData[key] = value;

        public void Release()
        {
            Instance = null;
            _intData.Clear();
            _floatData.Clear();
            _stringData.Clear();
        }
    }
}
