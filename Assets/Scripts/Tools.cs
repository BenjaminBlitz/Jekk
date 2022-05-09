using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public delegate float EasingFuncDelegate(float t);

public static class Tools
{
    public static void SetRandomColor(GameObject gameObject)
    {
        MeshRenderer[] mr = gameObject.GetComponentsInChildren<MeshRenderer>();

        if (mr != null && mr.Length > 0)
        {
            for (int i = 0; i < mr.Length; i++)
            {
                mr[i].material.color = Random.ColorHSV();
            }
        }
    }

    public static void Log(Component component, string msg)
    {
        Debug.Log(Time.frameCount + " " + component.GetType().Name + " " + msg);
    }

    public static IEnumerator MyTranslateCoroutine(Transform transform, Vector3 startPos, Vector3 endPos, float duration,
        EasingFuncDelegate easingFuncDelegate, Action startAction = null, Action endAction = null)
    {
        float elapsedTime = 0;

        if (startAction != null)
        {
            startAction();
        }

        //J'attend un retour
        while (elapsedTime < duration)
        {
            float k = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, easingFuncDelegate(k));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        if (endAction != null)
        {
            endAction();
        }
    }
}
