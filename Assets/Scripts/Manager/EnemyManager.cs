using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
//어느 타이밍에 어떤 적을 만들 지 관리함.
/*
json 데이터로 Enemy 클래스를 만들고 배열에 주소를 보관함.

prefab에 각자 할 수 있는 동작들을 붙여 놓음. 
=> prefab클래스 함수를 manager 에서 콜. 이 때 Enemy를 선택해서 같이 넘겨줌.
=> prefab클래스에선 Enemy 클래스 데이터를 기반으로 체력, 경험치 등을 결정

객체화된 프리팹은 큐에 넣고 하나씩 빼서 돌린다?
근데 또 만들지 아닌지 판단을 해야되는데.. 판단 기준 => 히어로 레벨.

*/
{
    // Start is called before the first frame update
    public Queue<GameObject> enemys = new Queue<GameObject>();
    public GameObject enemyCreator_;
    private EnemyCreator enemyCreator;
    private int selectType = 0;

    void Start()
    {
        enemyCreator = enemyCreator_.GetComponent<EnemyCreator>();
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy(){
        if (selectType < 3)
        {
            selectType++;
        }else{
            selectType = 0;
        }
        enemyCreator.createEmeny(selectType);
        yield return new WaitForSeconds(0.1f); 
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
