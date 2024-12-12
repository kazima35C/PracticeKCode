using UnityEngine;

public class JoystickUIView : MonoBehaviour
{
    [SerializeField] private GameObject root;

    public void Init()
    {
        Show();
    }
    private void Show() { root.SetActive(true); }

}
