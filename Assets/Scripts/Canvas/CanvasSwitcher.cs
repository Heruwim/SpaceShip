using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas _canvas169;
    [SerializeField] private Canvas _canvas189;

    private Canvas _activeCanvas;

	 private void Awake () 
	 {	
			float aspectRatio = (float)Screen.width / Screen.height;

        if (aspectRatio > 1.78f) 
        {
            EnableCanvas(_canvas189);
        }
        else 
        {
            EnableCanvas(_canvas169);
        }
	 }

	 private void EnableCanvas(Canvas canvas)
     {
        canvas.gameObject.SetActive(true);

        foreach (Canvas otherCanvas in GetComponentsInChildren<Canvas>())
        {
            if (otherCanvas != canvas)
            {
                otherCanvas.gameObject.SetActive(false);
            }
        }
     }

}
