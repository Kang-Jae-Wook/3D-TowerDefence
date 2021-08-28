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
        AimingTarget(); //  �����Ÿ� �� ���� ã�� �Լ�

        //  ���� ���� �����Ÿ� �� �߰ߵǾ��ٸ�
        if(m_EnemyTarget != null)
        {
            Vector3 norm = (m_EnemyTarget.transform.position - transform.position).normalized;

            //  Ÿ���� �� ������ �� �������� ������. y�� ���� ������� ���Ʒ��� ��鸮�Ƿ� y���� ����
            m_NeckTransform.rotation = Quaternion.LookRotation(new Vector3(norm.x, 0, norm.z));
        }
    }


    protected virtual void AimingTarget()
    {
        if(m_EnemyTarget != null)
        {
            //  �����Ÿ� �� ���� �ִٸ� ����. ��� �ٶ󺻴�
            if (Vector2.Distance(m_EnemyTarget.transform.position, transform.position) <= Range)
                return;
            else m_EnemyTarget = null;

        }

        if (m_EnemyTarget == null)
            m_EnemyTarget = FindObjectOfType<EnemyMovement>();

        m_EnemyTarget = FindObjectOfType<EnemyMovement>();
    }

    //  �� ��ü�� ���õǸ� �� �Լ��� ����ȴ�
    private void OnDrawGizmosSelected()
    {
        //  Gizmo? Guide
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
