using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scoring : MonoBehaviour
{
    public EventTrigger.TriggerEvent _scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Square square = collision.gameObject.GetComponent<Square>();

        if (square != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this._scoreTrigger.Invoke(eventData);
        }
    }
}
