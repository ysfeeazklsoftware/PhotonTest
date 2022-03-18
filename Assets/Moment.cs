using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Moment : MonoBehaviour
{
    PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 30;
            float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * 30;

            transform.Translate(x, y, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
         
              gameObject.GetComponent<PhotonView>().RPC("DestroyGameObject", RpcTarget.All, null); //normalde baþka obje için kullanýlýyor ama ben onu yapamadým kendi üstüme denedim burada sol týk yapýnca nesnenin PhotonViewinden RPC ile nesnenin içinde ki fonksiyonu çalýþtýrýyo
                                                    //yani methodun tutulduðu componenti çaðýrýp methodu çalýþtýrmýyoruz direkt methodu çalýþtýrýyoruz
        }
       
    }

    [PunRPC]
    public void DestroyGameObject()
    { 
        PhotonNetwork.Destroy(gameObject);
    }
}
