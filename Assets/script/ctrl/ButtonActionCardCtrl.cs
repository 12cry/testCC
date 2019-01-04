using Cry.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace testCC.Assets.script {
    public class ButtonActionCardCtrl : Singleton<ButtonActionCardCtrl>, IPointerClickHandler {
        public Card card;

        public void actionCatd () { }
        protected override void Awake () {
            base.Awake ();
        }
        public void OnPointerClick (PointerEventData eventData) {
            card.action ();
        }
    }
}