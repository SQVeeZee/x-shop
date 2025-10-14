using UnityEngine;

namespace Shop
{
    public class SceneService : MonoBehaviour
    {
        public static SceneService Instance { get; private set; }

        public void Initialize() => Instance = this;

        public void LoadScene()
        {

        }
    }
}