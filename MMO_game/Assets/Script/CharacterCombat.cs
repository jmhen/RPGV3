using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    private float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;
    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();

    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    // Update is called once per frame
    public void Attack(CharacterStats targetStats)
    {
        if (OnAttack != null)
            OnAttack();

        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator DoDamage (CharacterStats stats, float delay) {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.attack.GetValue());
    }

}
