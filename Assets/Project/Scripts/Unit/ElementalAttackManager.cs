using System;
using UnityEngine;

public class ElementalAttackManager : MonoBehaviour
{
    [SerializeField] private FireDemon fireDemon;
    public Action<int,int> startAttack;

    void OnEnable()
    {
        startAttack += TakeDamage;
    }

    void OnDisable()
    {
        startAttack -= TakeDamage;
    }

    void TakeDamage(int element,int receivedAttack)
    {
        fireDemon.hp-=receivedAttack;
    }
    
}

