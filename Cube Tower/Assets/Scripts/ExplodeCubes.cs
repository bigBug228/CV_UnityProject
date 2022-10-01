using UnityEngine;

public class ExplodeCubes : MonoBehaviour{
  private bool _collisionSet;
  public GameObject restartButton, explosion;
  private void OnCollisionEnter(Collision collision) {
    if(collision.gameObject.tag =="Cube" && !_collisionSet){
    for (int i =collision.transform.childCount-1; i>=0; i--){
      Transform child =collision.transform.GetChild(i);
      child.gameObject.AddComponent<Rigidbody>();
      child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f,Vector3.up,5f);
      child.SetParent(null);
    }
    restartButton.SetActive(true);
    Camera.main.transform.position -= new Vector3(0,0,3f);

    Camera.main.gameObject.AddComponent<CameraShake>();
    GameObject newVfx=Instantiate(explosion, new Vector3(collision.contacts[0].point.x,collision.contacts[0].point.y,collision.contacts[0].point.z),Quaternion.identity)as GameObject;
    Destroy(newVfx,1.5f);
    if(PlayerPrefs.GetString("music")!="No")
            GetComponent<AudioSource>().Play();
    Destroy(collision.gameObject);
    _collisionSet = true;
    }
  }
}
