using Cry.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace testCC.Assets.script {
    public class ButtonTakeCardCtrl : Singleton<ButtonTakeCardCtrl>, IPointerClickHandler {
        public Card card;
        public void takeCard () { }
        protected override void Awake () {
            base.Awake ();
        }

        public void OnPointerClick (PointerEventData eventData) {
            card.take ();
            Utils.hideButton ();
        }
    }
}