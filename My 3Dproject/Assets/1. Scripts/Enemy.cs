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
    // 에너미의 체력
    public int hp = 100;

    // 에너미의 체력바
    public Slider hpBar;

    public Transform player;

    NavMeshAgent agent;
    Animator anim;

    // 에너미의 상태
    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Damaged,
        Dead
    }

    // 기본 상태 할당
    public EnemyState eState = EnemyState.Idle;

    // 총에 맞으면 호출
    void Damaged(int damage)
    {
        // 네비메시 멈춤
        agent.isStopped = true;

        // 전달받은 데미지만큼 체력 소진
        hp -= damage;

        // 체력바에 체력 표시
        hpBar.value = hp / 100f;

        // 체력이 없다면
        if (hp <= 0)
        {
            // 죽음 상태로 전환
            eState = EnemyState.Dead;

            // 죽음 애니메이션으로 전환
            anim.SetTrigger("dead");

            // 죽었을 때 할 일
            Dead();
        }

        // 체력이 남았다면
        else
        {
            // 피격 상태로 전환
            eState = EnemyState.Damaged;

            // 피격 애니메이션으로 전환
            anim.SetTrigger("damaged");
        }
    }

    // 피격 애니메이션이 끝나면 호출
    void DamagedEnd()
    {
        // 기본 상태로 전환
        eState = EnemyState.Idle;

        // 기본 애니메이션으로 전환
        anim.SetBool("isWalk", false);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 상태에 따라 할 일 나누기
        switch (eState)
        {
            case EnemyState.Idle: Idle(); break;
            case EnemyState.Walk: Walk(); break;
            case EnemyState.Attack: Attack(); break;
            case EnemyState.Damaged: break;
            case EnemyState.Dead: break;
        }
    }

    // 기본 상태일 때 할 일
    void Idle()
    {
        // 플레이어와 약간 가까워지면
        if (Vector3.Distance(transform.position, player.position) <= 10)
        {
            // 이동 상태로 전환
            eState = EnemyState.Walk;

            // 이동 애니메이션으로 전환
            anim.SetBool("isWalk", true);

            // 네비메시 재개
            agent.isStopped = false;
        }
    }

    // 이동 상태일 때 할 일
    void Walk()
    {
        // 플레이어와의 거리
        float distance = Vector3.Distance(transform.position, player.position);

        // 플레이어와 멀어지면
        if (distance > 10)
        {
            // 기본 상태로 전환
            eState = EnemyState.Idle;

            // 기본 애니메이션으로 전환
            anim.SetBool("isWalk", false);

            // 네비메시 멈춤
            agent.isStopped = true;
        }

        // 플레이어와 많이 가까워지면
        else if (distance <= 2.5f)
        {
            // 공격 상태로 전환
            eState = EnemyState.Attack;

            // 쿨타임을 1로 만들어서 바로 공격할 수 있게
            attackCoolTime = 1;
        }

        // 다른 상태로 전환하지 않을 때
        else
        {
            // 플레이어의 위치를 목적지로
            agent.destination = player.position;
        }
    }

    // 공격 쿨타임
    float attackCoolTime;

    // 공격 상태일 때 할 일
    void Attack()
    {
        // 플레이어가 도망갔다면
        if (Vector3.Distance(transform.position, player.position) > 2.5f)
        {
            // 이동 상태로 전환
            eState = EnemyState.Walk;

            // 네비메시 재개
            agent.isStopped = false;
        }
        else
        {
            // 1초 세기
            attackCoolTime += Time.deltaTime;

            // 쿨타임이 지나면
            if (attackCoolTime >= 1)
            {
                // 공격 애니메이션으로 전환
                anim.SetTrigger("attack");

                // 쿨타임 초기화
                attackCoolTime = 0;
            }
        }
    }

    // 어택 애니메이션 중간에 호출
    void RealAttack()
    {
        // 플레이어의 체력 10 깎기
        player.SendMessage("Damaged", 10);
    }

    void Dead()
    {
        // 콜라이더 비활성화
        GetComponent<CapsuleCollider>().enabled = false;

        // 슬라이더 비활성화
        hpBar.gameObject.SetActive(false);
    }
}
