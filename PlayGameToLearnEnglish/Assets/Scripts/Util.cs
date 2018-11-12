using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static string NumberFormat(long number)
    {
        return number.ToString("N0");
    }

    public static string NumberFormatFloat(float number)
    {
        return String.Format("{0:#,##0.##}", number);
    }

    public static string GetSpriteName(ConstantManager.CATEGORY_IDS _categoryId)
    {
        string spriteName = "";
        switch (_categoryId)
        {
            case ConstantManager.CATEGORY_IDS.BASIC:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.UNDERLINE + ConstantManager.BASIC_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.ANIMAL:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.UNDERLINE + ConstantManager.ANIMAL_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.CITY:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.UNDERLINE + ConstantManager.CITY_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.FOOD:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.UNDERLINE + ConstantManager.FOOD_SURFIX;
                break;

            case ConstantManager.CATEGORY_IDS.SPORT:
                spriteName = ConstantManager.CATEGORY_PREFIX + ConstantManager.UNDERLINE + ConstantManager.SPORT_SURFIX;
                break;

            default:
                break;
        }
        return spriteName;
    }
}
