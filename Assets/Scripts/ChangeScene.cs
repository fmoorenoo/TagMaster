using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeScene(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}