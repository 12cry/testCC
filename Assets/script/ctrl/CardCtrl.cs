using UnityEngine;

namespace testCC.Assets.script {
    public class CardCtrl : MonoBehaviour {
        public Card card;
        void Start () {
        }
        void OnMouseDown () {
            print("---onMouseDown");
            card.see ();
        }
    }
}