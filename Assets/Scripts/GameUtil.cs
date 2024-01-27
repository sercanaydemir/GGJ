using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtil
{
    //[0,1]
    public static float Normalize(float val, float minVal, float maxVal)
    {
        maxVal -= minVal;
        val -= minVal;

        float exp = maxVal / 100f;
        maxVal /= exp;
        val /= exp;

        // [0,1]
        val = val / 100f;
        return val;
    }

    public static float Normalize(float val, float minVal, float maxVal, float nMin, float nMax)
    {
        if (val <= minVal) return nMin;
        if (val >= maxVal) return nMax;

        maxVal -= minVal;
        val -= minVal;

        float exp = maxVal / 100f;
        maxVal /= exp;
        val /= exp;

        // [0,1]
        val = val / 100f;

        float diff = nMax - nMin;
        maxVal *= diff;
        val *= diff;

        return val + nMin;
    }


    public static bool GetBool(int i)
    {
        return (i == 0) ? false : true;
    }

    public static float EaseInCubic(float x)
    {
        return x * x * x;
    }

    public static string DigitCurrency(int value)
    {
        string msg = "";
        msg = value.ToString();

        //   Debug.LogError("VALUE : " + value);
        if (value >= 1000)
        {
            float kVal = ((float)(value / 1000.0F));
            msg = kVal.ToString("F1") + "K";
            // Debug.LogError("Float val : " + kVal + " msg : " + msg);
        }
        else if (value >= 1000000)
        {
            float mVal = ((float)(value / 1000000.0F));
            msg = mVal.ToString("F1") + "M";
        }


        return msg;
    }

    public static GameObject Spawn(GameObject spawnObjPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedObj = GameObject.Instantiate(spawnObjPrefab, position, rotation);
        spawnedObj.SetActive(true);

        return spawnedObj;
    }

    public static string GetPossix(int order)
    {
        string possix = "TH";

        switch (order)
        {
            case 1:
                possix = "ST";
                break;
            case 2:
                possix = "ND";
                break;
            case 3:
                possix = "RD";
                break;
        }

        return possix;
    }
}



