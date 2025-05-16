using UnityEngine;
using System.Collections;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject player;
    public GameObject enemy;

    BattleInfo playerInfo;
    BattleInfo enemyInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupBattle()
    {
        playerInfo = player.GetComponent<BattleInfo>();
        enemyInfo = enemy.GetComponent<BattleInfo>();

        state = BattleState.PLAYERTURN;
    }

    public void OnFightButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        Debug.Log("Player is fighting");

        StartCoroutine(PlayerFight());
    }

    IEnumerator PlayerFight()
    {
        enemyInfo.TakeDamage(playerInfo.attackDmg);

        yield return new WaitForSeconds(1f);

        // Is enemy dead?

        //Change state

    }
}
