using _Scripts.Manager;
using Unity.VisualScripting;
using UnityEngine;
namespace _Scripts.UI
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private GuideUIView guideUIView;
        [SerializeField] private JoystickUIView joystickUIView;
        InputSystemManager inputManager;
        internal void Init(InputSystemManager characterControllerModesManager)
        {
            guideUIView.Init(characterControllerModesManager.GetDescriptions().ToSafeString());
            joystickUIView.Init();

            this.inputManager = characterControllerModesManager;
            this.inputManager.observerCurrentInput.onChange += UpdateView;
            UpdateView();
        }

        void UpdateView()
        {
            var activeJoystick = inputManager.currentInput.Contains("joystick");
            guideUIView.UpdateView(inputManager.currentInput);
            if (activeJoystick)
            {
                joystickUIView.Show();
                return;
            }
            joystickUIView.Hide();
        }
    }
}