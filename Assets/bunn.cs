using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bunn : MonoBehaviour
{
   public float speed;
   public bool vertical;
   public float changeTime = 3.0f;
   Rigidbody2D rigidbody2d;
   float timer;
   int direction = 1;
   void Start()
   {
       rigidbody2d = GetComponent<Rigidbody2D>();
       timer = changeTime;
   }
   void Update()
   {
       timer  -= Time.deltaTime;
      if (timer < 0)
      {
        direction = -direction;
        transform.localScale = new Vector3(-direction, 1, 1);
        timer = changeTime;
      }
   }
  void FixedUpdate()
  {    
       Vector2 position = rigidbody2d.position;
       if (vertical){
           position.y = position.y + speed * direction * Time.deltaTime;
       }
       else{
           position.x = position.x + speed * direction * Time.deltaTime;
       }
       rigidbody2d.MovePosition(position);
  }
}
