using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class HandPresence : MonoBehaviour
{
    public XRNode controller;
    private Animator handAnimator;
    private InputDevice device;
    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controller);
        handAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        UpdateHandAnimation();
    }
    void UpdateHandAnimation()
    {
        if (device.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        } else { handAnimator.SetFloat("Grip", 0); }

        if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        } else { handAnimator.SetFloat("Trigger", 0); }
    }
}
