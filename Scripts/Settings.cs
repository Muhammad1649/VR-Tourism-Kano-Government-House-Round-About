using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Settings : MonoBehaviour
{
    public GameObject ray;
    public GameObject preferencesUI;
    public Transform uiPosition;
    private XRNode inputDevice;
    private bool menuBtnPressed;
    private bool uiEnabled;
    // Snap Turn Variables
    public SnapTurnProvider turnProvider;
    public List<XRController> turnController;
    public XRController rightController;
    public XRController leftController;
    // Teleportation Variables
    // public XRController teleportRay;
    // public LocomotionSystem ls;
    // public TeleportationProvider tp;
    // public TeleportController tc;
    // public GameObject tr;
    // public GameObject rb;
    // public GameObject ta;
    // Joystic Movement Variables
    public playerMovement joysticMovement;
    public CharacterController cc;
    void Awake()
    {
        FindObjectOfType<ChangeWeather>().SetDefaultWeather();
        RefereshSettings();
        // if (PlayerPrefs.GetString("Movement") == "Joystic")
        // {
        //     SetjoysticMovement();
        // } else if (PlayerPrefs.GetString("Movement") == "Teleportation")
        // {
        //     SetTeleportation();
        // }
        if (PlayerPrefs.GetString("Hand") == "Right")
        {
            // teleportRay.controllerNode = XRNode.RightHand;
            joysticMovement.inputSource = XRNode.RightHand;
            ray.GetComponent<XRController>().controllerNode = XRNode.RightHand;
            turnController = new List<XRController>{leftController};
            turnProvider.controllers = turnController;
            inputDevice = XRNode.RightHand;
        } else if (PlayerPrefs.GetString("Hand") == "Left")
        {
            // teleportRay.controllerNode = XRNode.LeftHand;
            joysticMovement.inputSource = XRNode.LeftHand;
            ray.GetComponent<XRController>().controllerNode = XRNode.LeftHand;
            turnController = new List<XRController>{rightController};
            turnProvider.controllers = turnController;
            inputDevice = XRNode.LeftHand;
        }
        uiEnabled = false;
        preferencesUI.SetActive(false);
    }
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputDevice);
        bool menuBtnPressed;
        device.TryGetFeatureValue(CommonUsages.menuButton, out menuBtnPressed);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out menuBtnPressed);

        if(menuBtnPressed || Input.GetKey("s"))
        {
            ShowPreferances(true);
        }
        // else if(!menuBtnPressed || Input.GetKeyDown("h")){
        //     ShowPreferances(false);
        // }
        // preferencesUI.transform.position = uiPosition.position;
        // preferencesUI.transform.rotation = uiPosition.rotation;
    }
    public void ShowPreferances(bool showUI)
    {
        if(!uiEnabled && showUI)
        {
            preferencesUI.SetActive(true);
            preferencesUI.transform.position = uiPosition.position;
            preferencesUI.transform.rotation = uiPosition.rotation;
            ray.SetActive(true);
            uiEnabled = true;
        }
        if(uiEnabled && !showUI)
        {
            preferencesUI.SetActive(false);
            ray.SetActive(false);
            uiEnabled = false;
        }
    }
        // -----   Settings    ---- //
    void RefereshSettings()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 0));
    }
    public void SetQualitySettings(int qualityIndex)
    {
        PlayerPrefs.SetInt("Quality", qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
        RefereshSettings();
    }
        // -----   Settings    ---- //

    // void SetjoysticMovement()
    // {
    //     // Disable Teleportation
    //     ls.enabled = false;
    //     tp.enabled = false;
    //     tc.enabled = false;
    //     tr.SetActive(false);
    //     rb.SetActive(false);
    //     ta.SetActive(false);
    //     // Enable Joystic Movement
    //     joysticMovement.enabled = true;
    //     cc.enabled = true;
    // }
    // void SetTeleportation()
    // {
    //     // Disable Joystic Movement
    //     joysticMovement.enabled = false;
    //     cc.enabled = false;
    //     // Enable Teleportation
    //     ls.enabled = true;
    //     tp.enabled = true;
    //     tc.enabled = true;
    //     tr.SetActive(true);
    //     rb.SetActive(true);
    //     ta.SetActive(true);
    // }
}
