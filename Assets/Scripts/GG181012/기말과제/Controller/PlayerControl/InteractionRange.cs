using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{
    //캐릭터의 상호작용 범위에 들어온 상호작용 오브젝트를 캐치한다.
    PCharacter character;

    private void Start()
    {
        character = transform.parent.GetComponent<PCharacter>();
    }

    //void ActivateInteractionObject()
    //{
    //    character.interactableObject.Activate(character);
    //    //if (character.isInteractionObjectActivate)
    //    //{
    //    //    character.isInteractionObjectActivate = false;
    //    //    character.interactableObject.Activate();
    //    //}
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {


    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
