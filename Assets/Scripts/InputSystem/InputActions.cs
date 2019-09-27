// GENERATED AUTOMATICALLY FROM 'Assets/Input System/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""00da5f0e-79dc-457f-a9be-0cc646365668"",
            ""actions"": [
                {
                    ""name"": ""LeftHandUsage"",
                    ""id"": ""59bd2ad0-2559-4059-8a64-c66b12664e86"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""RightHandUsage"",
                    ""id"": ""248c5f7a-20ca-495e-8519-cf67df2c255c"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Movement"",
                    ""id"": ""e2570798-495d-436f-8b33-ab6c05e09c9c"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Rotation"",
                    ""id"": ""ebc55be9-663d-430f-8923-85a367395a8a"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""OpenEquipmentScreen"",
                    ""id"": ""d8a36d5d-92d2-4854-9543-9c13f3968f59"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""966ea4c4-a317-4184-84c5-db4030150a84"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""LeftHandUsage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""53644686-c60b-44ba-aada-922d5bdfbc21"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightHandUsage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""76d3a168-2532-445e-91d4-75b4105ac733"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a98fe9a1-f1a0-46a5-85f0-f2f80ec4260e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""db57650f-1bd1-4590-b2a9-dce90ab09c4a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""24f2e13f-116d-42d8-96f1-b9bbb0b6a593"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4e691909-528a-4aea-8656-5e51857e2352"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""8f0c8900-2c43-41be-a001-13b0e49b48e0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""b3a1d05a-91a1-4049-a66f-eb485d42991a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""OpenEquipmentScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        },
        {
            ""name"": ""UIPlayer"",
            ""id"": ""8aee59c9-334b-4e9e-87ce-c6d3cd739f6e"",
            ""actions"": [
                {
                    ""name"": ""CloseEquipmentScreen"",
                    ""id"": ""90d7b17d-15d6-4963-8ba5-1779a5c9fa45"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b12464b0-8b48-428a-b0f8-b2c60e7d1dd8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CloseEquipmentScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_LeftHandUsage = m_Player.GetAction("LeftHandUsage");
        m_Player_RightHandUsage = m_Player.GetAction("RightHandUsage");
        m_Player_Movement = m_Player.GetAction("Movement");
        m_Player_Rotation = m_Player.GetAction("Rotation");
        m_Player_OpenEquipmentScreen = m_Player.GetAction("OpenEquipmentScreen");
        // UIPlayer
        m_UIPlayer = asset.GetActionMap("UIPlayer");
        m_UIPlayer_CloseEquipmentScreen = m_UIPlayer.GetAction("CloseEquipmentScreen");
    }

    ~InputActions()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

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

    // Player
    private InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private InputAction m_Player_LeftHandUsage;
    private InputAction m_Player_RightHandUsage;
    private InputAction m_Player_Movement;
    private InputAction m_Player_Rotation;
    private InputAction m_Player_OpenEquipmentScreen;
    public struct PlayerActions
    {
        private InputActions m_Wrapper;
        public PlayerActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftHandUsage { get { return m_Wrapper.m_Player_LeftHandUsage; } }
        public InputAction @RightHandUsage { get { return m_Wrapper.m_Player_RightHandUsage; } }
        public InputAction @Movement { get { return m_Wrapper.m_Player_Movement; } }
        public InputAction @Rotation { get { return m_Wrapper.m_Player_Rotation; } }
        public InputAction @OpenEquipmentScreen { get { return m_Wrapper.m_Player_OpenEquipmentScreen; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                LeftHandUsage.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHandUsage;
                LeftHandUsage.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHandUsage;
                LeftHandUsage.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHandUsage;
                RightHandUsage.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHandUsage;
                RightHandUsage.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHandUsage;
                RightHandUsage.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHandUsage;
                Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                Rotation.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                Rotation.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                Rotation.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                OpenEquipmentScreen.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenEquipmentScreen;
                OpenEquipmentScreen.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenEquipmentScreen;
                OpenEquipmentScreen.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenEquipmentScreen;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                LeftHandUsage.started += instance.OnLeftHandUsage;
                LeftHandUsage.performed += instance.OnLeftHandUsage;
                LeftHandUsage.canceled += instance.OnLeftHandUsage;
                RightHandUsage.started += instance.OnRightHandUsage;
                RightHandUsage.performed += instance.OnRightHandUsage;
                RightHandUsage.canceled += instance.OnRightHandUsage;
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Rotation.started += instance.OnRotation;
                Rotation.performed += instance.OnRotation;
                Rotation.canceled += instance.OnRotation;
                OpenEquipmentScreen.started += instance.OnOpenEquipmentScreen;
                OpenEquipmentScreen.performed += instance.OnOpenEquipmentScreen;
                OpenEquipmentScreen.canceled += instance.OnOpenEquipmentScreen;
            }
        }
    }
    public PlayerActions @Player
    {
        get
        {
            return new PlayerActions(this);
        }
    }

    // UIPlayer
    private InputActionMap m_UIPlayer;
    private IUIPlayerActions m_UIPlayerActionsCallbackInterface;
    private InputAction m_UIPlayer_CloseEquipmentScreen;
    public struct UIPlayerActions
    {
        private InputActions m_Wrapper;
        public UIPlayerActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseEquipmentScreen { get { return m_Wrapper.m_UIPlayer_CloseEquipmentScreen; } }
        public InputActionMap Get() { return m_Wrapper.m_UIPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(UIPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IUIPlayerActions instance)
        {
            if (m_Wrapper.m_UIPlayerActionsCallbackInterface != null)
            {
                CloseEquipmentScreen.started -= m_Wrapper.m_UIPlayerActionsCallbackInterface.OnCloseEquipmentScreen;
                CloseEquipmentScreen.performed -= m_Wrapper.m_UIPlayerActionsCallbackInterface.OnCloseEquipmentScreen;
                CloseEquipmentScreen.canceled -= m_Wrapper.m_UIPlayerActionsCallbackInterface.OnCloseEquipmentScreen;
            }
            m_Wrapper.m_UIPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                CloseEquipmentScreen.started += instance.OnCloseEquipmentScreen;
                CloseEquipmentScreen.performed += instance.OnCloseEquipmentScreen;
                CloseEquipmentScreen.canceled += instance.OnCloseEquipmentScreen;
            }
        }
    }
    public UIPlayerActions @UIPlayer
    {
        get
        {
            return new UIPlayerActions(this);
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLeftHandUsage(InputAction.CallbackContext context);
        void OnRightHandUsage(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnOpenEquipmentScreen(InputAction.CallbackContext context);
    }
    public interface IUIPlayerActions
    {
        void OnCloseEquipmentScreen(InputAction.CallbackContext context);
    }
}
