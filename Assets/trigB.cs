using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRButtonPress : MonoBehaviour
{
    public GameObject Water; // Reference to the object you want to enable
    private InputDevice rightController; // Right controller input device
    private bool isButtonPressed = false;

    void Start()
    {
        // Get the right controller at the start
        InitializeInput();
    }

    void InitializeInput()
    {
        // Initialize right controller input device
        var rightHandControllers = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, rightHandControllers);

        if (rightHandControllers.Count > 0)
        {
            rightController = rightHandControllers[0];
        }
        else
        {
            Debug.LogWarning("Right controller not found!");
        }
    }

    void Update()
    {
        if (rightController.isValid)
        {
            // Check if the "B" button (secondaryButton) is pressed
            bool buttonPressed;
            if (rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPressed) && buttonPressed)
            {
                if (!isButtonPressed) // Only trigger once on button press
                {
                    ToggleObject(true); // Enable the object
                    isButtonPressed = true;
                }
            }
            else
            {
                if (isButtonPressed) // Reset when the button is released
                {
                    ToggleObject(false); // Enable the object
                    isButtonPressed = false;
                }
            }
        }
    }

    void ToggleObject(bool enable)
    {
        if (Water != null)
        {
            Water.SetActive(enable); // Enable or disable the object
        }
    }
}
