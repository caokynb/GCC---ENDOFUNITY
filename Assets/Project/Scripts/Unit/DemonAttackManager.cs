using System;
using UnityEngine;

public class DemonAttackManager : MonoBehaviour
{
    [SerializeField] private FireElemental fireUnit;
    public Action<int,int> startAttack;

    void OnEnable()
    {
        startAttack += TakeDamage;
    }

    void OnDisable()
    {
        startAttack -= TakeDamage;
    }

    public void TakeDamage(int element,int receivedAttack)
    {
        fireUnit.hp-=receivedAttack;
    }
    
}

