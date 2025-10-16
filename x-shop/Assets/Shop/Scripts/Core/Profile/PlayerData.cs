using System.Collections.Generic;
using UnityEngine;

namespace Shop.Core
{
    public sealed class PlayerData : MonoBehaviour //IService
    {
        public static PlayerData Instance { get; private set; }

        private readonly Dictionary<string, int> _intData = new();
        private readonly Dictionary<string, float> _floatData = new();
        private readonly Dictionary<string, string> _stringData = new();

        public void /*IService*/Initialize() => Instance = this;
        public void /*IService*/Release()
        {
            Instance = null;
            _intData.Clear();
            _floatData.Clear();
            _stringData.Clear();
        }

        public int GetDataInt(string key) => _intData.GetValueOrDefault(key, 0);
        public void SetDataInt(string key, int value) => _intData[key] = value;

        public string GetDataString(string key) => _stringData.TryGetValue(key, out var value) ? value : string.Empty;
        public void SetDataString(string key, string value, bool isNotify = false) => _stringData[key] = value;

        public float GetDataFloat(string key) => _floatData.GetValueOrDefault(key, 0f);
        public void SetDataFloat(string key, float value) => _floatData[key] = value;
    }
}
