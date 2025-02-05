using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 10f;
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;

    public float minX = -5.2f;
    public float maxX = 5.8f;
    public TMP_Text timerText; 

    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && CanMove())
        {
            CheckInput();
        }
    }

    bool CanMove()
    {
        if (timerText != null)
        {
            float timerValue;
            if (float.TryParse(timerText.text, out timerValue))
            {
                return timerValue > 0.0f;
            }
        }
        return true; 
    }

    void CheckInput()
    {
        if (transform.position.z < -2f)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
    }

    void MovePlayer(Vector3 direction)
    {
        isMoving = true;
        StartCoroutine(Move(direction));
    }

    IEnumerator Move(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + direction * moveDistance;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        
        float distance = Vector3.Distance(startPosition, targetPosition);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed / distance;
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);
            float height = Mathf.Sin(t * Mathf.PI) * jumpHeight;
            currentPosition.y = startPosition.y + height;
            transform.position = currentPosition;

            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
