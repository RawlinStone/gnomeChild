using UnityEngine;

public class fakeRotation : MonoBehaviour
{
    [SerializeField]
    Transform fakeParent;
    Vector3 offset;

    void FixedUpdate()
    {
        //transform.rotation = fakeParent.rotation;
        transform.position = fakeParent.position + offset;
    }
}