using System.Collections;
using UnityEngine;

public class InterFaded : MonoBehaviour
{
    [SerializeField] private CanvasGroup _FadeCanvasGroup;
    [SerializeField] private float _fadeSpeed = 1f;

    private bool _isOpen = false;


    [ContextMenu("Toggle UI")]
    private void ToggleUI()
    {
        _isOpen = !_isOpen;
        
        //StartCoroutine(Faded(_isOpen));

        _FadeCanvasGroup.Fade(_isOpen,0.5f);

    }
    /*IEnumerator Faded(bool isOpen)
    {
        float alpha = isOpen ? 0f : 1f;

        if(isOpen)
        {
            while(alpha < 1f)
            {
                alpha += _fadeSpeed * Time.deltaTime;
                _FadeCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
        else
        {
            while(alpha > 0)
            {
                alpha -= _fadeSpeed * Time.deltaTime;
                _FadeCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Finish Fading");
    }*/
}
