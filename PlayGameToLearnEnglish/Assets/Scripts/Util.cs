using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public enum SpriteType
    {
        none = 0,
        bt_back = 1,
        bt_diamond = 2,
        bt_highscore = 3,
        bt_rate = 4,
        bt_sound_off = 5,
        bt_sound_on = 6,
        button_fb = 7,
        Bg_button = 8,
        banner = 9,
        BottomBanner = 10,
        img_basic_quiz = 11,
        img_animal_quiz = 12,
        img_city_quiz = 13,
        img_food_quiz = 14,
        img_sport_quiz = 15,
        bt_hint = 16,
        bt_skip = 17,
        bt_remove = 18,
        bt_score = 19,
        q0_1 = 20,
        q0_2 = 21,
        q0_3 = 22,
        q0_4 = 23
    }

    public static string NumberFormat(long number)
    {
        return number.ToString("N0");
    }

    public static string NumberFormatFloat(float number)
    {
        return String.Format("{0:#,##0.##}", number);
    }
}
