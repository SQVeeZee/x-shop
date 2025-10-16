using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class CheatFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform _root;
        [SerializeField]
        private CheatView _cheatView;

        private List<CheatView> _cheatViews;

        public void Initialize(int length) => _cheatViews = new List<CheatView>(length);

        public CheatView CreateCheat()
        {
            var instance = Instantiate(_cheatView, _root);
            _cheatViews.Add(instance);
            return instance;
        }

        public void Release()
        {
            foreach (var cheatView in _cheatViews)
            {
                Destroy(cheatView.gameObject);
            }
            _cheatViews.Clear();
        }
    }
}