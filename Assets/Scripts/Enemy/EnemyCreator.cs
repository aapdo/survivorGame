using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Bat, Crab, Golem
}

public class EnemyCreator : MonoBehaviour
{
    [SerializeField]
    private List<EnemyData> enemyDatas;
    [SerializeField]
    private List<GameObject> enemyPrefabs;

    public GameObject enemyManager_;
    private EnemyManager enemyManager;
    private GameObject enemyInst;
    private Enemy enemy;

    void Start()
    {
        enemyManager = enemyManager_.GetComponent<EnemyManager>();
        for (int i = 0; i < enemyDatas.Count; i++)
        {
            enemyInst = createEmeny( (EnemyType)i );
            enemyManager.enemys.Enqueue(enemyInst);
            enemy.toString();
        }
        
        //enemyManager.
        
    }
    public GameObject createEmeny(EnemyType type){
        enemyInst = Instantiate(enemyPrefabs[(int)type]);
        //enemy Component: 체력 관리, 속도 설정등.
        enemy = enemyInst.GetComponent<Enemy>();
        //enemyData 넣어주기
        enemy.enemyData = enemyDatas[(int)type];
        enemy.enemyManager = enemyManager;
        //게임 오브젝트 이름 설정
        enemy.gameObject.name = enemy.enemyData.enemyName;
        //enemyManager 넣어주기
        enemy.enemyManager = enemyManager;

        return enemyInst;
    }
    
    
    public GameObject createEmeny(int type){
        enemyInst = Instantiate(enemyPrefabs[type]);
        enemy = enemyInst.GetComponent<Enemy>();
        enemy.enemyData = enemyDatas[type];
        enemy.gameObject.name = enemy.enemyData.enemyName;

        return enemyInst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
