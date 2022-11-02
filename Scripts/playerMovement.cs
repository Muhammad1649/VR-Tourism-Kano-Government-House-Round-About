using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class playerMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    public float additionalHeight = 0.2f;
    // public Camera cam;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        controller.Move(direction * Time.fixedDeltaTime * speed);
    }

    void CapsuleFollowHeadset()
    {
        controller.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        controller.center = new Vector3(capsuleCenter.x, controller.height/2 + controller.skinWidth, capsuleCenter.z);
    }
}
