using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PeriodicSinkRise : MonoBehaviour
{
    [Header("Timing (seconds)")]
    [Tooltip("UpStayTime")]
    public float stayDuration = 4f;

    [Tooltip("SinkingDuration")]
    public float sinkDuration = 3f;

    [Tooltip("BottomStayTime")]
    public float bottomPauseTime = 3f;

    [Tooltip("RiseDuration")]
    public float riseDuration = 2f;

    [Header("Motion")]
    [Tooltip("SinkingDepth")]
    public float sinkDepth = 2.5f;

    Vector3 _startLocalPos;

    void Awake()
    {
        // ��¼��ʼλ��
        _startLocalPos = transform.localPosition;
    }

    void OnEnable()
    {
        StartCoroutine(SinkPauseRiseLoop());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SinkPauseRiseLoop()
    {
        while (true)
        {
            // 1������ͣ��
            yield return new WaitForSeconds(stayDuration);

            // 2���³�
            yield return LerpPosition(
                _startLocalPos,
                _startLocalPos + Vector3.down * sinkDepth,
                sinkDuration
            );

            // 3���ײ���ͣ�� bottomPauseTime
            yield return new WaitForSeconds(bottomPauseTime);

            // 4���ϸ�
            yield return LerpPosition(
                _startLocalPos + Vector3.down * sinkDepth,
                _startLocalPos,
                riseDuration
            );
        }
    }

    IEnumerator LerpPosition(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // ȷ�����յ�λ
        transform.localPosition = to;
    }
}
