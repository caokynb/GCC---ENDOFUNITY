using System.Collections;
using TMPro;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    public static IEnumerator Flash(SpriteRenderer sprite)
    {   
        Color org = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = org;
        yield return null;
    }
    public static void RenderHp(TextMeshPro text,int hp)
    {
        text.text=$"{Mathf.Clamp(hp,0,int.MaxValue):F0}";
    }
}
