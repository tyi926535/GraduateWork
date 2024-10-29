using UnityEngine;
using UnityEngine.UI;

public class BActive : MonoBehaviour
{
    public Button but;
    public Sprite gal;

    public void ChangeButtonSprite(Sprite spr1)
    {
        if (but.image.sprite != spr1) { but.image.sprite = spr1; }
        else { but.image.sprite = gal; }

    }

}
