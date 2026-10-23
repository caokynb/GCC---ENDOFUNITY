using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    private bool sped;
    void Awake()
    {
        sped=false;
    }
    public void Speed()
    {
        if(!sped) Time.timeScale=speedMultiplier;
        else Time.timeScale=1f;
        sped=!sped;
    }
}
