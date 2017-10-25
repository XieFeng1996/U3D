using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedoing : MonoBehaviour
{
    public static gamedoing _instance; //实例化一个对象

    /*
     * 1.进入关卡时的玩家数据及处理
    */

    //获取玩家的难度
    public int playerDifficuty;

    //获取玩家的飞机伤害和飞机生命
    public int playerAirLife;
    public int playerAirHurt;

    //小怪的生命值和伤害、击杀获得的金币
    public int mobsLife1;
    public int mobsHurt1;
    public int mobsGold1;
    //中怪的生命值和伤害、击杀获得的金币
    public int mobsLife2;
    public int mobsHurt2;
    public int mobsGold2;
    //boss的生命值和伤害、击杀获得的金币
    public int mobsLife3;
    public int mobsHurt3;
    public int mobsGold3;
    //出怪速度(小怪、中怪)
    private float mobsStrangeSpeed;
    //怪物数量上限
    public int monsterCap;
    //玩家的击杀数量
    public int playerKillNumber;
    //boss出现位置
    public int bossAppearPlace;
    //怪物的攻击频率
    public float mobsAttackFrequency;
    //Boss的攻击频率
    public float BossAttackFtrquency;
    //获得玩家的关卡选择数据
    private int playerLevelChange;
    //道具使用次数
    public int usedPropsNumber;
    //玩家飞机生命（游戏中）
    public int playerAirLifeInGame;
    /*
     *  对于策划案中的怪物移动速度，砍了，不要。这句话知道就好。
    */


    //根据玩家选择的难度获取对应关卡，对应难度的boss数据
    public void LevelChange(int difficutyType)
    {
        playerLevelChange = PlayerPrefs.GetInt("playerLevelChange", 0);//玩家关卡
        switch (playerLevelChange)
        {
            case 0:         //关卡1
                if (difficutyType == 0)
                {  //简单
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife1_110", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt1_110", 0);
                }
                else if (difficutyType == 1)
                { //正常
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife2_110", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt2_110", 0);
                }
                else
                { //困难
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife3_110", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt3_110", 0);
                }
                break;
            case 1:        //关卡2
                if (difficutyType == 0)
                {  //简单
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife1_111", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt1_111", 0);
                }
                else if (difficutyType == 1)
                { //正常
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife2_111", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt2_111", 0);
                }
                else
                { //困难
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife3_111", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt3_111", 0);
                }
                break;
            case 2:        //关卡3
                if (difficutyType == 0)
                {  //简单
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife1_112", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt1_112", 0);
                }
                else if (difficutyType == 1)
                { //正常
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife2_112", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt2_112", 0);
                }
                else
                { //困难
                    mobsLife3 = PlayerPrefs.GetInt("mobsLife3_112", 0);
                    mobsHurt3 = PlayerPrefs.GetInt("mobsHurt3_112", 0);
                }
                break;
        }
    }
    public void playerchangeDifficutyType()
    {
        playerDifficuty = PlayerPrefs.GetInt("playChangeDifficuty", 0);
        //传入玩家选择的难度,获取对应的boss数据
        LevelChange(playerDifficuty);
        //获得对应的怪物属性
        switch (playerDifficuty)
        {
            case 0:      //简单难度
                mobsLife1 = PlayerPrefs.GetInt("mobsLife1_101", 0);
                mobsHurt1 = PlayerPrefs.GetInt("mobsHurt1_101", 0);
                mobsGold1 = PlayerPrefs.GetInt("killGold1", 0);

                mobsLife2 = PlayerPrefs.GetInt("mobsLife1_104", 0);
                mobsHurt2 = PlayerPrefs.GetInt("mobsHurt1_104", 0);
                mobsGold2 = PlayerPrefs.GetInt("killGold2", 0);
                break;
            case 1:      //正常难度
                mobsLife1 = PlayerPrefs.GetInt("mobsLife2_101", 0);
                mobsHurt1 = PlayerPrefs.GetInt("mobsHurt2_101", 0);
                mobsGold1 = PlayerPrefs.GetInt("killGold1", 0);

                mobsLife2 = PlayerPrefs.GetInt("mobsLife2_104", 0);
                mobsHurt2 = PlayerPrefs.GetInt("mobsHurt2_104", 0);
                mobsGold2 = PlayerPrefs.GetInt("killGold2", 0);
                break;
            case 2:      //困难难度
                mobsLife1 = PlayerPrefs.GetInt("mobsLife3_101", 0);
                mobsHurt1 = PlayerPrefs.GetInt("mobsHurt3_101", 0);
                mobsGold1 = PlayerPrefs.GetInt("killGold1", 0);

                mobsLife2 = PlayerPrefs.GetInt("mobsLife3_104", 0);
                mobsHurt2 = PlayerPrefs.GetInt("mobsHurt3_104", 0);
                mobsGold2 = PlayerPrefs.GetInt("killGold2", 0);
                break;
        }

    }
    public void getPlayerAirLife()
    {
        //通过ID来获取玩家最好的飞机
        int playerAir1 = PlayerPrefs.GetInt("airplaneId1", 0);
        int playerAir2 = PlayerPrefs.GetInt("airplaneId2", 0);
        int playerAir3 = PlayerPrefs.GetInt("airplaneId3", 0);
        int temp;
        if (playerAir1 > playerAir2)
        {
            temp = playerAir1;
        }
        else
        {
            temp = playerAir2;
        }
        if (temp < playerAir3)
        {
            temp = playerAir3;
        }
        switch (temp)
        {
            case 1:
                playerAirLife = PlayerPrefs.GetInt("airplaneLife1", 0);
                break;
            case 2:
                playerAirLife = PlayerPrefs.GetInt("airplaneLife2", 0);
                break;
            case 3:
                playerAirLife = PlayerPrefs.GetInt("airplaneLife3", 0);
                break;
        }
    }
    public void getPlayerAirHurt()
    {
        //判断是否拥有对应的子弹
        int playerAir1Hurt = PlayerPrefs.GetInt("bulletHave1", 0);
        int playerAir2Hurt = PlayerPrefs.GetInt("bulletHave2", 0);
        int playerAir3Hurt = PlayerPrefs.GetInt("bulletHave3", 0);
        //飞机的子弹ID(默认都为0)
        int bulletId1 = 0;
        int bulletId2 = 0;
        int bulletId3 = 0;

        if (playerAir1Hurt == 1)
        {
            bulletId1 = PlayerPrefs.GetInt("bulletId1", 0);
        }
        if (playerAir2Hurt == 1)
        {
            bulletId2 = PlayerPrefs.GetInt("bulletId2", 0);
        }
        if (playerAir3Hurt == 1)
        {
            bulletId3 = PlayerPrefs.GetInt("bulletId3", 0);
        }
        int temp;
        if (playerAir1Hurt > playerAir2Hurt)
        {
            temp = playerAir1Hurt;
        }
        else
        {
            temp = playerAir2Hurt;
        }
        if (temp < playerAir3Hurt)
        {
            temp = playerAir3Hurt;
        }
        switch (temp)
        {
            case 1:
                playerAirHurt = PlayerPrefs.GetInt("bulletHurt1", 0);
                break;
            case 2:
                playerAirHurt = PlayerPrefs.GetInt("bulletHurt2", 0);
                break;
            case 3:
                playerAirHurt = PlayerPrefs.GetInt("bulletHurt3", 0);
                break;
        }
    }
    //设置出现怪物的函数
    private void setMobsShowing()
    {   //这个数值晓锐你看着调，攻击时间间隔你看着改
        switch (playerDifficuty)
        {
            case 0:   //简单
                //怪物总数目
                monsterCap = 60;
                //怪物的攻击时间间隔
                mobsAttackFrequency = 0.3f;
                //boss出现位置
                bossAppearPlace = 45;
                //boss攻击时间间隔
                BossAttackFtrquency = 0.2f;
                //道具使用次数(不计入评分规则中)
                usedPropsNumber = 0;
                //玩家飞机生命
                playerAirLifeInGame = playerAirLife;
                //玩家击杀小怪数量(不计入评分规则中)
                playerKillNumber = 0;
                break;
            case 1:   //正常
                //怪物总数目
                monsterCap = 80;
                //怪物的攻击时间间隔
                mobsAttackFrequency = 0.2f;
                //boss出现位置
                bossAppearPlace = 60;
                //boss攻击时间间隔
                BossAttackFtrquency = 0.2f;
                //道具使用次数(不计入评分规则中)
                usedPropsNumber = 0;
                //玩家飞机生命
                playerAirLifeInGame = playerAirLife;
                //玩家击杀小怪数量(计入评分规则中)
                playerKillNumber = 0;
                break;
            case 2:   //困难
                //怪物总数目
                monsterCap = 100;
                //怪物的攻击时间间隔
                mobsAttackFrequency = 0.2f;
                //boss出现位置
                bossAppearPlace = 75;
                //boss攻击时间间隔
                BossAttackFtrquency = 0.1f;
                //道具使用次数(计入评分规则中)
                usedPropsNumber = 0;
                //玩家飞机生命
                playerAirLifeInGame = playerAirLife;
                //玩家击杀小怪数量(计入评分规则中)
                playerKillNumber = 0;
                break;
        }
    }

    void Awake()
    {
        _instance = this;

        //获取怪物属性
        playerchangeDifficutyType();
        //获得玩家的飞机和飞机伤害
        getPlayerAirLife();
        getPlayerAirHurt();
        //设置关卡数据
        setMobsShowing();

    }

    // Update is called once per frame

    void Update()
    {

    }
}
