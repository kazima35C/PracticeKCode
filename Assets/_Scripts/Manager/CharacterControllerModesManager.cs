using UnityEngine;

public class CharacterControllerModesManager : MonoBehaviour
{
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
    }

    private void SwitchMovementMode(int modeIndex)
    {
        Debug.Log(modeIndex);
        if (modeIndex >= 0 && modeIndex < availableMovementModes.Length)
        {
            controllerModes.SwitchMode(availableMovementModes[modeIndex]);
        }
    }
}