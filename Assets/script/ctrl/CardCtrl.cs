﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace testCC.Assets.script {
    public class CardCtrl : MonoBehaviour, IPointerClickHandler {

        public Card card;
        public void OnPointerClick (PointerEventData eventData) {
            card.see ();
        }
    }
}