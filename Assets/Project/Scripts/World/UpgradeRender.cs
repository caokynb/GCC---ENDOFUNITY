using TMPro;
using UnityEngine;

public class UpgradeRender : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text atkText;
    [SerializeField] private TMP_Text defText;
    [SerializeField] private TMP_Text spdText;
    [SerializeField] private TMP_Text mpText;
    [SerializeField] private TMP_Text mprText;
    void Start()
    {
        hpText.text = $"{UpgradeManager.hpUpgrade}";
        atkText.text = $"{UpgradeManager.atkUpgrade}";
        defText.text = $"{UpgradeManager.defUpgrade}";
        spdText.text = $"{UpgradeManager.spdUpgrade}";
        mpText.text = $"{UpgradeManager.manaUpgrade}";
        mprText.text = $"{UpgradeManager.manaRegenUpgrade}";
    }
}
