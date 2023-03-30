using UnityEngine;
using UnityEngine.XR;

public class Vibrate : MonoBehaviour
{
    private XRNode leftControllerNode = XRNode.LeftHand;
    private XRNode rightControllerNode = XRNode.RightHand;
    public static Vibrate SharedInstance;


    private void Awake()
    {
        SharedInstance = this;
    }

    public void VibrateControllers(float amp, float dur)
    {
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(leftControllerNode);
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(rightControllerNode);

        if (leftDevice.isValid)
        {
            leftDevice.SendHapticImpulse(0, amp, dur);
        }
        if (rightDevice.isValid)
        {
            rightDevice.SendHapticImpulse(0, amp, dur);
        }
    }
}
