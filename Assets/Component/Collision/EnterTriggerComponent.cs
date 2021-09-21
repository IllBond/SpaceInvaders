using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] string _tag;
        [SerializeField] LayerMask _layer = ~0;
        [SerializeField] EnterEvent _action;


        public void OnTriggerEnter2D(Collider2D collider)
        {

            if (!collider.gameObject.IsInLayer(_layer)) return;

            if (!string.IsNullOrEmpty(_tag) && !collider.gameObject.CompareTag(_tag)) return;

            _action?.Invoke(collider.gameObject);

        }
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {

    }

