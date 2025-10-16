using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Core
{
    public sealed class CheatView : MonoBehaviour, ICheatListener, ICheatViewer
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private Button _applyButton;

        private Action _onApply;
        private string _id;

        void ICheatListener.Subscribe(Action callback)
        {
            _onApply = callback;
            _applyButton.onClick.AddListener(ApplyClickHandler);
        }

        void ICheatListener.Release()
        {
            _applyButton.onClick.RemoveListener(ApplyClickHandler);
            _onApply = null;
        }

        void ICheatViewer.SetCurrency(string id, string value)
        {
            _id = id;
            ApplyText(id, value);
        }

        void ICheatViewer.UpdateCurrency(string value) => ApplyText(_id, value);

        private void ApplyClickHandler() => _onApply?.Invoke();
        private void ApplyText(string id, string value) => _text.text = $"{id}: {value}";
    }
}