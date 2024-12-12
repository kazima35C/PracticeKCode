using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MovementMode : ScriptableObject
{
    public abstract void HandleMovement(CharacterController characterController, Transform characterTransform, Controller playerInput, float moveSpeed, float rotationSpeed, ref Vector3 moveDirection);
}