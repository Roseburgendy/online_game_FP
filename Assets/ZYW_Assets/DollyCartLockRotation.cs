using UnityEngine;
using Cinemachine;

// ȷ���� CinemachineDollyCart ֮��ִ��
[DefaultExecutionOrder(100)]
[RequireComponent(typeof(CinemachineDollyCart))]
public class DollyCartLockRotation : MonoBehaviour
{
    Quaternion _initialRot;

    void Awake()
    {
        // ��¼�±༭ģʽ�µĳ�ʼ���糯��
        _initialRot = transform.rotation;
    }

    void LateUpdate()
    {
        // ǿ�ư���ת���س�ʼֵ
        transform.rotation = _initialRot;
    }
}
