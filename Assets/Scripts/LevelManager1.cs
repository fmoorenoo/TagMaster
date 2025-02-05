using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public List<LevelData> levels = new List<LevelData>();
    private int currentLevelIndex = 0;
    private List<GameObject> tags = new List<GameObject>();
    public float distance = 5f;
    public float speed = 2f;
    public float minY = -4.59f;

    private TextMeshProUGUI levelText;
    private GameObject exitButton; 


    void Start()
    {
        LevelUtilities.FindTags(tags);
        levelText = LevelUtilities.FindLevelText();
        exitButton = GameObject.FindWithTag("ExitButton");
        UpdateLevelText();
        LoadLevel(currentLevelIndex);
    }

    private void UpdateLevelText()
    {
        if (levelText != null && currentLevelIndex < 6)
        {
            levelText.text = "Nivel " + (currentLevelIndex + 1);
        }
        else if (currentLevelIndex >= 6)
        {
            levelText.text = "¡Has ganado!";
            MoveExitButton();
        }
    }

    private void MoveExitButton()
    {
        if (exitButton != null)
        {
            exitButton.transform.localPosition = new Vector3(0, -205, 0);
        }
        else
        {
            Debug.LogWarning("ExitButton no encontrado en la escena.");
        }
    }

    private void LoadLevel(int levelIndex)
    {
        if (levelIndex >= levels.Count)
        {
            Debug.Log("¡Todos los niveles completados!");
            PlayerUtilities.MovePlayerToFinalPosition();
            return;
        }

        LevelData levelData = levels[levelIndex];
        LevelUtilities.AssignTagsText(tags, levelData);
        UpdateLevelText();
    }

    public bool CheckOrder()
    {
        if (currentLevelIndex >= levels.Count)
        {
            Debug.Log("No hay más niveles disponibles.");
            return false;
        }

        if (!LevelUtilities.IsOrderCorrect(tags, levels[currentLevelIndex]))
        {
            Debug.Log("Orden incorrecto.");
            return false;
        }

        OnLevelComplete();
        return true;
    }

    private void OnLevelComplete()
    {
        GameObject floor = GameObject.FindWithTag("Floor");
        if (floor != null)
        {
            StartCoroutine(LevelUtilities.MoveFloorAndTagsDown(floor, tags, distance, minY, speed));
        }

        currentLevelIndex++;
        UpdateLevelText();
        Invoke(nameof(LoadNextLevel), 0.5f);
    }

    private void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex);
    }
}
