//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/weapons/WeaponsControlls.inputactions
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

public partial class @WeaponsControlls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @WeaponsControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WeaponsControlls"",
    ""maps"": [
        {
            ""name"": ""WeaponControls"",
            ""id"": ""11db2b5e-461e-48d5-a673-8cfa966f1011"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""d96e1f14-9db1-45b7-bd0a-7f002d9a892e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""WeaponChange"",
                    ""type"": ""Button"",
                    ""id"": ""24f57cf2-06d8-48dc-ba36-f670f17ef2d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""907dcd67-b2c3-4868-8199-b9eb62e20bda"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""468625b1-1c7f-43dd-8fde-821eeebedb0d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bfc6903-a54a-4477-8fce-2ee6f0859d0c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""WeaponChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9367092-7203-456f-9d3f-83ccde371642"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""WeaponChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // WeaponControls
        m_WeaponControls = asset.FindActionMap("WeaponControls", throwIfNotFound: true);
        m_WeaponControls_Shoot = m_WeaponControls.FindAction("Shoot", throwIfNotFound: true);
        m_WeaponControls_WeaponChange = m_WeaponControls.FindAction("WeaponChange", throwIfNotFound: true);
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

    // WeaponControls
    private readonly InputActionMap m_WeaponControls;
    private List<IWeaponControlsActions> m_WeaponControlsActionsCallbackInterfaces = new List<IWeaponControlsActions>();
    private readonly InputAction m_WeaponControls_Shoot;
    private readonly InputAction m_WeaponControls_WeaponChange;
    public struct WeaponControlsActions
    {
        private @WeaponsControlls m_Wrapper;
        public WeaponControlsActions(@WeaponsControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_WeaponControls_Shoot;
        public InputAction @WeaponChange => m_Wrapper.m_WeaponControls_WeaponChange;
        public InputActionMap Get() { return m_Wrapper.m_WeaponControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponControlsActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponControlsActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @WeaponChange.started += instance.OnWeaponChange;
            @WeaponChange.performed += instance.OnWeaponChange;
            @WeaponChange.canceled += instance.OnWeaponChange;
        }

        private void UnregisterCallbacks(IWeaponControlsActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @WeaponChange.started -= instance.OnWeaponChange;
            @WeaponChange.performed -= instance.OnWeaponChange;
            @WeaponChange.canceled -= instance.OnWeaponChange;
        }

        public void RemoveCallbacks(IWeaponControlsActions instance)
        {
            if (m_Wrapper.m_WeaponControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponControlsActions @WeaponControls => new WeaponControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IWeaponControlsActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnWeaponChange(InputAction.CallbackContext context);
    }
}