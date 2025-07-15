using UnityEngine;
using Cinemachine;
[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(CinemachineDollyCart))]
public class DollyCartInitNearestEarly : MonoBehaviour
{
    public CinemachinePathBase path;
    public int sampleCount = 100;
    CinemachineDollyCart cart;
    Vector3 originalPosition;

    void Awake()
    {
        cart = GetComponent<CinemachineDollyCart>();
        // �� DollyCart �� transform ��֮ǰ���ȱ��泡����ڵ�ԭʼλ��
        originalPosition = transform.position;
    }

    void Start()
    {
        float bestU = 0f, bestDist = float.MaxValue;
        for (int i = 0; i <= sampleCount; i++)
        {
            float u = i / (float)sampleCount;
            Vector3 pt = path.EvaluatePositionAtUnit(
                u, CinemachinePathBase.PositionUnits.PathUnits);
            float d = Vector3.Distance(originalPosition, pt);
            if (d < bestDist)
            {
                bestDist = d;
                bestU = u;
            }
        }
        
        cart.m_Position = bestU;
    }
}
