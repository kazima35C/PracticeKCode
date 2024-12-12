using UnityEngine;

public class JoystickUIView : MonoBehaviour
{
    [SerializeField] private GameObject root;

    public void Init()
    {
        Hide();
    }
    public void Show() { root.SetActive(true); }
    public void Hide() { root.SetActive(false); }

}
