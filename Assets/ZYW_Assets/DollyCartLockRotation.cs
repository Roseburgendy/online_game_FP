using UnityEngine;
using Cinemachine;

// 确保在 CinemachineDollyCart 之后执行
[DefaultExecutionOrder(100)]
[RequireComponent(typeof(CinemachineDollyCart))]
public class DollyCartLockRotation : MonoBehaviour
{
    Quaternion _initialRot;

    void Awake()
    {
        // 记录下编辑模式下的初始世界朝向
        _initialRot = transform.rotation;
    }

    void LateUpdate()
    {
        // 强制把旋转锁回初始值
        transform.rotation = _initialRot;
    }
}
