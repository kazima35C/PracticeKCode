using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PointAndClickMovementMode", menuName = "MovementModes/PointAndClick")]
public class PointAndClickMovementMode : MovementMode
{
    private Vector3 targetPoint;
    private bool isMoving = false;

    public override void HandleMovement(CharacterController characterController, Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection)
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPoint = hit.point;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            Vector3 direction = (targetPoint - characterTransform.position).normalized;
            direction.y = 0;

            if (Vector3.Distance(characterTransform.position, targetPoint) > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                characterTransform.rotation = Quaternion.RotateTowards(characterTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                characterController.Move(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
    }
}