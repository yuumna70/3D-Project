/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public Slider hpBar;
    public Transform player;
    NavMeshAgent agent;
    Animator anim;

    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Damaged,
        Dead
    }

    public EnemyState eState = EnemyState.Idle;

    void Damaged(int damage)
    {
        agent.isStopped = true;
        hp -= damage;
        hpBar.value = hp / 100f;

        if(hp <= 0)
        {
            eState = EnemyState.Dead;
            anim.SetTrigger("dead");
            Dead();
        }
        else
        {
            eState = EnemyState.Damaged;
            anim.SetTrigger("damaged");
        }
    }

    void DamagedEnd()
    {
        eState = EnemyState.Idle;
        anim.SetBool("isWalk", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(eState)
        {
            case EnemyState.Idle: Idle();
                break;
            case EnemyState.Walk: Walk();
                break;
            case EnemyState.Attack: Attack();
                break;
            case EnemyState.Damaged:
                break;
            case EnemyState.Dead:
                break;
        }
        // agent.destination = player.position;
    }

    void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) <= 10)
        {
            if (Vector3.Distance(transform.position, player.position) <= 10)
            {
                eState = EnemyState.Walk;
                anim.SetBool("isWalk", true);
                agent.isStopped = false;
            }
        }
    }

    void Walk()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > 10)
        {
            eState = EnemyState.Idle;
            anim.SetBool("isWalk", false);
            agent.isStopped = true;
        }
        else if(distance <= 2.5f)
        {
            eState = EnemyState.Attack;
            attackCoolTime = 1;
        }
        else
        {
            agent.destination = player.position;
        }
    }

    float attackCoolTime;

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) > 2.5f)
        {
            eState = EnemyState.Walk;
            agent.isStopped = false;
        }
        else
        {
            attackCoolTime += Time.deltaTime;
            if(attackCoolTime >= 1)
            {
                anim.SetTrigger("attack");
                attackCoolTime = 0;
            }
        }
    }

    void RealAttack()
    {
        player.SendMessage("Damaged", 10);
    }

    void Dead()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        hpBar.gameObject.SetActive(false);
    }

}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // ���ʹ��� ü��
    public int hp = 100;

    // ���ʹ��� ü�¹�
    public Slider hpBar;

    public Transform player;

    NavMeshAgent agent;
    Animator anim;

    // ���ʹ��� ����
    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Damaged,
        Dead
    }

    // �⺻ ���� �Ҵ�
    public EnemyState eState = EnemyState.Idle;

    // �ѿ� ������ ȣ��
    void Damaged(int damage)
    {
        // �׺�޽� ����
        agent.isStopped = true;

        // ���޹��� ��������ŭ ü�� ����
        hp -= damage;

        // ü�¹ٿ� ü�� ǥ��
        hpBar.value = hp / 100f;

        // ü���� ���ٸ�
        if (hp <= 0)
        {
            // ���� ���·� ��ȯ
            eState = EnemyState.Dead;

            // ���� �ִϸ��̼����� ��ȯ
            anim.SetTrigger("dead");

            // �׾��� �� �� ��
            Dead();
        }

        // ü���� ���Ҵٸ�
        else
        {
            // �ǰ� ���·� ��ȯ
            eState = EnemyState.Damaged;

            // �ǰ� �ִϸ��̼����� ��ȯ
            anim.SetTrigger("damaged");
        }
    }

    // �ǰ� �ִϸ��̼��� ������ ȣ��
    void DamagedEnd()
    {
        // �⺻ ���·� ��ȯ
        eState = EnemyState.Idle;

        // �⺻ �ִϸ��̼����� ��ȯ
        anim.SetBool("isWalk", false);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ���¿� ���� �� �� ������
        switch (eState)
        {
            case EnemyState.Idle: Idle(); break;
            case EnemyState.Walk: Walk(); break;
            case EnemyState.Attack: Attack(); break;
            case EnemyState.Damaged: break;
            case EnemyState.Dead: break;
        }
    }

    // �⺻ ������ �� �� ��
    void Idle()
    {
        // �÷��̾�� �ణ ���������
        if (Vector3.Distance(transform.position, player.position) <= 10)
        {
            // �̵� ���·� ��ȯ
            eState = EnemyState.Walk;

            // �̵� �ִϸ��̼����� ��ȯ
            anim.SetBool("isWalk", true);

            // �׺�޽� �簳
            agent.isStopped = false;
        }
    }

    // �̵� ������ �� �� ��
    void Walk()
    {
        // �÷��̾���� �Ÿ�
        float distance = Vector3.Distance(transform.position, player.position);

        // �÷��̾�� �־�����
        if (distance > 10)
        {
            // �⺻ ���·� ��ȯ
            eState = EnemyState.Idle;

            // �⺻ �ִϸ��̼����� ��ȯ
            anim.SetBool("isWalk", false);

            // �׺�޽� ����
            agent.isStopped = true;
        }

        // �÷��̾�� ���� ���������
        else if (distance <= 2.5f)
        {
            // ���� ���·� ��ȯ
            eState = EnemyState.Attack;

            // ��Ÿ���� 1�� ���� �ٷ� ������ �� �ְ�
            attackCoolTime = 1;
        }

        // �ٸ� ���·� ��ȯ���� ���� ��
        else
        {
            // �÷��̾��� ��ġ�� ��������
            agent.destination = player.position;
        }
    }

    // ���� ��Ÿ��
    float attackCoolTime;

    // ���� ������ �� �� ��
    void Attack()
    {
        // �÷��̾ �������ٸ�
        if (Vector3.Distance(transform.position, player.position) > 2.5f)
        {
            // �̵� ���·� ��ȯ
            eState = EnemyState.Walk;

            // �׺�޽� �簳
            agent.isStopped = false;
        }
        else
        {
            // 1�� ����
            attackCoolTime += Time.deltaTime;

            // ��Ÿ���� ������
            if (attackCoolTime >= 1)
            {
                // ���� �ִϸ��̼����� ��ȯ
                anim.SetTrigger("attack");

                // ��Ÿ�� �ʱ�ȭ
                attackCoolTime = 0;
            }
        }
    }

    // ���� �ִϸ��̼� �߰��� ȣ��
    void RealAttack()
    {
        // �÷��̾��� ü�� 10 ���
        player.SendMessage("Damaged", 10);
    }

    void Dead()
    {
        // �ݶ��̴� ��Ȱ��ȭ
        GetComponent<CapsuleCollider>().enabled = false;

        // �����̴� ��Ȱ��ȭ
        hpBar.gameObject.SetActive(false);
    }
}
