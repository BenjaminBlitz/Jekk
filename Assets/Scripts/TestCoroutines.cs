using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.Tweening;

public class TestCoroutines : MonoBehaviour
{
    IEnumerator m_MyCoroutineRef;
    int m_Counter = 0;

    private void Start()
    {
        //Application.targetFrameRate = 60;
        //StartCoroutine(Tools.MyTranslateCoroutine(transform, transform.position, transform.position + Random.onUnitSphere * 4, 2, 
        //  EasingFunctions.InOutSine, () => { Tools.SetRandomColor(gameObject); }, () => { transform.localScale *= 2; }));
        //StartCoroutine(m_MyCoroutineRef);

        for (int i = 0; i < 100; i++)
        {
            StartCoroutine(CounterIncrementCoroutine());
        }
    }

    private void Update()
    {
        Tools.Log(this, m_Counter.ToString());
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 40), "START"))
        {
            if (m_MyCoroutineRef != null)
            {
                StopCoroutine(m_MyCoroutineRef);
            }

            m_MyCoroutineRef = MyMultipleTranslationsCoroutine(4);
            StartCoroutine(m_MyCoroutineRef);
        }

        if (GUI.Button(new Rect(120, 10, 100, 40), "STOP") && m_MyCoroutineRef != null)
        {
            StopCoroutine(m_MyCoroutineRef);
            m_MyCoroutineRef = null;
        }

        if (GUI.Button(new Rect(240, 10, 100, 40), "STOP"))
        {
            StopAllCoroutines();
        }
    }

    // Start is called before the first frame update
    IEnumerator MyFirstCoroutine(float waitDuration)
    {
        Tools.Log(this, "START MyFirtCouroutine");

        //J'attend un retour
        while (true)
        {
            Tools.Log(this, "RUNNING MyFirstCouroutine");
            yield return null;
        }

        Tools.Log(this, "END MyFirtCouroutine");
    }

    /**
    IEnumerator MyTranslateCoroutine(Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsedTime = 0;

        //J'attend un retour
        while (elapsedTime < duration)
        {
            float k = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, k);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }*/

    IEnumerator MyMultipleTranslationsCoroutine(int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return StartCoroutine(Tools.MyTranslateCoroutine(
                    transform,
                    transform.position,
                    transform.position + Random.onUnitSphere * 4,
                    2,
                    EasingFunctions.InOutSine,
                    () => { Tools.SetRandomColor(gameObject); },
                    () => { transform.localScale *= 2; })
                );
        }
    }

    IEnumerator CounterIncrementCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(Random.value);
            m_Counter++;
        }
        yield break;
    }
}
