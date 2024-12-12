using System.Text;
using _Scripts.Character;
using _Scripts.Input;
using _Scripts.Utils;
using UnityEngine;
namespace _Scripts.Manager
{
    public class InputSystemManager : MonoBehaviour
    {
        public Observable<string> observerCurrentInput;
        public string currentInput => observerCurrentInput.value;
        [SerializeField] private CharacterControllerMovement controllerModes;
        [SerializeField] private MovementMode[] availableMovementModes;
        private Controller playerInputController;

        public void Init(CharacterControllerMovement controllerModes)
        {
            this.controllerModes = controllerModes;
            playerInputController = new Controller();

            playerInputController.CharacterControls.Enable();

            playerInputController.CharacterControls.SwitchMode1.performed += ctx => SwitchMovementMode(0);
            playerInputController.CharacterControls.SwitchMode2.performed += ctx => SwitchMovementMode(1);
            playerInputController.CharacterControls.SwitchMode3.performed += ctx => SwitchMovementMode(2);

            this.controllerModes.Init(playerInputController);
            this.controllerModes.SwitchMode(availableMovementModes[0]);
            observerCurrentInput.value = availableMovementModes[0].description;
        }

        private void SwitchMovementMode(int modeIndex)
        {
            if (modeIndex >= 0 && modeIndex < availableMovementModes.Length)
            {
                controllerModes.SwitchMode(availableMovementModes[modeIndex]);
                observerCurrentInput.value = availableMovementModes[modeIndex].description;
            }
        }

        public StringBuilder GetDescriptions()
        {
            StringBuilder desc = new StringBuilder();
            for (int i = 0; i < availableMovementModes.Length; i++)
            {
                desc.AppendLine($"numpad{i + 1} => {availableMovementModes[i].description}");
            }
            return desc;
        }
    }
}