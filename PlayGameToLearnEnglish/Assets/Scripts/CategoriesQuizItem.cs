﻿using System.Collections;
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

	// Use this for initialization
	void Start () {

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
        progress.value = curLevel;s
    }
}