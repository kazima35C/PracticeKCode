using TMPro;
using UnityEngine;

public class GuideUIView : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private TextMeshProUGUI descriptionTxt;


    public void Init(string description)
    {
        descriptionTxt.text = description;

        Show();
    }
    private void Show() { root.SetActive(true); }
}
