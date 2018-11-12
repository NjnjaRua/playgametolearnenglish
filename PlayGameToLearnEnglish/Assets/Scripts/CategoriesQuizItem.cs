using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesQuizItem : MonoBehaviour {
    [SerializeField]
    private Text name;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text level;

    [SerializeField]
    private Slider progress;

    int curLevel;
    int maxLevel;

    PopupManager puManager;
    ConstantManager.CATEGORY_IDS categoryId;

    // Use this for initialization
    void Start () {
        if (puManager == null)
            puManager = PopupManager.getInstance();
    }

    public void OnUpdateData(ConstantManager.CATEGORY_IDS _categoryId)
    {
        this.categoryId = _categoryId;
        UseSpriteAtlas userSpriteAtlas = icon.GetComponent<UseSpriteAtlas>();
        if(userSpriteAtlas != null)
            userSpriteAtlas.OnSetSprite(Util.GetSpriteName(_categoryId));
        name.text = categoryId.ToString();
        curLevel = UserData.GetInstance().GetCategoryLevel(categoryId);
        maxLevel = ConstantManager.GetInstance().GetMaxLevelOfCategory(categoryId);
        level.text = "Level: " + curLevel + "/" + maxLevel;
        OnUpdateProcess();
    }
	
    public void OnUpdateProcess()
    {
        if (progress == null)
            return;
        progress.maxValue = maxLevel;
        progress.value = curLevel;
    }

    public void OnOpenCategory()
    {
        Debug.Log("OnOpenCategory");
        if (puManager == null)
            return;
        puManager.HideAllPopup();
        puManager.OnShowPopupQuizMain(categoryId);
    }
}
