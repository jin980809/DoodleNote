using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum EThema { None, AmusementPark };

public class ThemaSelector : MonoBehaviour
{
    [SerializeField]
    private string _themaSceneString;

    [SerializeField]
    private LevelSelector _levelSelector;

    [SerializeField]
    private float _sizeUpValue;

    [SerializeField]
    private GameObject Joystick;

    bool _isStay;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStay)
        {
            if (Input.GetMouseButton(0))
            {
                //if (EventSystem.current.IsPointerOverGameObject() == true)
                //{
                //    return;
                //}

                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);               
                Ray2D ray = new Ray2D(wp, Vector2.zero);

                float distance = Mathf.Infinity;
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);
                //Debug.Log(hit.collider);

                if (hit.collider == this.gameObject.GetComponent<PolygonCollider2D>() && !Joystick.GetComponent<FreeJoystick>().is_click)
                {
                    _levelSelector.Activate(true);
                    Joystick.SetActive(false);
                    //UIManager.p_UIManager.ScreenFadeOut();
                    //UIManager.p_UIManager.p_currentThema = _themaSceneString;

                    //StartCoroutine(FadeCoroutine());

                    //SceneManager.LoadScene(_openLevel);
                }
            }
        }
    }

    private IEnumerator FadeCoroutine()
    {
        while(UIManager.p_UIManager.IsFading())
        {
            yield return null;
        }

        Debug.Log("end");
        SceneManager.LoadScene(_themaSceneString);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _isStay = true;

        Vector3 size = new Vector3(gameObject.transform.localScale.x + _sizeUpValue, gameObject.transform.localScale.y + _sizeUpValue, gameObject.transform.localScale.z);
        gameObject.transform.localScale = size;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        _isStay = false;

        Vector3 size = new Vector3(gameObject.transform.localScale.x - _sizeUpValue, gameObject.transform.localScale.y - _sizeUpValue, gameObject.transform.localScale.z);
        gameObject.transform.localScale = size;
    }
}
