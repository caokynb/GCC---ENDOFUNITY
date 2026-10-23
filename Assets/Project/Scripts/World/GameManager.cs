using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void Play()
    {
        SceneManager.LoadScene("Combat");
    }
    public static void PickUpgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }
    public static void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
