using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class ExtensionMethods
{
    [Conditional("DEBUG_ON")]
    public static void Log(this MonoBehaviour mono, object message)
    {
        Debug.Log(message);
    }

    public static Vector2 ConvertToVector2(this Vector3 origin)
    {
        return new Vector2(origin.x, origin.y);
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
}