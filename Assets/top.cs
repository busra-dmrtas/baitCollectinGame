using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{

    public int puan = 0;
    public GameObject kirmiziYem;
    public GameObject yesilYem;
    int sure = 0;
    int hiz = 5;
    
    void Start()
    {
        
    } 
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal")*Time.deltaTime*hiz;
        float dikey = Input.GetAxis("Vertical")*Time.deltaTime*hiz;
        transform.Translate(yatay, dikey, 0);
        sure++;
        if (sure>=1000)
        {
            hiz +=3;
            sure = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="tag_yesil")
        {
            puan += 2;
            Destroy(collision.gameObject);
            YemUret();
        }
        if (collision.gameObject.tag == "tag_kirmizi")
        {
            puan --;
            Destroy(collision.gameObject);
            YemUret();
        }
        Debug.Log(puan.ToString());
    }

    private void YemUret()
    {
        int adet=Random.Range(1,5);
        for (int i = 0; i < adet; i++)
        {
            int yemTuru = Random.Range(0, 2);
            int yeniX = Random.Range(-9, 10);
            int yeniY = Random.Range(-4, 5);
            if (yemTuru == 0)
            {
                Instantiate(yesilYem, new Vector2(yeniX, yeniY), Quaternion.identity);
            }
            if (yemTuru == 1)
            {
                Instantiate(kirmiziYem, new Vector2(yeniX, yeniY), Quaternion.identity);
            }
        }
    }

}
