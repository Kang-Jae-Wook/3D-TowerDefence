using System.Collections;
using UnityEngine;

class TurretStatus : MonoBehaviour
{
    [Header("Attribute", order = 0)]
    [SerializeField] private Transform m_FireTransform;
    [SerializeField] private Transform m_NeckTransform;
    public float Damage;
    public float Range;
    public float FireRate;

    [Header("Shop Attribute", order = 1)]
    public int Price;

    private EnemyMovement m_EnemyTarget = null;
    private float m_ReloadTime = 0;

    private void Update()
    {
        AimingTarget(); //  사정거리 내 적을 찾는 함수

        //  만약 적이 사정거리 내 발견되었다면
        if(m_EnemyTarget != null)
        {
            Vector3 norm = (m_EnemyTarget.transform.position - transform.position).normalized;

            //  타워의 목 방향을 적 방향으로 돌린다. y축 까지 돌릴경우 위아래로 흔들리므로 y축은 뺀다
            m_NeckTransform.rotation = Quaternion.LookRotation(new Vector3(norm.x, 0, norm.z));
        }
    }


    protected virtual void AimingTarget()
    {
        if(m_EnemyTarget != null)
        {
            //  사정거리 내 적이 있다면 종료. 계속 바라본다
            if (Vector2.Distance(m_EnemyTarget.transform.position, transform.position) <= Range)
                return;
            else m_EnemyTarget = null;

        }

        if (m_EnemyTarget == null)
            m_EnemyTarget = FindObjectOfType<EnemyMovement>();

        m_EnemyTarget = FindObjectOfType<EnemyMovement>();
    }

    //  이 객체가 선택되면 이 함수가 실행된다
    private void OnDrawGizmosSelected()
    {
        //  Gizmo? Guide
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
