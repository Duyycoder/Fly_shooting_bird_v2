using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    public BlockType blockType;
    public eSoundName sound;
    private float curHP;
    private float maxHP;
    private SpriteRenderer sr;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        SetShotSFX();
        maxHP = GameData.Instance.blockData.listBlockSprites[(int) blockType].spriteInfos.maxHP;
        curHP = maxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprites[(int) blockType].spriteInfos.listSprite[2];
    }

    public void TakeDamage(float amount)
    {
        curHP -= amount;
        AudioManager.Instance.Shot(sound);
        SetSprite();
    }

    public void SetSprite()
    {
        if (curHP / maxHP <= 1f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int) blockType].spriteInfos.listSprite[0];
        }
        else if (curHP / maxHP <= 2f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int) blockType].spriteInfos.listSprite[1];
        }

        if (curHP <= 0f)
        {
            Disable();
            GameMenu.Instance.UpdateScore((int) blockType + 1);
        }
    }

    public void SetShotSFX()
    {
        if (blockType == BlockType.Wood)
        {
            sound = eSoundName.Wood_Sound;
        }
        if (blockType == BlockType.Stone)
        {
            sound = eSoundName.Stone_Sound;
        }
        if (blockType == BlockType.Metal)
        {
            sound = eSoundName.Metal_Sound;
        }
    }
}