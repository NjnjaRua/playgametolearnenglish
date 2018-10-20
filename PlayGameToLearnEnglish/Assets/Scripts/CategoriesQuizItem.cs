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

    public void OnUpdateData(Util.SpriteType spriteType, string categoriesName)
    {
        UseSpriteAtlas userSpriteAtlas = icon.GetComponent<UseSpriteAtlas>();
        if(userSpriteAtlas != null)
        {
            userSpriteAtlas.OnSetSprite(spriteType);
        }
        name.text = categoriesName;
        curLevel = Random.Range(0, 100);
        maxLevel = 100;
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
