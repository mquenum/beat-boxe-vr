using UnityEngine;

public class PlayerCounterManager : MonoBehaviour
{
    [SerializeField] private GameObject _rightHand;
    public bool _hasCounterPosition = false;
    public static PlayerCounterManager SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _rightHand)
        {
            _hasCounterPosition = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightHand)
        {
            _hasCounterPosition = false;
        }
    }

}
        