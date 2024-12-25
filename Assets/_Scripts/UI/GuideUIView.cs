using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class GuideUIView : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI descriptionTxt;
        [SerializeField] private TextMeshProUGUI currentInputTxt;

        public void Init(string description)
        {
            descriptionTxt.text = description;
            Show();
        }

        public void UpdateView(string inputName)
        {
            currentInputTxt.text = "CurrentInput:: " + inputName;
        }
        private void Show() { root.SetActive(true); }
    }
}