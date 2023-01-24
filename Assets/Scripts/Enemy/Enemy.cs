using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy가 가지고 있는 script
//enemyData를 사용하여 이동시키기, HP가 0이 되면 죽도록 설정.
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public EnemyManager enemyManager;
    private GameObject player;

    public float pursuitSpeed;
    public float wanderSpeed = 1f;
    public float currentSpeed;

    public float directionChangeInterval = 0.5f;
    public bool followPlayer = true;

    Coroutine moveCoroutine;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rb2d;
    Animator animator;

    Transform targetTransform = null;
    Vector3 endPosition;
    float currentAngle = 0;
    float remainDistance;

    private void Start(){
        player = GameObject.Find("Player");

        targetTransform = player.transform;
        endPosition = targetTransform.position;
        currentSpeed = wanderSpeed;

        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        //StartCoroutine(WanderRoutine());
        //StartCoroutine(Move(wanderSpeed));
        
    }
    private void Update() {
        
        //Debug.DrawLine(rb2d.position, endPosition, Color.red);
    }
    private void FixedUpdate() {
        endPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, enemyData.speed * Time.deltaTime);
    }
    /*


    IEnumerator Move(float speed){
        remainDistance = (transform.position - endPosition).sqrMagnitude;
        Debug.Log("raminDistance: "+remainDistance);
        Debug.Log("float epsilona:"+float.Epsilon);
        
        //true: remainDistance가 아주 작은 숫자가 아님.
        while (remainDistance > float.Epsilon)
        {
            //목표 지점을 타겟으로.
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            //
       

            animator.SetBool("Run", true);
            Vector3 newPosition = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            transform.position = newPosition;



            Debug.Log("new position: "+newPosition);

            //rb2d.MovePosition(newPosition);
            remainDistance = (transform.position - endPosition).sqrMagnitude;

            yield return new WaitForFixedUpdate();
        }
        animator.SetBool("Run", false);
    }
    */
    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && followPlayer){
            targetTransform = collision.gameObject.transform;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
        }
    }
    */
    
    public void toString(){
        Debug.Log("name: " + enemyData.enemyName);
    }
}
