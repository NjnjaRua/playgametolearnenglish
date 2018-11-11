using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UseSpriteAtlas : MonoBehaviour {
    
    [SerializeField]
    private SpriteAtlas spriteAtlas;
    
    [SerializeField]
    private Image img;

    private string spriteName;

    private string curSpriteName;

    // Use this for initialization
    void Start () {
        if (img == null)
            img = this.GetComponent<Image>();
        //curSpriteType = Util.SpriteType.none;
        curSpriteName = "";
    }

    void Update()
    {
        OnChangeSprite();
    }

    private void OnChangeSprite()
    {
        if(img != null && spriteAtlas != null && curSpriteName != spriteName)
        {
            curSpriteName = spriteName;
            img.sprite = spriteAtlas.GetSprite(curSpriteName);
        }
    }

    /*public void OnSetSprite(Util.SpriteType spriteType)
    {
        if (this.spriteType == spriteType)
            return;
        this.spriteType = spriteType;
        OnChangeSprite();
    }*/

    public void OnSetSprite(string name)
    {
        if (string.IsNullOrEmpty(name) || spriteName == name)
            return;
        this.spriteName = name;
        OnChangeSprite();
    }
}
