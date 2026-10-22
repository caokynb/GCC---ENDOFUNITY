using UnityEngine;

public class DemonTower : TowerBase
{
    [SerializeField] private TowerSO demonData;
    [SerializeField] private GameObject fireDemon;
    [SerializeField] private GameObject waterDemon;
    [SerializeField] private GameObject groundDemon;
    private float timer1;
    private float timer2;
    private float timer3;

    void Awake()
    {
        GetStat(demonData);
        timer1 = 10f;
        timer2 = 20f;
        timer3 = 30f;
    }

    void FixedUpdate()
    {
        RegenMana();
        RenderHp();

        TrySpawn(ref timer1, fireDemon, 11f);
        TrySpawn(ref timer2, waterDemon, 17f);
        TrySpawn(ref timer3, groundDemon, 23f);
    }

    private void TrySpawn(ref float timer, GameObject demon, float cooldown)
    {
        if (timer>0f) timer-=Time.fixedDeltaTime;
        if (timer>0f || demon==null) return;
        UnitBase demonPrefab = demon.GetComponent<UnitBase>();
        if (demonPrefab != null && SummonManager.Instance.Summon(this, demonPrefab))
            timer = cooldown;
    }
}
