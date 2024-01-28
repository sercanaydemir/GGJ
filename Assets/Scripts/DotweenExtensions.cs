using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using DG.Tweening;
using TMPro;

public static class DOTweenEx
{

    public static Tweener DOTextInt(this TextMeshProUGUI text, int initialValue, int finalValue, float duration, Func<int, string> convertor)
    {
        return DOTween.To(

             () => initialValue,

             it => text.text = convertor(it),

             finalValue,

             duration
         );
    }

    public static Tweener DOTextInt(this TextMeshProUGUI text, int initialValue, int finalValue, float duration)
    {
        return DOTweenEx.DOTextInt(text, initialValue, finalValue, duration, it => it.ToString());
    }

    public static Tweener DOTextFloat(this TextMeshProUGUI text, float initialValue, float finalValue, float duration, Func<float, string> convertor)
    {
        return DOTween.To(

             () => initialValue,

             it => text.text = convertor(it),

             finalValue,

             duration
         );
    }

    // public static Tweener DOTextFloatFormatter(this TextMeshProUGUI text, float initialValue, float finalValue, float duration)
    // {
    //     return DOTween.To(
    //
    //          () => initialValue,
    //
    //          it => text.text = NumberFormatter.GetFormattedText((double)it),
    //
    //          finalValue,
    //
    //          duration
    //      );
    // }

    public static Tweener DOTextFloat(this TextMeshProUGUI text, float initialValue, float finalValue, float duration,string floating="")
    {
        return DOTweenEx.DOTextFloat(text, initialValue, finalValue, duration, it => it.ToString(floating));
        //return DOTweenEx.DOTextFloat(text, initialValue, finalValue, duration, it => { });
    }

    public static Tweener DOTextLong(this TextMeshProUGUI text, long initialValue, long finalValue, float duration, Func<long, string> convertor)
    {
        return DOTween.To(

             () => initialValue,

             it => text.text = convertor(it),

             finalValue,

             duration

         );
    }

    public static Tweener DOTextLong(this TextMeshProUGUI text, long initialValue, long finalValue, float duration)
    {
        return DOTweenEx.DOTextLong(text, initialValue, finalValue, duration, it => it.ToString());
    }

    public static Tweener DOTextDouble(this TextMeshProUGUI text, double initialValue, double finalValue, float duration, Func<double, string> convertor)
    {
        return DOTween.To(

             () => initialValue,

             it => text.text = convertor(it),

             finalValue,

             duration
         );
    }

    public static Tweener DOTextDouble(this TextMeshProUGUI text, double initialValue, double finalValue, float duration)
    {
        return DOTweenEx.DOTextDouble(text, initialValue, finalValue, duration, it => it.ToString());
    }

    // public static Tweener DOTextDoubleFormatter(this TextMeshProUGUI text, double initialValue, double finalValue, float duration)
    // {
    //     return DOTween.To(
    //
    //          () => initialValue,
    //
    //          it => text.text = CalcUtils.FormatNumber(it),
    //
    //          finalValue,
    //
    //          duration
    //      );
    // }

}