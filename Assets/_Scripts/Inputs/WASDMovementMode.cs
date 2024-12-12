using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "WASDMovementMode", menuName = "MovementModes/WASD")]
public class WASDMovementMode : MovementMode
{
    public override void HandleMovement(CharacterController characterController, Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection)
    {
        Vector2 inputVector = playerInput.CharacterControls.Movement.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            characterTransform.rotation = Quaternion.RotateTowards(characterTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }
}
