using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene10 : MonoBehaviour
{
    [SerializeField] List<Sprite> card_Img;
    [SerializeField] SpriteRenderer[] card_Slot;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        animator = GetComponent<Animator>();
        Invoke("PlayStartAnim", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button back = root.Q<Button>("Back");
        Button draw = root.Q<Button>("draw");

        back.clicked += () => SceneManager.LoadScene(sceneName: "SampleScene");
        //draw.clicked += () => ShuffleCards();
    }
    
    public void Shuffle_Cards()
    {
        StartCoroutine(ResetAnim());
    }

    void PlayStartAnim()
    {
        animator.Play("Shuffle");
        ShuffleCards();
    }

    IEnumerator ResetAnim()
    {
        animator.Play("Reset");
        yield return new WaitForSeconds(2f);
        animator.Play("Shuffle");
        ShuffleCards();

    }

    void ShuffleCards()
    {
        
        for (int i = 0; i < card_Slot.Length; i++)
        {
            List<int> list = new List<int>();
            int Rand = 0;
            list = new List<int>(new int[card_Img.Count]);

            for (int j = 1; j < card_Img.Count; j++)
            {
                Rand = Random.Range(0, card_Img.Count);

                while (list.Contains(Rand))
                {
                    Rand = Random.Range(0, card_Img.Count);
                }
            }
            card_Slot[i].sprite = card_Img[Rand];
        }
    }
}
