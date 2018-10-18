using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UseSpriteAtlas : MonoBehaviour {
    
    [SerializeField]
    private SpriteAtlas spriteAtlas;

    [SerializeField]
    private Util.SpriteType spriteType;
    
    [SerializeField]
    private Image img;

    private Util.SpriteType curSpriteType;

    // Use this for initialization
    void Start () {
        if (img == null)
            img = this.GetComponent<Image>();
        curSpriteType = Util.SpriteType.none;
    }

    void Update()
    {
        OnChangeSprite();
    }

    private void OnChangeSprite()
    {
        if(img != null && spriteAtlas != null && curSpriteType != spriteType)
        {
            curSpriteType = spriteType;
            string name = spriteType.ToString();
            img.sprite = spriteAtlas.GetSprite(name);
        }
    }

    public void OnSetSprite(Util.SpriteType spriteType)
    {
        if (this.spriteType == spriteType)
            return;
        this.spriteType = spriteType;
        OnChangeSprite();
    }
}
