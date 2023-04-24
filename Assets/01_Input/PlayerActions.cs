//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/01_Input/PlayerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""d899ae05-0cd2-4550-96bb-a4f336633bcc"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""220cf888-b87f-41ae-b9b3-42c99d3f1299"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f57d59d0-7274-4a3b-b7b6-73fe4712aadf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""ce597d36-1b48-4ebe-aa9a-4ca01d53f7eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveCameraX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c5998561-2ef5-40bc-b8be-af45833e6018"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveCameraY"",
                    ""type"": ""Value"",
                    ""id"": ""ac5fa7aa-7bb3-418b-8266-a3588d3b61d8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TimeTravel"",
                    ""type"": ""Button"",
                    ""id"": ""e371f6b9-a4c0-4395-9203-6d97b3ed375f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b4a9285f-19cc-4815-8d0f-7de12d7f407d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29cbf3e6-aed3-4def-87b1-0088a6e9cdf3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3369d740-2baf-4f15-9da5-76d0e2e12b86"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""573b1403-290a-4887-88dc-38a57419fce8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6ec54c32-0249-42ef-9c9f-4a9b5f851530"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b00f6948-f2b8-4cdd-a21a-408b38a1b17f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e45bf57-3cc2-450e-af79-f03a90f3a779"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e34d180-fcdc-4687-9c1c-4676a89790a1"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCameraX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b0baaff-a76c-4866-af95-3ad5601093ff"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCameraY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""810b1fb6-1b33-4ba2-b200-86f1aeb4840b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TimeTravel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Walk = m_PlayerActionMap.FindAction("Walk", throwIfNotFound: true);
        m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActionMap_Sprint = m_PlayerActionMap.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerActionMap_MoveCameraX = m_PlayerActionMap.FindAction("MoveCameraX", throwIfNotFound: true);
        m_PlayerActionMap_MoveCameraY = m_PlayerActionMap.FindAction("MoveCameraY", throwIfNotFound: true);
        m_PlayerActionMap_TimeTravel = m_PlayerActionMap.FindAction("TimeTravel", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
    private readonly InputAction m_PlayerActionMap_Walk;
    private readonly InputAction m_PlayerActionMap_Jump;
    private readonly InputAction m_PlayerActionMap_Sprint;
    private readonly InputAction m_PlayerActionMap_MoveCameraX;
    private readonly InputAction m_PlayerActionMap_MoveCameraY;
    private readonly InputAction m_PlayerActionMap_TimeTravel;
    public struct PlayerActionMapActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerActionMapActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_PlayerActionMap_Walk;
        public InputAction @Jump => m_Wrapper.m_PlayerActionMap_Jump;
        public InputAction @Sprint => m_Wrapper.m_PlayerActionMap_Sprint;
        public InputAction @MoveCameraX => m_Wrapper.m_PlayerActionMap_MoveCameraX;
        public InputAction @MoveCameraY => m_Wrapper.m_PlayerActionMap_MoveCameraY;
        public InputAction @TimeTravel => m_Wrapper.m_PlayerActionMap_TimeTravel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @MoveCameraX.started += instance.OnMoveCameraX;
            @MoveCameraX.performed += instance.OnMoveCameraX;
            @MoveCameraX.canceled += instance.OnMoveCameraX;
            @MoveCameraY.started += instance.OnMoveCameraY;
            @MoveCameraY.performed += instance.OnMoveCameraY;
            @MoveCameraY.canceled += instance.OnMoveCameraY;
            @TimeTravel.started += instance.OnTimeTravel;
            @TimeTravel.performed += instance.OnTimeTravel;
            @TimeTravel.canceled += instance.OnTimeTravel;
        }

        private void UnregisterCallbacks(IPlayerActionMapActions instance)
        {
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @MoveCameraX.started -= instance.OnMoveCameraX;
            @MoveCameraX.performed -= instance.OnMoveCameraX;
            @MoveCameraX.canceled -= instance.OnMoveCameraX;
            @MoveCameraY.started -= instance.OnMoveCameraY;
            @MoveCameraY.performed -= instance.OnMoveCameraY;
            @MoveCameraY.canceled -= instance.OnMoveCameraY;
            @TimeTravel.started -= instance.OnTimeTravel;
            @TimeTravel.performed -= instance.OnTimeTravel;
            @TimeTravel.canceled -= instance.OnTimeTravel;
        }

        public void RemoveCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnMoveCameraX(InputAction.CallbackContext context);
        void OnMoveCameraY(InputAction.CallbackContext context);
        void OnTimeTravel(InputAction.CallbackContext context);
    }
}
