using Cry.Common;
using UnityEngine.UI;

namespace testCC.Assets.script.ctrl {
    public class UICtrl : Singleton<UICtrl> {
        protected override void Awake () {
            base.Awake ();
        }

        public Button bActionCard;

        public void takeCard () {
            Utils.currentCard.take ();
        }
        public void actionCard () {
            Utils.currentCard.action ();
        }
        public void closeCard () {
            Utils.currentCard.close ();
        }
        public void hideBActionCard () {
            bActionCard.gameObject.SetActive (false);
        }
    }
}