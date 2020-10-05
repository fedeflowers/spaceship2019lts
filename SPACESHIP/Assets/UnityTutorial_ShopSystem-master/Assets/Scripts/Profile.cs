using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Diagnostics;


public class Profile : MonoBehaviour
{
	#region Singlton:Profile

	public static Profile Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion

	public class Avatar
	{
		public Sprite Image;
		public int prefabToInstantiateIndex;
	}

	public List<Avatar> AvatarsList;

	[SerializeField] GameObject AvatarUITemplate;
	[SerializeField] Transform AvatarsScrollView;

	GameObject g;
	int newSelectedIndex, previousSelectedIndex;

	[SerializeField] Color ActiveAvatarColor;
	[SerializeField] Color DefaultAvatarColor;

	[SerializeField] Image CurrentAvatar;

	void Start ()
	{

		GetAvailableAvatars();
		Game.Instance.UpdateAllCoinsUIText();
	}

	void GetAvailableAvatars ()
	{
	

		for (int i = 0; i < Shop.Instance.ShopItemsList.Count; i++) {
			if (Shop.Instance.ShopItemsList [i].IsPurchased) {
				//add all purchased avatars to AvatarsList
				AddAvatar (Shop.Instance.ShopItemsList [i].Image, Shop.Instance.ShopItemsList[i].prefabToInstantiateIndex);
			}
			//new code
			if (PlayerPrefs.HasKey(Shop.Instance.ShopItemsList[i].name) == true)
			{
				AddAvatar(Shop.Instance.ShopItemsList[PlayerPrefs.GetInt(Shop.Instance.ShopItemsList[i].name)].Image, Shop.Instance.ShopItemsList[PlayerPrefs.GetInt(Shop.Instance.ShopItemsList[i].name)].prefabToInstantiateIndex);
			}
		}

		if (PlayerPrefs.HasKey("SelectedAvatar") == true)
		{
			newSelectedIndex = PlayerPrefs.GetInt("SelectedAvatar");
			UnityEngine.Debug.Log("nello start l'index è: " + newSelectedIndex);
		}

		SelectAvatar (newSelectedIndex);
	}

	public void AddAvatar(Sprite img, int index)
	{
		if (AvatarsList == null)
			AvatarsList = new List<Avatar>();

		Avatar av = new Avatar()
		{
			Image = img,
			prefabToInstantiateIndex = index,
		};

	
		//add av to AvatarsList
		AvatarsList.Add (av);

		//add avatar in the UI scroll view
		g = Instantiate (AvatarUITemplate, AvatarsScrollView);
		g.transform.GetChild (0).GetComponent <Image> ().sprite = av.Image;


		//add click event
		g.transform.GetComponent <Button> ().AddEventListener (AvatarsList.Count - 1, OnAvatarClick);
	}

	void OnAvatarClick (int AvatarIndex)
	{
		SelectAvatar (AvatarIndex);
	}

	void SelectAvatar (int AvatarIndex)
	{
		
		previousSelectedIndex = newSelectedIndex;
		newSelectedIndex = AvatarIndex;
		AvatarsScrollView.GetChild (previousSelectedIndex).GetComponent <Image> ().color = DefaultAvatarColor;
		AvatarsScrollView.GetChild (newSelectedIndex).GetComponent <Image> ().color = ActiveAvatarColor;

		//Change Avatar
		CurrentAvatar.sprite = AvatarsList [newSelectedIndex].Image;


		PlayerPrefs.SetInt("SelectedAvatar", newSelectedIndex); // louso per tener conto di qual è l'avatar selezionato nel profile
		PlayerPrefs.SetInt("prefabToInstantiateIndex", AvatarsList[newSelectedIndex].prefabToInstantiateIndex);
		//Debug.Log("index: " +AvatarsList[newSelectedIndex].prefabToInstantiateIndex);
		UnityEngine.Debug.Log("index in profile: " + newSelectedIndex);


	}
}
