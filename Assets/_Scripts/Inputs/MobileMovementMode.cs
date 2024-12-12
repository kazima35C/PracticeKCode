using UnityEngine;
namespace _Scripts.Input
{
    [CreateAssetMenu(fileName = "MobileMovementMode", menuName = "MovementModes/Mobile")]
    public class MobileMovementMode : MovementMode
    {
        public override void HandleMovement(CharacterController characterController,
         Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection)
        {
            Vector2 joystickInput = playerInput.CharacterControls.JoystickMovement.ReadValue<Vector2>();
            Vector3 direction = new Vector3(joystickInput.x, 0, joystickInput.y);

            Vector2 rotationInput = playerInput.CharacterControls.JoystickRotation.ReadValue<Vector2>();
            Vector3 rotationDirection = new Vector3(rotationInput.x, 0, rotationInput.y);

            if (rotationDirection.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(rotationDirection.x, rotationDirection.z) * Mathf.Rad2Deg;
                float smoothedAngle = Mathf.LerpAngle(characterTransform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
                characterTransform.rotation = Quaternion.Euler(0, smoothedAngle, 0);
            }

            if (direction.magnitude > 0.1f)
            {
                characterController.Move(direction * moveSpeed * Time.deltaTime);
            }
        }
    }
}
