using UnityEngine;
using UnityEngine.InputSystem;
namespace _Scripts.Input
{

    [CreateAssetMenu(fileName = "PointAndClickMovementMode", menuName = "MovementModes/PointAndClick")]
    public class PointAndClickMovementMode : MovementMode
    {
        private Vector3 targetPoint;
        public bool isMoving = false;
        public float lastMovementTime;
        private float resetThreshold = .2f; // Time in seconds to reset movement

        public override void HandleMovement(CharacterController characterController, Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection)
        {
            if (isMoving && (Mathf.Abs(Time.time - lastMovementTime) > resetThreshold))
            {
                isMoving = false;
            }
            lastMovementTime = Time.time;
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
}