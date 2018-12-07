using Cry.Common;
using UnityEngine;

namespace testCC.Assets.script {
    public class ButtonTakeCardCtrl : Singleton<ButtonTakeCardCtrl> {
        public Card card;

        public void takeCard(){
            card.take();
        }
        protected override void Awake () {
            base.Awake ();
        }
    }
}