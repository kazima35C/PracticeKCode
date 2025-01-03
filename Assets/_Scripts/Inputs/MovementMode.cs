using UnityEngine;

namespace _Scripts.Input
{
    public abstract class MovementMode : ScriptableObject
    {
        public string description;
        public abstract void HandleMovement(CharacterController characterController, Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection);

    }
}