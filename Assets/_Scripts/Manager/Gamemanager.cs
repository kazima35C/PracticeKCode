using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Gamemanager : MonoBehaviour
{
    public CharacterControllerMovement prefabCharacter;
    public CharacterControllerModesManager characterControllerModesManager;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public Transform parentCharcater;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        var charcater = Instantiate(prefabCharacter, parentCharcater);
        characterControllerModesManager.Init(charcater);
        SetCamera(charcater.transform);
    }

    private void SetCamera(Transform target)
    {
        cinemachineVirtualCamera.LookAt = target;
        cinemachineVirtualCamera.Follow = target;
    }
}
