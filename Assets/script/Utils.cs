using System.Collections.Generic;
using testCC.Assets.script;
using testCC.Assets.script.model;

namespace testCC.Assets.script {
    public class Utils {
        public static int cardMoveSpeed = 1;
        public static int cardWidth = 100;
        public static Resource resource;
        public static Card currentCard;
        public static List<CardCtrl> takedCardCtrls = new List<CardCtrl> ();

        public static void hideButton () {
            ButtonCloseCtrl.instance.gameObject.SetActive (false);
            ButtonTakeCardCtrl.instance.gameObject.SetActive (false);
            ButtonActionCardCtrl.instance.gameObject.SetActive (false);
        }
    }
}