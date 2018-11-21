using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DG.Tweening;
using Newtonsoft.Json;
using testCC.Assets.script;
using UnityEngine;
using UnityEngine.UI;

namespace testCC.Assets.script {
	public class GCtrl : MonoBehaviour {

		public CardCtrl cardCtrlPrefab;
		public Queue<CardCtrl> remainderCards = new Queue<CardCtrl> ();
		public Queue<CardCtrl> currentCards = new Queue<CardCtrl> ();
		Tweener t1;
		int cardWidth = 100;
		int currentCardLimitNum = 3;
		bool over = false;
		void Start () {
			init ();
		}

		void init () {
			print ("---init");

			string json = File.ReadAllText ("./Assets/Resources/cardBuild.json", Encoding.UTF8);
			List<CardBuild> cardBuildList = JsonConvert.DeserializeObject<List<CardBuild>> (json);

			List<Card> cardList = new List<Card> ();
			for (int i = 0; i < cardBuildList.Count; i++) {
				cardList.Insert (Random.Range (i, i + 1), cardBuildList[i]);
			}
			cardList.ForEach (card => {
				CardCtrl newCtrdCtrl = Instantiate<CardCtrl> (cardCtrlPrefab, cardCtrlPrefab.transform.parent);
				newCtrdCtrl.card = card;
				card.cardCtrl = newCtrdCtrl;
				remainderCards.Enqueue (newCtrdCtrl);
			});
			// run ();
		}

		CardCtrl getANewCard () {
			if (remainderCards.Count == 0) {
				return null;
			}
			CardCtrl cardCtrl = remainderCards.Dequeue ();
			Card card = cardCtrl.card;
			Text[] texts = cardCtrl.GetComponentsInChildren<Text> ();
			Dictionary<string, Text> textDic = texts.ToDictionary (key => key.name, text => text);
			textDic["cardName"].text = card.cardName;
			if (card is CardBuild) {
				textDic["costScience"].text = ((CardBuild) card).costScience.ToString ();
			}
			return cardCtrl;
		}
		public void computeCurrentCards () {
			Queue<CardCtrl> newCurrentCards = new Queue<CardCtrl> ();

			CardCtrl cardCtrl;
			int removeCardNum = 1;
			int newCardNum = currentCardLimitNum;
			for (int i = 0; i < currentCardLimitNum; i++) {
				if (currentCards.Count == 0) {
					break;
				}
				cardCtrl = currentCards.Dequeue ();
				if (removeCardNum > 0) {
					removeCardNum--;
					Object.Destroy (cardCtrl.gameObject);
				} else {
					newCurrentCards.Enqueue (cardCtrl);
					newCardNum--;
				}
			}
			for (int i = 0; i < newCardNum; i++) {
				cardCtrl = getANewCard ();
				if (cardCtrl == null) {
					over = true;
					break;
				}
				newCurrentCards.Enqueue (cardCtrl);
			}

			currentCards = newCurrentCards;
		}
		public void showCurrentCards () {
			CardCtrl cardCtrl;
			int count = currentCards.Count;
			int i=0;
			while (currentCards.Count > 0) {
				cardCtrl = currentCards.Dequeue ();
				cardCtrl.transform.DOMove (new Vector3 (cardWidth / 2 + i++ * cardWidth, Screen.height - cardWidth / 2, 0), 2);
			}
		}

		public void run () {
			print ("---run");
			// print (Screen.width);
			// print (Screen.height);

			if (over) {
				print ("---over");
				return;
			}
			computeCurrentCards ();
			showCurrentCards ();

		}
		public void reset () {
			print ("---reset");
			// t1.Rewind (false);

			while (remainderCards.Count != 0) {
				print ("---remainderCards");
				CardCtrl cardCtrl = remainderCards.Dequeue ();
				Object.Destroy (cardCtrl.gameObject);
			}

			while (currentCards.Count != 0) {
				print ("---currentCards");
				CardCtrl cardCtrl = currentCards.Dequeue ();
				Object.Destroy (cardCtrl.gameObject);
			}
			over = false;
			init ();
		}

		public void test1 () {
			print ("---test1");
			init ();
		}

	}
}