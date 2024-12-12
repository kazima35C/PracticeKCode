using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameUIView : MonoBehaviour
{
    public GuideUIView guideUIView;
    public JoystickUIView joystickUIView;
    internal void Init(InputSystemManager characterControllerModesManager)
    {
        guideUIView.Init(characterControllerModesManager.GetDescriptions().ToSafeString());
        joystickUIView.Init();

    }
}