using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] public static int hpUpgrade=0;
    [SerializeField] public static int atkUpgrade=0;
    [SerializeField] public static int defUpgrade=0;
    [SerializeField] public static int spdUpgrade=0;
    [SerializeField] public static int manaUpgrade=0;
    [SerializeField] public static int manaRegenUpgrade=0;
    private static float upgradeUnit=0.02f;
    private static float demonUpgrade=0.01f;
    // Increase by 2% per upgrade (Unit)
    // Increase by 1% per round (Demon)
    public void AddUpgrade(int type)
    {
        switch (type)
        {
            case 0:
                hpUpgrade++;
                break;
            case 1:
                atkUpgrade++;
                break;
            case 2:
                defUpgrade++;
                break;
            case 3:
                spdUpgrade++;
                break;
            case 4:
                manaUpgrade++;
                break;
            case 5:
                manaRegenUpgrade++;
                break;
            default: 
                break;
        }
        GameManager.Play();
    }
    private static int GetUpgradeType(int upgrade)
    {
        switch (upgrade)
        {
            case 0:
                return hpUpgrade;
            case 1:
                return atkUpgrade;
            case 2:
                return defUpgrade;
            case 3:
                return spdUpgrade;
            case 4:
                return manaUpgrade;
            case 5:
                return manaRegenUpgrade;
            default: 
                return -1;
        }
    }
    public static int GetUpgradesINT(int stat,int type)
    {
        return Mathf.RoundToInt(stat+stat*upgradeUnit*GetUpgradeType(type));
    }
    public static float GetUpgradesFLOAT(float stat,int type)
    {
        return stat+stat*upgradeUnit*GetUpgradeType(type);
    }
    public static int GetUpgradesDemonINT(int stat,int round)
    {
        return Mathf.RoundToInt(stat+stat*(demonUpgrade*(round-1)));
    }
    public static float GetUpgradeDemonFLOAT(float stat,int round)
    {
        return stat+stat*(demonUpgrade*(round-1));
    }
    public static float GetTimerDemon(float timer,int round)
    {
        return timer-timer*demonUpgrade*(round-1);
    }
}
