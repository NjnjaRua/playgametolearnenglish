using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantManager : MonoBehaviour {
    private static ConstantManager instance;

    public const int MAX_CATEGORIES_QUIZ = 5;
    public const int MAX_IMAGES_TIP = 4;

    private const int CATEGORY_BASIC_MAX_LEVEL = 10;
    private const int CATEGORY_ANIMAL_MAX_LEVEL = 10;
    private const int CATEGORY_CITY_MAX_LEVEL = 10;
    private const int CATEGORY_FOOD_MAX_LEVEL = 10;
    private const int CATEGORY_SPORT_MAX_LEVEL = 10;

    public const string BASIC_SURFIX = "basic";
    public const string ANIMAL_SURFIX = "animal";
    public const string CITY_SURFIX = "city";
    public const string FOOD_SURFIX = "food";
    public const string SPORT_SURFIX = "sport";

    public const string UNDERLINE = "_";

    public const string CATEGORY_PREFIX = "category";

    public enum CATEGORY_IDS
    {
        BASIC = 0,
        ANIMAL = 1,
        CITY = 2,
        FOOD = 3,
        SPORT = 4
    }
    public CATEGORY_IDS categoryId;

    private void Awake()
    {
        instance = this;
    }

    public static ConstantManager GetInstance()
    {
        return instance;
    }

    public static GameObject GetGameObject()
    {
        if (instance == null)
            return null;
        return instance.gameObject;
    }

    public int GetMaxLevelOfCategory(CATEGORY_IDS categoryId)
    {
        int maxLevel = 0;
        switch(categoryId)
        {
            case CATEGORY_IDS.BASIC:
                maxLevel = CATEGORY_BASIC_MAX_LEVEL;
                break;

            case CATEGORY_IDS.ANIMAL:
                maxLevel = CATEGORY_ANIMAL_MAX_LEVEL;
                break;

            case CATEGORY_IDS.CITY:
                maxLevel = CATEGORY_CITY_MAX_LEVEL;
                break;

            case CATEGORY_IDS.FOOD:
                maxLevel = CATEGORY_FOOD_MAX_LEVEL;
                break;

            case CATEGORY_IDS.SPORT:
                maxLevel = CATEGORY_SPORT_MAX_LEVEL;
                break;

            default:
                break;
        }
        return maxLevel;
    }
}
