using UnityEngine;
using System.Collections;

public class Link : MonoBehaviour {


	public static string url = "http://139.59.100.192/PH/";
    public static string urlAvatar = "http://139.59.100.192/PH/storage/Image/";

    public static string HANTU_PLAYER_ID = "HANTU_PLAYER_ID";

	//SCENE STRING
	public static string Arena = "Arena";
	public static string ArenaGetPoint = "ArenaGetPoint";
	public static string End = "End";
	public static string Equipment = "Equipment";
	public static string Fusion = "Fusion";
	public static string Game = "Game";
	public static string Home = "Home";
	public static string Jousting = "Jousting";
	public static string Map = "Map";
	public static string PilihCharacter = "PilihCharacter";
	public static string PilihCharacterOB = "PilihCharacterOB";
	public static string Practice = "Practice";
	public static string Register = "Register";
	public static string Searching = "Searching";
	public static string SelectCharacter = "SelectCharacter";
	public static string Storage = "Storage";
	public static string Summon = "Summon";
    public static string Stage = "Stage";
    public static string StageChoose = "StageChoose";
    public static string Replay = "Replay";
    public static string IBURU = "IBURU";
    public static string IGOLD = "IGOLD";
    public static string IENERGY = "IENERGY";
    public static string SUMMONQUESTSTATS = "SUQS";
    public static string SOLOQUESTSTATS = "SOQS";
    public static string CATCHQUESTSTATS = "CAQS";
    //DATA CHARACTER SELECTION
    public static string CHAR_1_FILE 		= "char_1_file";
	public static string CHAR_1_ATTACK 		= "char_1_attack";
	public static string CHAR_1_DEFENSE 	= "char_1_defense";
	public static string CHAR_1_HP 			= "char_1_hp";
	public static string CHAR_1_ID			= "char_1_id";
	public static string CHAR_1_GRADE		= "char_1_grade";
	public static string CHAR_1_LEVEL		= "char_1_level";
	public static string CHAR_1_TARGETNL		= "char_1_target";
	public static string CHAR_1_MONSTEREXP		= "char_1_monster";
	public static string CHAR_1_ELEMENT		= "char_1_element";
	public static string CHAR_1_MODE		= "char_1_mode";

	public static string CHAR_2_FILE 		= "char_2_file";
	public static string CHAR_2_ATTACK 		= "char_2_attack";
	public static string CHAR_2_DEFENSE 	= "char_2_defense";
	public static string CHAR_2_HP 			= "char_2_hp";
	public static string CHAR_2_ID			= "char_2_id";
	public static string CHAR_2_GRADE		= "char_2_grade";
	public static string CHAR_2_LEVEL		= "char_2_level";
	public static string CHAR_2_TARGETNL		= "char_2_target";
	public static string CHAR_2_MONSTEREXP		= "char_2_monster";
	public static string CHAR_2_ELEMENT		= "char_2_element";
	public static string CHAR_2_MODE		= "char_2_mode";

	public static string CHAR_3_FILE 		= "char_3_file";
	public static string CHAR_3_ATTACK 		= "char_3_attack";
	public static string CHAR_3_DEFENSE 	= "char_3_defense";
	public static string CHAR_3_HP 			= "char_3_hp";
	public static string CHAR_3_ID			= "char_3_id";
	public static string CHAR_3_GRADE		= "char_3_grade";
	public static string CHAR_3_LEVEL		= "char_3_level";
	public static string CHAR_3_TARGETNL		= "char_3_target";
	public static string CHAR_3_MONSTEREXP		= "char_3_monster";
	public static string CHAR_3_ELEMENT		= "char_3_element";
	public static string CHAR_3_MODE		= "char_3_mode";

	//DATA CHARACTER BATTLE POSITION
	public static string POS_1_CHAR_1_FILE 		= "pos_1_char_1_file";
	public static string POS_1_CHAR_1_ATTACK 	= "pos_1_char_1_attack";
	public static string POS_1_CHAR_1_DEFENSE 	= "pos_1_char_1_defense";
	public static string POS_1_CHAR_1_HP 		= "pos_1_char_1_hp";
	public static string POS_1_CHAR_1_ID		= "pos_1_char_1_id";
	public static string POS_1_CHAR_1_GRADE		= "pos_1_char_1_grade";
	public static string POS_1_CHAR_1_LEVEL		= "pos_1_char_1_level";
	public static string POS_1_CHAR_1_ELEMENT	= "pos_1_char_1_element";
	public static string POS_1_CHAR_1_MODE	= "pos_1_char_1_mode";

	public static string POS_1_CHAR_2_FILE 		= "pos_1_char_2_file";
	public static string POS_1_CHAR_2_ATTACK 	= "pos_1_char_2_attack";
	public static string POS_1_CHAR_2_DEFENSE 	= "pos_1_char_2_defense";
	public static string POS_1_CHAR_2_HP 		= "pos_1_char_2_hp";
	public static string POS_1_CHAR_2_ID		= "pos_1_char_2_id";
	public static string POS_1_CHAR_2_GRADE		= "pos_1_char_2_grade";
	public static string POS_1_CHAR_2_LEVEL		= "pos_1_char_2_level";
	public static string POS_1_CHAR_2_ELEMENT	= "pos_1_char_2_element";
	public static string POS_1_CHAR_2_MODE	= "pos_1_char_2_mode";

