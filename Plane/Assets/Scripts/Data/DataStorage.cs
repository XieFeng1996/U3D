using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

	/*
     *  数据储存区，将此脚本挂载在第一个界面的摄像机上即可。
    */
	//库ID
    private static int libraryId = 1;
                  //飞机数据
	//飞机1ID
    private static int airplaneId1 = 1;
    //飞机1名字
    private static string airplaneName1 = "芝麻";
	//飞机1生命
    private static int airplaneLife1 = 50;

	//飞机2ID
    private static int airplaneId2 = 0;
	//飞机2名字
	private static string airplaneName2 = "麻瓜";
	//飞机2生命
    private static int airplaneLife2 = 100;

	//飞机3ID
    private static int airplaneId3 = 0;
	//飞机3名字
	private static string airplaneName3 = "西瓜";
	//飞机3生命
    private static int airplaneLife3 = 200;
                 //子弹数据
    //子弹1ID
    private static int bulletId1 = 1;
    //是否拥有子弹1
    private int bulletHave1 = 1;
    //子弹1伤害
    private static int bulletHurt1 = 5;

	//子弹2ID
    private static int bulletId2 = 2;
	//是否拥有子弹2
	private int bulletHave2 = 0;
	//子弹2伤害
    private static int bulletHurt2 = 10;

	//子弹3ID
    private static int bulletId3 = 3;
	//是否拥有子弹3
	private int bulletHave3 = 0;
	//子弹3伤害
    private static int bulletHurt3 = 20;
                  //关卡数据
    //关卡1
    private static int levelId1 = 1;
    //关卡1名字
    private static string levelIdName1 = "仙女星系";
    //关卡1难度ID(初级难度)
    private static int levelDiffcultyId1_1 = 0;
    //星星数
    private int starsNum1_2 = 0;
	//关卡1难度ID(中级难度)
	private static int levelDiffcultyId1_3 = 0;
	//星星数
	private int starsNum1_4 = 0;
	//关卡1难度ID(高级难度)
	private static int levelDiffcultyId1_5 = 0;
	//星星数
	private int starsNum1_6 = 0;


	//关卡2
    private static int levelId2 = 0;
	//关卡2名字
	private static string levelIdName2 = "猫眼星系";
	//关卡2难度ID(初级难度)
	private static int levelDiffcultyId2_1 = 0;
	//星星数
	private int starsNum2_2 = 0;
	//关卡2难度ID(中级难度)
	private static int levelDiffcultyId2_3 = 0;
	//星星数
	private int starsNum2_4 = 0;
	//关卡2难度ID(高级难度)
	private static int levelDiffcultyId2_5 = 0;
	//星星数
	private int starsNum2_6 = 0;

	//关卡3
	private int levelId3 = 0;
	//关卡3名字
	private static string levelIdName3 = "银河星系";
	//关卡3难度ID(初级难度)
	private static int levelDiffcultyId3_1 = 0;
	//星星数
	private int starsNum3_2 = 0;
	//关卡3难度ID(中级难度)
	private static int levelDiffcultyId3_3 = 0;
	//星星数
	private int starsNum3_4 = 0;
	//关卡3难度ID(高级难度)
	private static int levelDiffcultyId3_5 = 0;
	//星星数
	private int starsNum3_6 = 0;

                             //金币
    //玩家金币数
    private int goldNum = 500;

                            //道具数据
    //道具1
    private static int propsId1 = 1001;
    //道具1名字
    private static string propsName1 = "时之钟";
    //道具1购入价格
    private static int propsBuy1 = 1000;
    //玩家拥有数
    private int playerNum1 = 0;

	//道具2
    private static int propsId2 = 1002;
	//道具2名字
	private static string propsName2 = "防御罩";
	//道具2购入价格
	private static int propsBuy2 = 1500;
	//玩家拥有数
	private int playerNum2 = 0;


	//道具3
    private static int propsId3 = 1003;
	//道具3名字
	private static string propsName3 = "防御罩1";
	//道具3购入价格
	private static int propsBuy3 = 2000;
	//玩家拥有数
	private int playerNum3 = 0;

	//道具4
    private static int propsId4 = 1004;
	//道具4名字
	private static string propsName4 = "时之钟1";
	//道具4购入价格
	private static int propsBuy4 = 3000;
	//玩家拥有数
	private int playerNum4 = 0;

                         //怪物数据
    //初级怪
    private static int mobsId1 = 101;
    //小怪名
    private static string mobsName1 = "小怪";
    //小怪生命（初级难度）
    private static int mobsLife1_101 = 1;
    //小怪伤害（初级难度）
    private static int mobsHurt1_101 = 10;
	//小怪生命（中级难度）
	private static int mobsLife2_101 = 20;
	//小怪伤害（中级难度）
	private static int mobsHurt2_101 = 20;
	//小怪生命（高级难度）
	private static int mobsLife3_101 = 40;
	//小怪伤害（高级难度）
	private static int mobsHurt3_101 = 20;
    //击杀获得金币
    private static int killGold1 = 20;

	//中级怪
	private static int mobsId4 = 104;
	//小怪名
    private static string mobsName4 = "中怪";
	//小怪生命（初级难度）
	private static int mobsLife1_104 = 60;
	//小怪伤害（初级难度）
	private static int mobsHurt1_104 = 20;
	//小怪生命（中级难度）
	private static int mobsLife2_104 = 80;
	//小怪伤害（中级难度）
	private static int mobsHurt2_104 = 40;
	//小怪生命（高级难度）
	private static int mobsLife3_104 = 140;
	//小怪伤害（高级难度）
	private static int mobsHurt3_104 = 50;
	//击杀获得金币
	private static int killGold2 = 50;

	//高级怪
	private static int mobsId7 = 107;
	//小怪名
    private static string mobsName7 = "高级怪";
	//小怪生命（初级难度）
	private static int mobsLife1_107 = 80;
	//小怪伤害（初级难度）
	private static int mobsHurt1_107 = 40;
	//小怪生命（中级难度）
	private static int mobsLife2_107 = 140;
	//小怪伤害（中级难度）
	private static int mobsHurt2_107 = 60;
	//小怪生命（高级难度）
	private static int mobsLife3_107 = 200;
	//小怪伤害（高级难度）
	private static int mobsHurt3_107 = 80;
	//击杀获得金币
	private static int killGold3 = 80;

    //BOSS1
    private static int mobsId10 = 110;
    //BOSS1名字
    private static string mobsName10 = "爱衣";
    //BOSS1生命(初级)
    private static int mobsLife1_110 = 200;
	//BOSS1伤害(初级)
	private static int mobsHurt1_110 = 40;
	//BOSS1生命(中级)
	private static int mobsLife2_110 = 400;
	//BOSS1伤害(中级)
	private static int mobsHurt2_110 = 80;
	//BOSS1生命(高级)
	private static int mobsLife3_110 = 800;
	//BOSS1伤害(高级)
	private static int mobsHurt3_110 = 100;
	//击杀获得金币
	private static int killGold4 = 300;

	//BOSS2
	private static int mobsId11 = 111;
	//BOSS2名字
	private static string mobsName11 = "佐仓";
	//BOSS2生命(初级)
	private static int mobsLife1_111 = 600;
	//BOSS2伤害(初级)
	private static int mobsHurt1_111 = 40;
	//BOSS2生命(中级)
	private static int mobsLife2_111 = 1200;
	//BOSS2伤害(中级)
	private static int mobsHurt2_111 = 80;
	//BOSS2生命(高级)
	private static int mobsLife3_111 = 2000;
	//BOSS2伤害(高级)
	private static int mobsHurt3_111 = 100;
	//击杀获得金币
	private static int killGold5 = 500;

	//BOSS3
	private static int mobsId12 = 112;
	//BOSS3名字
	private static string mobsName12 = "松岗";
	//BOSS3生命(初级)
	private static int mobsLife1_112 = 1200;
	//BOSS3伤害(初级)
	private static int mobsHurt1_112 = 80;
	//BOSS3生命(中级)
	private static int mobsLife2_112 = 2600;
	//BOSS3伤害(中级)
	private static int mobsHurt2_112 = 200;
	//BOSS3生命(高级)
	private static int mobsLife3_112 = 4000;
	//BOSS3伤害(高级)
	private static int mobsHurt3_112 = 200;
	//击杀获得金币
	private static int killGold6 = 1000;
	// Use this for initialization
	void Start () {
		//保存数据到playerPrefes中
        PlayerPrefs.SetInt("libraryId",libraryId);   //ID
        PlayerPrefs.SetInt("airplaneId1",airplaneId1);   //飞机1ID
        PlayerPrefs.SetString("airplaneName1",airplaneName1);//飞机1名字
        PlayerPrefs.SetInt("airplaneLife1",airplaneLife1);  //飞机1生命
        PlayerPrefs.SetInt("airplaneId2",airplaneId2);   //飞机2ID
        PlayerPrefs.SetString("airplaneName2",airplaneName2);//飞机2名字
        PlayerPrefs.SetInt("airplaneLife2",airplaneLife2);  //飞机2生命
        PlayerPrefs.SetInt("airplaneId3",airplaneId3);   //飞机3ID
        PlayerPrefs.SetString("airplaneName3",airplaneName3);//飞机3名字
        PlayerPrefs.SetInt("airplaneLife3",airplaneLife3);  //飞机3生命

        PlayerPrefs.SetInt("bulletId1",bulletId1);    //子弹1ID
        PlayerPrefs.SetInt("bulletHave1",bulletHave1); //是否拥有子弹1
        PlayerPrefs.SetInt("bulletHurt1",bulletHurt1); //子弹1的伤害
        PlayerPrefs.SetInt("bulletId2", bulletId2);    //子弹2ID
        PlayerPrefs.SetInt("bulletHave2",bulletHave2); //是否拥有子弹2
        PlayerPrefs.SetInt("bulletHurt2",bulletHurt2); //子弹2的伤害
        PlayerPrefs.SetInt("bulletId3",bulletId3);    //子弹3ID
        PlayerPrefs.SetInt("bulletHave3",bulletHave3); //是否拥有子弹3
        PlayerPrefs.SetInt("bulletHurt3",bulletHurt3); //子弹3的伤害

        PlayerPrefs.SetInt("levelId1",levelId1);//关卡1ID
        PlayerPrefs.SetString("levelIdName1",levelIdName1);//关卡1名字
        PlayerPrefs.SetInt("levelDiffcultyId1_1",levelDiffcultyId1_1);//关卡1初级难度
        PlayerPrefs.SetInt("starsNum1_2",starsNum1_2);//关卡1初级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId1_3",levelDiffcultyId1_3);//关卡1中级难度
        PlayerPrefs.SetInt("starsNum1_4",starsNum1_4);//关卡1中级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId1_5",levelDiffcultyId1_5);//关卡1高级难度
        PlayerPrefs.SetInt("starsNum1_6",starsNum1_6);//关卡1高级难度星星数

        PlayerPrefs.SetInt("levelId2",levelId2);//关卡2ID
        PlayerPrefs.SetString("levelIdName2",levelIdName2);//关卡2名字
        PlayerPrefs.SetInt("levelDiffcultyId2_1",levelDiffcultyId2_1);//关卡2初级难度
		PlayerPrefs.SetInt("starsNum2_2",starsNum2_2);//关卡2初级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId2_3",levelDiffcultyId2_3);//关卡2中级难度
        PlayerPrefs.SetInt("starsNum2_4",starsNum2_4);//关卡2中级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId2_5",levelDiffcultyId2_5);//关卡2高级难度
        PlayerPrefs.SetInt("starsNum2_6",starsNum2_6);//关卡2高级难度星星数

        PlayerPrefs.SetInt("levelId3",levelId3);//关卡3ID
        PlayerPrefs.SetString("levelIdName3",levelIdName3);//关卡3名字
        PlayerPrefs.SetInt("levelDiffcultyId3_1",levelDiffcultyId3_1);//关卡3初级难度
        PlayerPrefs.SetInt("starsNum3_2",starsNum3_2);//关卡3初级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId3_3",levelDiffcultyId3_3);//关卡3中级难度
        PlayerPrefs.SetInt("starsNum3_4",starsNum3_4);//关卡3中级难度星星数
        PlayerPrefs.SetInt("levelDiffcultyId3_5",levelDiffcultyId3_5);//关卡3高级难度
        PlayerPrefs.SetInt("starsNum3_6",starsNum3_6);//关卡3高级难度星星数

        PlayerPrefs.SetInt("goldNum",goldNum);//玩家金币

	    PlayerPrefs.SetInt("propsId1",propsId1);//道具1ID
        PlayerPrefs.SetString("propsName1",propsName1);//道具1名字
        PlayerPrefs.SetInt("propsBuy1",propsBuy1);//道具1购入价格
        PlayerPrefs.SetInt("playerNum1",playerNum1);//玩家拥有的道具1数量

        PlayerPrefs.SetInt("propsId2",propsId2);//道具2ID
        PlayerPrefs.SetString("propsName2",propsName2);//道具2名字
        PlayerPrefs.SetInt("propsBuy2",propsBuy2);//道具2购入价格
        PlayerPrefs.SetInt("playerNum2",playerNum2);//玩家拥有的道具2数量

        PlayerPrefs.SetInt("propsId3",propsId3);//道具3ID
        PlayerPrefs.SetString("propsName3",propsName3);//道具3名字
		PlayerPrefs.SetInt("propsBuy3",propsBuy3);//道具3购入价格
        PlayerPrefs.SetInt("playerNum3",playerNum3);//玩家拥有的道具3数量

        PlayerPrefs.SetInt("propsId4",propsId4);//道具4ID
        PlayerPrefs.SetString("propsName4",propsName4);//道具4名字
        PlayerPrefs.SetInt("propsBuy4",propsBuy4);//道具4购入价格
        PlayerPrefs.SetInt("playerNum4",playerNum4);//玩家拥有的道具4数量

	    PlayerPrefs.SetInt("mobsId1",mobsId1);//初级怪ID
        PlayerPrefs.SetString("mobsName1",mobsName1);//初级怪名字
        PlayerPrefs.SetInt("mobsLife1_101",mobsLife1_101);//初级怪初级难度下生命
        PlayerPrefs.SetInt("mobsHurt1_101",mobsHurt1_101);//初级怪初级难度下伤害
        PlayerPrefs.SetInt("mobsLife2_101",mobsLife2_101);//初级怪中级难度下生命
        PlayerPrefs.SetInt("mobsHurt2_101",mobsHurt2_101);//初级怪中级难度下伤害
        PlayerPrefs.SetInt("mobsLife3_101",mobsLife3_101);//初级怪高级难度下生命
        PlayerPrefs.SetInt("mobsHurt3_101",mobsHurt3_101);//初级怪高级难度下伤害
        PlayerPrefs.SetInt("killGold1",killGold1);//初级怪击杀获得金币

		PlayerPrefs.SetInt("mobsId4",mobsId4);//中级怪ID
        PlayerPrefs.SetString("mobsName4",mobsName4);//中级怪名字
        PlayerPrefs.SetInt("mobsLife1_104",mobsLife1_104);//中级怪初级难度下生命
        PlayerPrefs.SetInt("mobsHurt1_104",mobsHurt1_104);//中级怪初级难度下伤害
        PlayerPrefs.SetInt("mobsLife2_104",mobsLife2_104);//中级怪中级难度下生命
        PlayerPrefs.SetInt("mobsHurt2_104",mobsHurt2_104);//中级怪中级难度下伤害
        PlayerPrefs.SetInt("mobsLife3_104",mobsLife3_104);//中级怪高级难度下生命
        PlayerPrefs.SetInt("mobsHurt3_104",mobsHurt3_104);//中级怪高级难度下伤害
        PlayerPrefs.SetInt("killGold2",killGold2);//中级怪击杀获得金币

		PlayerPrefs.SetInt("mobsId7",mobsId7);//高级怪ID
        PlayerPrefs.SetString("mobsName7",mobsName7);//高级怪名字
		PlayerPrefs.SetInt("mobsLife1_107",mobsLife1_107);//高级怪初级难度下生命
		PlayerPrefs.SetInt("mobsHurt1_107",mobsHurt1_107);//高级怪初级难度下伤害
		PlayerPrefs.SetInt("mobsLife2_107",mobsLife2_107);//高级怪中级难度下生命
		PlayerPrefs.SetInt("mobsHurt2_107",mobsHurt2_107);//高级怪中级难度下伤害
		PlayerPrefs.SetInt("mobsLife3_107",mobsLife3_107);//高级怪高级难度下生命
		PlayerPrefs.SetInt("mobsHurt3_107",mobsHurt3_107);//高级怪高级难度下伤害
        PlayerPrefs.SetInt("killGold3",killGold3);//高级怪击杀获得金币

		PlayerPrefs.SetInt("mobsId10",mobsId10);//BOSS1ID
        PlayerPrefs.SetString("mobsName10",mobsName10);//BOSS1名字
        PlayerPrefs.SetInt("mobsLife1_110",mobsLife1_110);//BOSS1初级难度下生命
        PlayerPrefs.SetInt("mobsHurt1_110",mobsHurt1_110);//BOSS1初级难度下伤害
        PlayerPrefs.SetInt("mobsLife2_110",mobsLife2_110);//BOSS1中级难度下生命
        PlayerPrefs.SetInt("mobsHurt2_110",mobsHurt2_110);//BOSS1中级难度下伤害
        PlayerPrefs.SetInt("mobsLife3_110",mobsLife3_110);//BOSS1高级难度下生命
        PlayerPrefs.SetInt("mobsHurt3_110",mobsHurt3_110);//BOSS1高级难度下伤害
        PlayerPrefs.SetInt("killGold4",killGold4);//BOSS1击杀获得金币

        PlayerPrefs.SetInt("mobsId11",mobsId11);//BOSS2ID
        PlayerPrefs.SetString("mobsName11",mobsName11);//BOSS2名字
        PlayerPrefs.SetInt("mobsLife1_111",mobsLife1_111);//BOSS2初级难度下生命
        PlayerPrefs.SetInt("mobsHurt1_111",mobsHurt1_111);//BOSS2初级难度下伤害
        PlayerPrefs.SetInt("mobsLife2_111",mobsLife2_111);//BOSS2中级难度下生命
        PlayerPrefs.SetInt("mobsHurt2_111",mobsHurt2_111);//BOSS2中级难度下伤害
        PlayerPrefs.SetInt("mobsLife3_111",mobsLife3_111);//BOSS2高级难度下生命
        PlayerPrefs.SetInt("mobsHurt3_111",mobsHurt3_111);//BOSS2高级难度下伤害
        PlayerPrefs.SetInt("killGold5",killGold5);//BOSS2击杀获得金币

        PlayerPrefs.SetInt("mobsId12",mobsId12);//BOSS3ID
        PlayerPrefs.SetString("mobsName12",mobsName12);//BOSS3名字
        PlayerPrefs.SetInt("mobsLife1_112",mobsLife1_112);//BOSS3初级难度下生命
        PlayerPrefs.SetInt("mobsHurt1_112",mobsHurt1_112);//BOSS3初级难度下伤害
        PlayerPrefs.SetInt("mobsLife2_112",mobsLife2_112);//BOSS3中级难度下生命
        PlayerPrefs.SetInt("mobsHurt2_112",mobsHurt2_112);//BOSS3中级难度下伤害
        PlayerPrefs.SetInt("mobsLife3_112",mobsLife3_112);//BOSS3高级难度下生命
        PlayerPrefs.SetInt("mobsHurt3_112",mobsHurt3_112);//BOSS3高级难度下伤害
        PlayerPrefs.SetInt("killGold6",killGold6);//BOSS3击杀获得金币

        print("数据储存完成");
	}
	
}
