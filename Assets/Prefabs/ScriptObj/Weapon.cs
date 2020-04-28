using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public GameObject hosePref;

    public override void UseItem()
    {
        
        if (true) // is shoot posible
        {
            Vector3 PointerPos = Input.mousePosition;                                //получаем коруды мышки
            PointerPos.z = 10;
            Vector3 Start = PlayerTransform.position;                                //получаем корты игрока
            Vector3 Direct = (Camera.main.ScreenToWorldPoint(PointerPos) - Start);   //вычисляем каправление

            int ignore = ~(1 << 8);                                                  //это фильтра, чтобы игнорить игрока
           
            RaycastHit2D hit = Physics2D.Raycast(Start, Direct, 10,ignore);         //пускаем луч
            if (hit.point != null)                                                   //проверяем сталкнулся ли он
            {
                Instantiate(hosePref, hit.point, new Quaternion());                  //создаём мячик на месте столкновения
            }
        }
    }
}
