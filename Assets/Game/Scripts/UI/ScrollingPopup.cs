using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityUtilities.ObjectPool;

public class ScrollingPopup : MonoBehaviour
{
    private static GameObject prefab;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Text text;
    public Text Text
    {
        get { return text; }
        private set { text = value; }
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length));
    }

    private IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPool.Destroy(gameObject);
    }

    public static void Create(string text, Vector2 position)
    {
        if (prefab == null)
        {
            prefab = Resources.Load<GameObject>("Prefabs/Scrolling Popup");
        }

        ScrollingPopup scrollingPopup = ObjectPool.Spawn(prefab, Vector3.zero, Quaternion.identity).GetComponent<ScrollingPopup>();
        scrollingPopup.transform.SetParent(UIManager.Instance.HudObject.transform);
        scrollingPopup.transform.position = Camera.main.WorldToScreenPoint(new Vector2(position.x + Random.Range(-0.5f, 0.5f), position.y + Random.Range(-0.5f, 0.5f)));
        scrollingPopup.Text.text = text;
    }
}
