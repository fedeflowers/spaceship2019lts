using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class Shop : MonoBehaviour
{
	#region Singlton:Shop

	public static Shop Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion

	//private List<int> listPurchased;
	private int[] listArray;
	[System.Serializable] public class ShopItem
	{
		public int damage;
		//public int lifes // da implementare
		public int speed;
		public string name;
		public Sprite Image;
		public int Price;
		public bool IsPurchased = false;
		public int prefabToInstantiateIndex;
	}

	public List<ShopItem> ShopItemsList;
	[SerializeField] Animator NoCoinsAnim;
 

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	Button buyBtn;

	void Start ()
	{

		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (0).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
			g.transform.GetChild (1).GetChild (0).GetComponent <Text> ().text = ShopItemsList [i].Price.ToString ();
			g.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].speed.ToString();
			g.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].damage.ToString();

			buyBtn = g.transform.GetChild (2).GetComponent <Button> ();
			UnityEngine.Debug.Log("index: "+i);
			//mio code per vedere quali sono shoppati
			if (PlayerPrefs.HasKey(ShopItemsList[i].name) == true)
			{
				ShopItemsList[PlayerPrefs.GetInt(ShopItemsList[i].name)].IsPurchased = true;
				//UnityEngine.Debug.Log("sono entrato");
				//UnityEngine.Debug.Log(PlayerPrefs.GetInt(ShopItemsList[i].name));

			}
			//fine code
			if (ShopItemsList [i].IsPurchased) {
				DisableBuyButton ();
			}
			
			buyBtn.AddEventListener (i, OnShopItemBtnClicked);
		}

		//mio code
	}

	void OnShopItemBtnClicked (int itemIndex)
	{
		if (Game.Instance.HasEnoughCoins (ShopItemsList [itemIndex].Price)) {
			Game.Instance.UseCoins (ShopItemsList [itemIndex].Price);
			//purchase Item
			ShopItemsList [itemIndex].IsPurchased = true;
			PlayerPrefs.SetInt(ShopItemsList[itemIndex].name, itemIndex); // questo index è comprato


			//disable the button
			buyBtn = ShopScrollView.GetChild (itemIndex).GetChild (2).GetComponent <Button> ();
			DisableBuyButton ();
			//change UI text: coins
			Game.Instance.UpdateAllCoinsUIText ();

			//add avatar
			Profile.Instance.AddAvatar(ShopItemsList[itemIndex].Image, ShopItemsList[itemIndex].prefabToInstantiateIndex);
		} else {
			NoCoinsAnim.SetTrigger ("NoCoins");
			UnityEngine.Debug.Log ("You don't have enough coins!!");
		}
	}

	void DisableBuyButton ()
	{
		buyBtn.interactable = false;
		buyBtn.transform.GetChild (0).GetComponent <Text> ().text = "PURCHASED";
	}
	/*---------------------Open & Close shop--------------------------*/
	public void OpenShop ()
	{
		ShopPanel.SetActive (true);
	}

	public void CloseShop ()
	{
		ShopPanel.SetActive (false);
	}
	int boolToInt(bool val)
	{
		if (val)
			return 1;
		else
			return 0;
	}

	bool intToBool(int val)
	{
		if (val != 0)
			return true;
		else
			return false;
	}
}
