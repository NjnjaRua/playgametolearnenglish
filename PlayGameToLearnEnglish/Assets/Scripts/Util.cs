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
}
