using UnityEngine;

public class onTriggKill : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        foreach (fall parent in  collision.transform.GetComponentsInParent<fall>())//.Rise_Death(false);
        {
            parent.Rise_Death(true);
        }
    }
}
