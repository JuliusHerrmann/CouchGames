using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielstein : MonoBehaviour
{
    public enum MOVEDIRECTION {top, down, left, right};
    public bool moving = false;
    Vector3 naechstePos;
    // Start is called before the first frame update
    private Vector3 velocity = Vector3.zero;

    void Start(){
        naechstePos = transform.position;
    }
    void Update(){
        if(transform.position != naechstePos){
            //transform.Translate(-(transform.position - naechstePos) * Time.deltaTime * 5);
            transform.position = Vector3.SmoothDamp(transform.position, naechstePos, ref velocity, Vector2.Distance(transform.position, naechstePos) * 0.1f);
        }else{
            moving = false;
        }
        /*if(Vector2.Distance(transform.position, naechstePos) < 0.0001f){
            transform.position = naechstePos;
        }*/
    }

    public void move(MOVEDIRECTION direction){
        moving = true;
        RaycastHit2D hit;
    	LayerMask wallLayer = LayerMask.GetMask("Wall");
        switch(direction){
            case MOVEDIRECTION.top:
                hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, wallLayer);
                if(hit.collider != null){
                    Debug.Log(hit.collider.gameObject.transform.position);
                    float distance = hit.collider.gameObject.transform.position.y - transform.position.y;
                    float jumpDisctance = (distance / 0.5f);
                    naechstePos = new Vector3(transform.position.x, transform.position.y + (int)jumpDisctance * 0.5f, 0);
                }
                break;
            case MOVEDIRECTION.down:
                hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, wallLayer);
                    if(hit.collider != null){
                        Debug.Log(hit.collider.gameObject.transform.position);
                        float distance = hit.collider.gameObject.transform.position.y - transform.position.y;
                        float jumpDisctance = (distance / 0.5f);
                        naechstePos = new Vector3(transform.position.x, transform.position.y + (int)jumpDisctance * 0.5f, 0);
                    }
                break;
            case MOVEDIRECTION.left:
                hit = Physics2D.Raycast(transform.position, -Vector2.right, Mathf.Infinity, wallLayer);
                if(hit.collider != null){
                    Debug.Log(hit.collider.gameObject.transform.position);
                    float distance = hit.collider.gameObject.transform.position.x - transform.position.x;
                    float jumpDisctance = (distance / 0.5f);
                    naechstePos = new Vector3(transform.position.x  + (int)jumpDisctance * 0.5f, transform.position.y, 0);
                }
                break;
            case MOVEDIRECTION.right:
                hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, wallLayer);
                    if(hit.collider != null){
                        Debug.Log(hit.collider.gameObject.transform.position);
                        float distance = hit.collider.gameObject.transform.position.x - transform.position.x;
                        float jumpDisctance = (distance / 0.5f);
                        naechstePos = new Vector3(transform.position.x  + (int)jumpDisctance * 0.5f, transform.position.y, 0);   
                    }
                break;
        }
    }
}
