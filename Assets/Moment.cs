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
         
              gameObject.GetComponent<PhotonView>().RPC("DestroyGameObject", RpcTarget.All, null); //normalde ba�ka obje i�in kullan�l�yor ama ben onu yapamad�m kendi �st�me denedim burada sol t�k yap�nca nesnenin PhotonViewinden RPC ile nesnenin i�inde ki fonksiyonu �al��t�r�yo
                                                    //yani methodun tutuldu�u componenti �a��r�p methodu �al��t�rm�yoruz direkt methodu �al��t�r�yoruz
        }
       
    }

    [PunRPC]
    public void DestroyGameObject()
    { 
        PhotonNetwork.Destroy(gameObject);
    }
}
