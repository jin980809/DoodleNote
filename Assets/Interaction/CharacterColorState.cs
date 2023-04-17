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

    // Method to set the character's color based on the current color state
    public void SetColor()
    {
        switch (currentColor)
        {
            case ColorState.Origin:
                
                break;

            case ColorState.Red:
                Anim.SetBool("is_red", true);
                break;

            case ColorState.Orange:
                
                break;

            case ColorState.Yellow:
                
                break;

            case ColorState.Green:
                
                break;

            case ColorState.Blue:

                break;

            case ColorState.Purple:
                
                break;
        }
    }

    void Anim_End()
    {
        Anim.SetBool("is_red", false);

        switch (currentColor)
        {
            case ColorState.Origin:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
                break;

            case ColorState.Red:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 0, 1);
                break;

            case ColorState.Orange:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.5f, 0, 1);
                break;

            case ColorState.Yellow:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 0, 1);
                break;

            case ColorState.Green:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0, 1);
                break;

            case ColorState.Blue:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 1, 1);
                break;

            case ColorState.Purple:
                this.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 1, 1);
                break;
        }
    }
}
