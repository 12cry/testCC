using Cry.Common;
using UnityEngine.UI;

namespace testCC.Assets.script.ctrl {
    public class UICtrl : Singleton<UICtrl> {
        protected override void Awake () {
            base.Awake ();
        }

        public Button bTakeCard;
        public Button bActionCard;
        public Button bCloseCard;

        public void takeCard () {
            Utils.currentCard.take ();
        }
        public void actionCard () {
            Utils.currentCard.action ();
        }
        public void closeCard () {
            Utils.currentCard.closeView ();
        }
        public void hideBTakeCard () {
            bTakeCard.gameObject.SetActive (false);
        }
        public void hideBActionCard () {
            bActionCard.gameObject.SetActive (false);
        }
        public void hideBCloseCard () {
            bCloseCard.gameObject.SetActive (false);
        }
        public void showBTakeCard () {
            bTakeCard.gameObject.SetActive (true);
        }
        public void showBActionCard () {
            bActionCard.gameObject.SetActive (true);
        }
        public void showBCloseCard () {
            bCloseCard.gameObject.SetActive (true);
        }
        public void hideSeeButton () {
            this.hideBTakeCard ();
            this.hideBActionCard ();
            this.hideBCloseCard ();
        }
    }
}