	public static string POS_1_CHAR_3_FILE 		= "pos_1_char_3_file";
	public static string POS_1_CHAR_3_ATTACK 	= "pos_1_char_3_attack";
	public static string POS_1_CHAR_3_DEFENSE 	= "pos_1_char_3_defense";
	public static string POS_1_CHAR_3_HP 		= "pos_1_char_3_hp";
	public static string POS_1_CHAR_3_ID		= "pos_1_char_3_id";
	public static string POS_1_CHAR_3_GRADE		= "pos_1_char_3_grade";
	public static string POS_1_CHAR_3_LEVEL		= "pos_1_char_3_level";
	public static string POS_1_CHAR_3_ELEMENT	= "pos_1_char_3_element";
	public static string POS_1_CHAR_3_MODE	= "pos_1_char_3_mode";

	public static string POS_2_CHAR_1_FILE 		= "pos_2_char_1_file";
	public static string POS_2_CHAR_1_ATTACK 	= "pos_2_char_1_attack";
	public static string POS_2_CHAR_1_DEFENSE 	= "pos_2_char_1_defense";
	public static string POS_2_CHAR_1_HP 		= "pos_2_char_1_hp";
	public static string POS_2_CHAR_1_ID		= "pos_2_char_1_id";
	public static string POS_2_CHAR_1_GRADE		= "pos_2_char_1_grade";
	public static string POS_2_CHAR_1_LEVEL		= "pos_2_char_1_level";
	public static string POS_2_CHAR_1_ELEMENT	= "pos_2_char_1_element";
	public static string POS_2_CHAR_1_MODE	= "pos_2_char_1_mode";

	public static string POS_2_CHAR_2_FILE 		= "pos_2_char_2_file";
	public static string POS_2_CHAR_2_ATTACK 	= "pos_2_char_2_attack";
	public static string POS_2_CHAR_2_DEFENSE 	= "pos_2_char_2_defense";
	public static string POS_2_CHAR_2_HP 		= "pos_2_char_2_hp";
	public static string POS_2_CHAR_2_ID		= "pos_2_char_2_id";
	public static string POS_2_CHAR_2_GRADE		= "pos_2_char_2_grade";
	public static string POS_2_CHAR_2_LEVEL		= "pos_2_char_2_level";
	public static string POS_2_CHAR_2_ELEMENT	= "pos_2_char_2_element";
	public static string POS_2_CHAR_2_MODE	= "pos_2_char_2_mode";

	public static string POS_2_CHAR_3_FILE 		= "pos_2_char_3_file";
	public static string POS_2_CHAR_3_ATTACK 	= "pos_2_char_3_attack";
	public static string POS_2_CHAR_3_DEFENSE 	= "pos_2_char_3_defense";
	public static string POS_2_CHAR_3_HP 		= "pos_2_char_3_hp";
	public static string POS_2_CHAR_3_ID		= "pos_2_char_3_id";
	public static string POS_2_CHAR_3_GRADE		= "pos_2_char_3_grade";
	public static string POS_2_CHAR_3_LEVEL		= "pos_2_char_3_level";
	public static string POS_2_CHAR_3_ELEMENT	= "pos_2_char_3_element";
	public static string POS_2_CHAR_3_MODE	= "pos_2_char_3_mode";
	public static string StageData	= "MapStageData";
	public static string MapData	= "MapData";
	public static string DEVICE_ID 	= "device_id";
	public static string USER_NAME	= "user_name";
	public static string FULL_NAME 	= "full_name";
	public static string EMAIL		= "email";
	public static string PASSWORD	= "password";


	public static string USER_1 	= "User1";
	public static string USER_2		= "User2";

	public static string AP = "ap";
	public static string AR = "ar";

	public static string ENERGY = "ENERGY";
	public static string GOLD = "GOLD";
	public static string SOUL_STONE = "SOUL_STONE";

	public static string COMMON 		= "COMMON";
	public static string RARE	 		= "RARE";
	public static string LEGENDARY	 	= "LEGENDARY";

	public static string NewsCount 		= "NCount";
	public static string EventCount 		= "ECount";
	public static string COMMONGem 		= "COMMONGem";
	public static string RAREGem	 		= "RAREGem";
	public static string LEGENDARYGem	 	= "LEGENDARYGem";
	public static string LOGIN_BY = "login_by";
	public static string STATUS_BATTLE = "status_battle";
	public static string STATUS_LOGIN = "status_login";

	public static string LAT = "LAT";
	public static string LOT = "LOT";

	public static string COUNT_PLAYER_FOUND = "COUNT_PLAYER_FOUND";
	public static string COUNT_INVITING_FOUND = "COUNT_INVITING_FOUND";

	public static string FCM_ID = "FCM_ID";
	public static string ID = "ID";
	public static string ID_PEOPLE = "ID_PEOPLE";

	public static string FOR_CONVERTING = "FOR_CONVERTING";
	public static string FOR_CONVERTING_2 = "FOR_CONVERTING_2";

	public static string LOKASI = "LOKASI";
	public static string JENIS = "JENIS";

	public static string SEARCH_BATTLE = "SEARCH_BATTLE";
	public static string INVITE_CLICK = "INVITE_CLICK";

	public static string HANTU_DEFENSE_FILE = "HANTU_DEFENSE_FILE";
	public static string HANTU_DEFENSE_NAME = "HANTU_DEFENSE_NAME";
	//Berburu

	public static string BURU_FILE 		= "Hunt_file";
	public static string BURU_ATTACK 		= "Hunt_attack";
	public static string BURU_DEFENSE 	= "Hunt_defense";
	public static string BURU_HP 			= "Hunt_Hp";
	public static string BURU_MODE			= "Hunt_Mode";
	

	void Start () {
		
	}

}
