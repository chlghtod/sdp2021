using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class MonsterRange : MonoBehaviour
{
    //몬스터의 범위 스크립트
    //몬스터끼리도 인식할거 같음
    //수정 필요

    protected Character character;
    protected GameObject cha_Hit_Pivot;

    private void Awake()
    {
        character = transform.parent.transform.parent.GetComponent<Character>();
        //cha_Hit_Pivot = character.gameObject.transform.Find("Hit_Pivot").GetComponent<GameObject>();
        //Debug.Log("ddd");
    }

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Clock")
        {

        }
    }

}
