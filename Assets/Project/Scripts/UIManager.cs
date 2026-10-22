using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Combat");
    }
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
