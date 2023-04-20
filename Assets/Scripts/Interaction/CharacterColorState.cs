using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorState : MonoBehaviour
{
    Animator Anim;

    public enum ColorState
    {
        Origin = 0,
        Red = 1,
        Orange = 2,
        Yellow = 3,
        Green = 4,
        Blue = 5,
        Purple = 6
    };

    public ColorState _ColorState { get; set; }

    public ColorState currentColor; // Current color of the character

    void Start()
    {
        Anim = this.GetComponent<Animator>();
        currentColor = ColorState.Origin;
    }

    void Update()
    {
        //SetColor();
    }

    public void SetColor()
    {
        switch (currentColor)
        {

            case ColorState.Red:
                Anim.SetBool("is_red", true);
                break;

            case ColorState.Orange:
                Anim.SetBool("is_orange", true);
                break;

            case ColorState.Yellow:
                Anim.SetBool("is_yellow", true);
                break;

            case ColorState.Green:
                Anim.SetBool("is_green", true);
                break;

            case ColorState.Blue:
                Anim.SetBool("is_blue", true);
                break;

            case ColorState.Purple:
                Anim.SetBool("is_purple", true);
                break;
        }
    }

    void Anim_End()
    {
        Anim.SetBool("is_red", false);
        Anim.SetBool("is_orange", false);
        Anim.SetBool("is_yellow", false);
        Anim.SetBool("is_green", false);
        Anim.SetBool("is_blue", false);
        Anim.SetBool("is_purple", false);

        switch (currentColor)
        {
            case ColorState.Red:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.7568628f, 0.7411765f, 1);
                break;

            case ColorState.Orange:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.8509805f, 0.63921570f, 1);
                break;

            case ColorState.Yellow:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.9764706f, 0.8196079f, 1);
                break;

            case ColorState.Green:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(0.8196079f, 0.9921569f, 0.7098039f, 1);
                break;

            case ColorState.Blue:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(0.654902f, 0.7098039f, 1, 1);
                break;

            case ColorState.Purple:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(0.8117648f, 0.627451f, 1, 1);
                break;
        }
    }
}
