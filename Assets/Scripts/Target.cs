using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;
    public int targetScore;
	
	private bool dirRight = true;
    public float movingSpeed = 1.3f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider item) 
    {
        if (item.gameObject.tag == "Bullet")
        {
            ScoreManager.UpdateScore(targetScore);
            Destroy(target); // destroys target, may consider not destroying too
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target.tag == "MovingTarget" || target.tag == "FlyingTarget") {
            if (dirRight)
                transform.Translate (Vector3.right * movingSpeed * Time.deltaTime);
            else
                transform.Translate (-Vector3.right * movingSpeed * Time.deltaTime);
            
            if(transform.position.x >= 4.5f) {
                dirRight = false;
            }
            
            if(transform.position.x <= -4.0f) {
                dirRight = true;
            }
        }
    }
}
