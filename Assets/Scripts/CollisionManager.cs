using UnityEngine;
using UnityEngine.Events;

public class CollisionManager : MonoBehaviour
{
    public UnityEvent collisionEnter;

    void OnCollisionEnter(Collision elt)
    {
        collisionEnter.Invoke();
    }
}
