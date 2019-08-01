using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class ExtensionMethods
{
    [Conditional("DEBUG_ON")]
    public static void Log(this MonoBehaviour mono, object message)
    {
        MonoBehaviour.print(message);
    }

    public static Vector2 ConvertToVector2(this Vector3 origin)
    {
        return new Vector2(origin.x, origin.y);
    }

    public static T TryParse<T>(this MonoBehaviour mono, object input)
    {
        try
        {
            T result = (T)input;
            return result;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public static void SetCallback(this MonoBehaviour mono, float duration, System.Action callback)
    {
        if (callback != null)
        {
            mono.StartCoroutine(Boo(duration, callback));
        }
    }

    static IEnumerator Boo(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback();
    }

    public static void SetLoopCoroutine(this MonoBehaviour mono, float tick, Action tickCallback, Action endCallback, Func<Boolean> condition)
    {
        mono.StartCoroutine(Foo(tick, tickCallback, endCallback, condition));
    }

    static IEnumerator Foo(float tick, Action tickCallback, Action endCallback, Func<Boolean> condition)
    {
        while (condition())
        {
            tickCallback();
            yield return new WaitForSeconds(tick);
        }
        endCallback();
    }
}