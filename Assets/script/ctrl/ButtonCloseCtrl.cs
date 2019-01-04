using Cry.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace testCC.Assets.script {
    public class ButtonCloseCtrl : Singleton<ButtonCloseCtrl>, IPointerClickHandler {
        public Card card;
        protected override void Awake () {
            base.Awake ();
        }

        public void OnPointerClick (PointerEventData eventData) {
            card.close ();
            Utils.hideButton ();
        }
    }
}