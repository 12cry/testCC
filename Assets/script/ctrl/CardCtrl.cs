using UnityEngine;

namespace testCC.Assets.script {
    public class CardCtrl : MonoBehaviour {
        public Card card;
        void Start () {
            card.cardCtrl = this;
        }
        void OnMouseDown () {
            card.see ();
        }
    }
}