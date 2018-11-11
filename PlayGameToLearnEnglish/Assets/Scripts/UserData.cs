using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {
    private static UserData instance;

    private long coin;
    private string userName;
    public const string HIGH_SCORE = "NNT_HIGH_SCORE";
    public delegate void CoinChange();
    public static CoinChange OnCoinChange;
    private Dictionary<ConstantManager.CATEGORY_IDS,int> dicCategoriesLevels;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        UpdateCoin(PlayerPrefs.GetInt(HIGH_SCORE));
	}

    public static UserData GetInstance()
    {
        return instance;
    }

    public static GameObject GetGameObject()
    {
        return instance.gameObject;
    }
	
	public void IncreaseCoin(long _coin)
    {
        if (_coin <= 0)
            return;
        this.coin += _coin;
        if (OnCoinChange != null)
            OnCoinChange();
    }

    public void DecreaseCoin(long _coin)
    {
        if (_coin <= 0)
            return;
        this.coin -= coin;
        if (this.coin <= 0)
            this.coin = 0;
        if (OnCoinChange != null)
            OnCoinChange();
    }

    public void UpdateCoin(long _coin)
    {
        if (_coin < 0)
            return;
        this.coin = _coin;
        if (OnCoinChange != null)
            OnCoinChange();
    }

    public long GetCoin()
    {
        return coin;
    }

    public void SetCategoryLevel(ConstantManager.CATEGORY_IDS categoryId, int newLevel)
    {
        if (dicCategoriesLevels == null || dicCategoriesLevels.Count <= 0)
            return;
        int level = -1;
        if(!dicCategoriesLevels.TryGetValue(categoryId, out level))
        {
            Debug.LogError("Not found " + categoryId);
            return;
        }
        dicCategoriesLevels[categoryId] = newLevel;
    }

    public int GetCategoryLevel(ConstantManager.CATEGORY_IDS categoryId)
    {
        if (dicCategoriesLevels == null || dicCategoriesLevels.Count <= 0)
            return 0;
        int level = 0;
        if (!dicCategoriesLevels.TryGetValue(categoryId, out level))
        {
            Debug.LogError("Not found " + categoryId);
            return 0;
        }
        return level;
    }
}
