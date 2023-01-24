using UnityEngine;


//scriptable object enemy
[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    public int ID;
    public int HP;
    public string enemyName;
    public int power;
    public int speed;
    public int rewardEXP;
}