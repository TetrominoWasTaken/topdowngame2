using UnityEngine;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadDeath()
    {
        SceneManager.LoadScene(2);
    }    
}
