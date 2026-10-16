using UnityEngine;

public class SummonManager : MonoBehaviour
{
    [SerializeField] private PlayerTower player;
    public void Summon1()
    {
        player.Summon(1,75);
    }
    public void Summon2()
    {
        player.Summon(2,100);
    }
    public void Summon3()
    {
        player.Summon(3,50);
    }
}
