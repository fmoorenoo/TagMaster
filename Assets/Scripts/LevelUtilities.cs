using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public static class LevelUtilities
{
    public static void FindTags(List<GameObject> tags)
    {
        tags.Clear();
        Transform tagsParent = GameObject.Find("Tags").transform;
        foreach (Transform child in tagsParent)
        {
            if (child.CompareTag("HTMLTag"))
            {
                tags.Add(child.gameObject);
            }
        }
    }

    public static TextMeshProUGUI FindLevelText()
    {
        GameObject levelTextObj = GameObject.FindWithTag("LevelText");
        return levelTextObj != null ? levelTextObj.GetComponent<TextMeshProUGUI>() : null;
    }

    public static void AssignTagsText(List<GameObject> tags, LevelData levelData)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (i < levelData.texts.Length)
            {
                TextMeshPro textMeshPro = tags[i].GetComponentInChildren<TextMeshPro>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = levelData.texts[i];
                }
            }
        }
    }

    public static bool IsOrderCorrect(List<GameObject> tags, LevelData levelData)
    {
        tags.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        for (int i = 0; i < tags.Count; i++)
        {
            TextMeshPro textMesh = tags[i].GetComponentInChildren<TextMeshPro>();
            if (textMesh == null || textMesh.text != levelData.texts[levelData.correctOrder[i]])
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerator MoveFloorAndTagsDown(GameObject floor, List<GameObject> tags, float distance, float minY, float speed)
    {
        Vector3 targetPositionFloor = floor.transform.position + new Vector3(0, -distance, 0);
        if (targetPositionFloor.y < minY) targetPositionFloor.y = minY;

        Vector3[] targetPositionsTags = new Vector3[tags.Count];
        for (int i = 0; i < tags.Count; i++)
        {
            targetPositionsTags[i] = tags[i].transform.position + new Vector3(0, -distance, 0);
            if (targetPositionsTags[i].y < minY) targetPositionsTags[i].y = minY;
        }

        while (Vector3.Distance(floor.transform.position, targetPositionFloor) > 0.01f)
        {
            if (floor.transform.position.y <= minY) yield break;

            floor.transform.position = Vector3.MoveTowards(floor.transform.position, targetPositionFloor, speed * Time.deltaTime);
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].transform.position = Vector3.MoveTowards(tags[i].transform.position, targetPositionsTags[i], speed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
