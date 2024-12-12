using _Scripts.Input;
using UnityEngine;
namespace _Scripts.Character
{
    public class CharacterControllerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float rotationSpeed = 720f;
        public MovementMode currentMovementMode;
        private Controller playerInputController;
        private Vector3 movementDirection;
        private bool isPlayerInitialized = false;

        public void Init(Controller playerInputController)
        {
            isPlayerInitialized = true;
            this.playerInputController = playerInputController;
        }

        private void Update()
        {
            if (!isPlayerInitialized) { return; }
            currentMovementMode.HandleMovement(
                characterController,
                transform,
                playerInputController,
                movementSpeed,
                rotationSpeed,
                ref movementDirection
            );
        }

        public void SwitchMode(MovementMode newMovementMode)
        {
            this.currentMovementMode = newMovementMode;
        }
    }
}
