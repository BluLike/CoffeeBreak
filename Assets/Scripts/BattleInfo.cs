using UnityEngine;
using UnityEngine.UI;

public class BattleInfo : MonoBehaviour 
{
    public int maxHP;
    public int currentHP;

    public GameObject spriteGO;
    private Image currentSprite;

    public Sprite highHPSprite;
    public Sprite midHPSprite;
    public Sprite lowHPSprite;

    public int attackDmg;

    public Sprite damageSprite;

    private void Start()
    {
        currentSprite = spriteGO.gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP > (maxHP * 2 / 3)) currentSprite.sprite = highHPSprite;
        else if (currentHP >= (maxHP * 1 / 3)) currentSprite.sprite = midHPSprite;
        else currentSprite.sprite = lowHPSprite;

        if (currentHP <= 0)
        {
            return true;
        }
        else return false;

       
    }
}
