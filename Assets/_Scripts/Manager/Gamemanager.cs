using _Scripts.Character;
using _Scripts.Input;
using _Scripts.UI;
using Cinemachine;
using UnityEngine;
namespace _Scripts
{
    public class Gamemanager : MonoBehaviour
    {
        [SerializeField] private CharacterControllerMovement prefabCharacter;
        [SerializeField] private InputSystemManager characterControllerModesManager;
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private Transform parentCharcater;
        [SerializeField] private GameUIView gameUIView;

        private void Start()
        {
            Init();
        }
        private void Init()
        {
            var charcater = Instantiate(prefabCharacter, parentCharcater);
            characterControllerModesManager.Init(charcater);
            gameUIView.Init(characterControllerModesManager);
            SetCamera(charcater.transform);
        }

        private void SetCamera(Transform target)
        {
            cinemachineVirtualCamera.LookAt = target;
            cinemachineVirtualCamera.Follow = target;
        }
    }
}
