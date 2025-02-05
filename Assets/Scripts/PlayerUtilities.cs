using UnityEngine;
using System.Collections;

public static class PlayerUtilities
{
    public static void MovePlayerToFinalPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<MonoBehaviour>().StartCoroutine(SmoothMove(player.transform, new Vector3(-0.06f, -2.55f, -7.03f), 1f));
        }
    }

    private static IEnumerator SmoothMove(Transform target, Vector3 finalPosition, float duration)
    {
        Vector3 startPosition = target.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            target.position = Vector3.Lerp(startPosition, finalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.position = finalPosition;

        yield return null;

        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
