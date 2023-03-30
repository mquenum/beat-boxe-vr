using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrateController : MonoBehaviour
{
    [SerializeField] private XRController _controller;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private  float frequency = 1.0f;

    private void Start()
    {
        //_controller = GetComponent<XRController>();
    }

    public void Vibrate()
    {
        _controller.SendHapticImpulse(amplitude, duration);
    }
}
