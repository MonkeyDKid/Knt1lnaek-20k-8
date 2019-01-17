using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class SearchingItem : MonoBehaviour {


	public Text NamaText;

	public string defense_id1;
	public string defense_id2;
	public string defense_id3;

	public string defense_grade1;
	public string defense_grade2;
	public string defense_grade3;

	public string defense_level1;
	public string defense_level2;
	public string defense_level3;


	public Image defense1_image;
	public Image defense2_image;
	public Image defense3_image;

	public string file1;
	public string file2;
	public string file3;

	public string defense1_attack;
	public string defense1_defense;
	public string defense1_hp;

	public string defense2_attack;
	public string defense2_defense;
	public string defense2_hp;

	public string defense3_attack;
	public string defense3_defense;
	public string defense3_hp;
	public string AGP="50";

	public Searching cc;

	void Start () {
		cc = GameObject.Find ("Searching").GetComponent<Searching>();
	}

	public void OnClick () {

		PlayerPrefs.SetString (Link.LOKASI, "ArenaDuel");
		PlayerPrefs.SetString (Link.ArenaGetPoint, "50");
		PlayerPrefs.SetString (Link.USER_1, NamaText.text.ToString());
		PlayerPrefs.SetString (Link.USER_2, PlayerPrefs.GetString(Link.FULL_NAME));

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, file1);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, file2);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, file3);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ID, defense_id1);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ID, defense_id2);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ID, defense_id3);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, defense_grade1);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, defense_grade2);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, defense_grade3);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, defense_level1);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, defense_level2);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, defense_level3);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, defense1_attack);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, defense2_attack);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, defense3_attack);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, defense1_defense);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, defense2_defense);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, defense3_defense);

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, defense1_hp);
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, defense2_hp);
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, defense3_hp);

		SceneManagerHelper.LoadScene ("PilihCharacterOB");

	}
}
