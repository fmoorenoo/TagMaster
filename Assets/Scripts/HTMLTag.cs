using UnityEngine;

public class HTMLTag : MonoBehaviour
{
    private Transform originalParent;

    public void Grab(Transform hand)
    {
        originalParent = transform.parent; 
        transform.SetParent(hand); 
        transform.localPosition = Vector3.zero; 
    }

    public void Release()
    {
        transform.SetParent(originalParent); 
    }
}
