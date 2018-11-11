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

	// Use this for initialization
	void Start () {
        if (puManager == null)
            puManager = PopupManager.getInstance();
    }

    public void OnUpdateData(ConstantManager.CATEGORY_IDS categoryId)
    {
        string spriteName = "";
        switch(categoryId)
        {
            case ConstantManager.CATEGORY_IDS.BASIC:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.BASIC_SURFIX;    
                break;

            case ConstantManager.CATEGORY_IDS.ANIMAL:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.ANIMAL_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.CITY:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.CITY_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.FOOD:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.FOOD_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.SPORT:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.SPORT_SURFIX;
                break;

            default:
                break;
        }
        UseSpriteAtlas userSpriteAtlas = icon.GetComponent<UseSpriteAtlas>();
        if(userSpriteAtlas != null)
        {
            userSpriteAtlas.OnSetSprite(spriteName);
        }
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
        int _quizId = 0;
        puManager.HideAllPopup();
        puManager.OnShowPopupQuizMain(_quizId);
    }
}
