using System;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static int round=1;
    [SerializeField] private DemonTower demon;
    [SerializeField] private PlayerTower player;
    [SerializeField] private TMP_Text tmn;
    void Start()
    {
        Render();
    }
    void Render()
    {
        tmn.text=$"Round\n{round}";
    }
    void OnEnable()
    {
        demon.roundCheck+=NextRound;
        player.roundCheck+=StartOver;
    } 
    void OnDisable()
    {
        demon.roundCheck-=NextRound;
        player.roundCheck-=StartOver;
    }
    void NextRound()
    {
        round++;
        GameManager.PickUpgrade();
    }
    void StartOver()
    {
        round=1;
        GameManager.Return();
    }
}
