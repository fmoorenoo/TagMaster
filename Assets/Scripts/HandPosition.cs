using UnityEngine;

public class HandPosition : MonoBehaviour
{
    public Transform thumb;
    public Transform indexFinger;
    public Transform middleFinger;
    public Transform ringFinger;
    public Transform littleFinger;

    private HTMLTag currentTag = null; 
    private HTMLTag heldTag = null;  

    private Quaternion closedThumb;
    private Quaternion closedIndex;
    private Quaternion closedMiddle;
    private Quaternion closedRing;
    private Quaternion closedLittle;

    private Quaternion initialThumbRotation;
    private Quaternion initialIndexRotation;
    private Quaternion initialMiddleRotation;
    private Quaternion initialRingRotation;
    private Quaternion initialLittleRotation;

    void Start()
    {
        initialThumbRotation = thumb.localRotation;
        initialIndexRotation = indexFinger.localRotation;
        initialMiddleRotation = middleFinger.localRotation;
        initialRingRotation = ringFinger.localRotation;
        initialLittleRotation = littleFinger.localRotation;

        closedThumb = Quaternion.Euler(-30, 0, 0);
        closedIndex = Quaternion.Euler(-90, 0, 0);
        closedMiddle = Quaternion.Euler(-90, 0, 0);
        closedRing = Quaternion.Euler(-90, 0, 0);
        closedLittle = Quaternion.Euler(-90, 0, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CloseHand();

            if (currentTag != null && heldTag == null)
            {
                float distance = Vector3.Distance(transform.position, currentTag.transform.position);
                if (distance < 0.5f)
                {
                    heldTag = currentTag;
                    heldTag.Grab(transform);
                }
            }
        }
        else
        {
            OpenHand();

            if (heldTag != null)
            {
                heldTag.Release();
                heldTag = null;

                LevelManager levelManager = FindObjectOfType<LevelManager>();
                if (levelManager != null)
                {
                    levelManager.CheckOrder();
                }
            }
        }
    }


    private void CloseHand()
    {
        thumb.localRotation = Quaternion.Lerp(thumb.localRotation, closedThumb, Time.deltaTime * 10);
        indexFinger.localRotation = Quaternion.Lerp(indexFinger.localRotation, closedIndex, Time.deltaTime * 10);
        middleFinger.localRotation = Quaternion.Lerp(middleFinger.localRotation, closedMiddle, Time.deltaTime * 10);
        ringFinger.localRotation = Quaternion.Lerp(ringFinger.localRotation, closedRing, Time.deltaTime * 10);
        littleFinger.localRotation = Quaternion.Lerp(littleFinger.localRotation, closedLittle, Time.deltaTime * 10);
    }

    private void OpenHand()
    {
        thumb.localRotation = Quaternion.Lerp(thumb.localRotation, initialThumbRotation, Time.deltaTime * 10);
        indexFinger.localRotation = Quaternion.Lerp(indexFinger.localRotation, initialIndexRotation, Time.deltaTime * 10);
        middleFinger.localRotation = Quaternion.Lerp(middleFinger.localRotation, initialMiddleRotation, Time.deltaTime * 10);
        ringFinger.localRotation = Quaternion.Lerp(ringFinger.localRotation, initialRingRotation, Time.deltaTime * 10);
        littleFinger.localRotation = Quaternion.Lerp(littleFinger.localRotation, initialLittleRotation, Time.deltaTime * 10);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("HTMLTag") && heldTag == null)
        {
            currentTag = other.GetComponent<HTMLTag>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HTMLTag"))
        {
            currentTag = null;
        }
    }
}
