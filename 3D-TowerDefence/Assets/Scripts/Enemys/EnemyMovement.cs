﻿using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    private Transform m_MovePoint = null;
    private int m_WaypointIndex = 0;

    void Start()
    {
        transform.position = WaypointManager.Get.GetPoint(0).position;
        m_MovePoint = WaypointManager.Get.GetPoint(m_WaypointIndex);

        SetDirection();
    }
    private void SetDirection()
    {
        //  내 위치와 상대 위치를 뺸 값을 정규화 시켜준다 (단위벡터)

        Vector3 norm = (m_MovePoint.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(norm);

    }
    public void FixedUpdate()
    {
        if (m_MovePoint == null) return;

        float point = Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * point);

        //  내 위치와 웨이포인터 위치를 기준으로 거리를 계산한다
        //  내가 움직인 값 만큼 거리값이 작거나 같으면 나는 웨이포인터 안으로 들어온 것!
        if(Vector3.Distance(transform.position, m_MovePoint.position) <= point)
        {
            transform.position = m_MovePoint.position;
            m_MovePoint = WaypointManager.Get.GetPoint(++m_WaypointIndex);

            if (m_MovePoint == null)
            {
                Destroy(gameObject);
            }
            else SetDirection();
        }
    }

   
}