using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class SceneService : MonoBehaviour
    {
        public const string ShopScene = "ShopScene";
        public const string ShopCardScene = "ShopCardScene";

        public static SceneService Instance { get; private set; }

        public IPayload Payload { get; private set; }

        private string _currentSceneName;
        private string _previousSceneName;

        public void Initialize()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadSceneWithPayload<TPayload>(string sceneName, TPayload payload)
            where TPayload : IPayload
        {
            Payload = payload;
            _previousSceneName = SceneManager.GetActiveScene().name;
            _currentSceneName = sceneName;

            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void ReturnBack()
        {
            if (string.IsNullOrEmpty(_currentSceneName))
            {
                return;
            }

            SceneManager.UnloadSceneAsync(_currentSceneName);
            _currentSceneName = _previousSceneName;
        }

        public TPayload GetPayload<TPayload>() where TPayload : class, IPayload
        {
            return Payload as TPayload;
        }
    }
}