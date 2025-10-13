using UnityEngine;

namespace Shop.Core
{
    public sealed class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public int GetDataInt(string key) => PlayerPrefs.GetInt(key, 0);
        public void SetDataInt(string key, int value) => PlayerPrefs.SetInt(key, value);

        public void GetDataString(string key) => PlayerPrefs.GetString(key, string.Empty);
        public void SetDataString(string key, string value) => PlayerPrefs.SetString(key, value);

        public void GetDataFloat(string key) => PlayerPrefs.GetFloat(key, 0f);
        public void SetDataFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
    }
}
