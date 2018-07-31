using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuTracker : MonoBehaviour
{
    public GameObject boxFlasher1;
    public GameObject boxFlasher2;
    public GameObject boxFlasher3;
    public Button resume;
    public Button start;
    public Button random;
    public Text quoteBox;
    private string[] quotes = new string[35];
    private int tracker = 0;
    private const int Intro = 2;

    private void Start()
    {
        quotes[0] = "Guys love it when you can show them you're better than they are at soemthing they love. -Leslie Knope";
        quotes[1] = "Punk-ass book jockeys! -Leslie Knope";
        quotes[2] = "You know my codde, hoes before bros. Uteruses before duderuses. Ovaries before brovaries. -Leslie Knope";
        quotes[3] = "What I hear when I'm being yelled at is people caring really loudly at me -Leslie Knope";
        quotes[4] = "I ate a brownie once at a party in college. It was kind of indescribable relaly. I felt like I was floating. It turns out that there wasn't any marijuana in it, it was just an insanely good brownine. -Leslie Knope";
        quotes[5] = "I tried to make ramen in the coffee pot and I broke everything -Andy Dwyer";
        quotes[6] = "Veganism is the sad result of a morally corrupt mind. Reconsider your life. -Ron Swanson";
        quotes[7] = "I'm worrid about Schmidt. He's a Jew in the desert. I don't want him to wander. -Winston Bishop";
        quotes[8] = "They call me Prank Sinatra! -Winston Bishop";
        quotes[9] = "I'm a hit you ass with a ski! Get some! -Winston Bishop";
        quotes[10] = "I'm not convinced I know how to read, I've just memorized a lot of words. -Nick Miller";
        quotes[11] = "I'm a beat your ass with an athletic stick boy! -Winston Bishop";
        quotes[12] = "I'm not superstitious, but...I'm a little-stitious. -Michael Scott";
        quotes[13] = "I'm about to lose my freaking mind! -Andy Bernard";
        quotes[14] = "If I had a gun with two bullets and I was in a room with Hitler, Bin Laden and Toby, I would shoot Toby twice -Michael Scott";
        quotes[15] = "Sometimes I'll start a sentence and I don't even know where it's going. I just hope I find it along the way. -Michael Scott";
        quotes[16] = "Bears. Beets. Battlestar Galactica. -Jim Halpert";
        quotes[17] = "Identity theft is not a joke Jim! Millions of familes suffer every year! -Dwight Schrute";
        quotes[18] = "Well, happy birthday Jesus. Sorry your party's so lame. -Michael Scott";
        quotes[19] = "Saw Inception...Or at least I dreamt I did. -Michael Scott";
        quotes[20] = "I love lamp -Brick Tamland";
        quotes[21] = "Why don't you go back to your home on whore island? -Ron Burgundy";
        quotes[22] = "I'm not a baby! I'm a man! An ANCHORMAN! -Ron Burgundy";
        quotes[23] = "I remember when I had my first beer -Brennan Huff";
        quotes[24] = "Don't put that evil on me Ricky Bobby -Lucius Washington";
        quotes[25] = "Yeah there were horses and a man on fire and I killed a guy with a trident. -Brick Tamland";
        quotes[26] = "By the beard of Zeus! -Ron Burgundy";
        quotes[27] = "I'm not even mad...that's amazing. -Ron Burgundy";
        quotes[28] = "I HATE YOU! -Anakin Skywalker";
        quotes[29] = "Power, Unlimited power! -Chancellor Palpatine";
        quotes[30] = "Do it. -Chancellor Palpatine";
        quotes[31] = "No... no, no, YOU WILL DIE! -Chancellor Palpatine";
        quotes[32] = "There's nothing wrong with having a tree as a friend. -Bob Ross";
        quotes[33] = "I guess I’m a little weird. I like to talk to trees and animals. That’s okay though; I have more fun than most people. -Bob Ross";
        quotes[34] = "Now then, let's come right down in here and put some nice big strong arms on these trees. Tree needs an arm too. It'll hold up the weight of the forest. Little bird has to have a place to set there. There he goes... -Bob Ross";
        quotes[33] = "Believe that you can do it cause you can do it. -Bob Ross";
    }
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (tracker < 2)
            {
                tracker++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (tracker > 0)
            {
                tracker--;
            }
        }
        if (tracker == 0)
        {
            boxFlasher1.SetActive(true);
            boxFlasher2.SetActive(false);
            boxFlasher3.SetActive(false);
            resume.enabled = true;
            start.enabled = false;
            random.enabled = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeGameButton();
            }
        }
        else if (tracker == 1)
        {
            boxFlasher1.SetActive(false);
            boxFlasher2.SetActive(true);
            boxFlasher3.SetActive(false);
            resume.enabled = false;
            start.enabled = true;
            random.enabled = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NewGameButton();
            }
        }
        else
        {
            boxFlasher1.SetActive(false);
            boxFlasher2.SetActive(false);
            boxFlasher3.SetActive(true);
            resume.enabled = false;
            start.enabled = false;
            random.enabled = true;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RandomizeText();
            }
        }
    }
    public void ResumeGameButton()
    {

    }
    public void NewGameButton()
    {
        SceneManager.LoadScene(Intro);
    }
    public void RandomizeText()
    {
        int whichOne = Random.Range(0, 35);
        quoteBox.text = quotes[whichOne];
    }
}
