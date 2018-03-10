using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;


public class StartOptions : MonoBehaviour {



	public int sceneToStart = 1;										//Index number in build settings of scene to load if changeScenes is true
	public bool changeScenes;											//If true, load a new scene when Start is pressed, if false, fade out UI and continue in single scene
	public bool changeMusicOnStart;										//Choose whether to continue playing menu music or start a new music clip
	public int musicToChangeTo = 0;										//Array index in array MusicClips to change to if changeMusicOnStart is true.
    public Text playButtonText;

	[HideInInspector] public bool inMainMenu = true;					//If true, pause button disabled in main menu (Cancel in input manager, default escape key)
	[HideInInspector] public Animator animColorFade; 					//Reference to animator which will fade to and from black when starting game.
	[HideInInspector] public Animator animMenuAlpha;					//Reference to animator that will fade out alpha of MenuPanel canvas group
	[HideInInspector] public AnimationClip fadeColorAnimationClip;		//Animation clip fading to color (black default) when changing scenes
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;		//Animation clip fading out UI elements alpha


	private PlayMusic playMusic;										//Reference to PlayMusic script
	private float fastFadeIn = .01f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
	private ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels
    private int choosenLevel = 1;

    void Start()
    {

    }

	void Awake()
	{
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

		//Get a reference to PlayMusic attached to UI object
		playMusic = GetComponent<PlayMusic> ();
	}


	public void StartButtonClicked()
	{
        
        //Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
        Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);

        //Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
        animColorFade.SetTrigger("fade");

        //Load the selected scene
        Application.LoadLevel(1);
        /*
		//If changeScenes is true, start fading and change scenes halfway through animation when screen is blocked by FadeImage
		if (changeScenes) 
		{
            if (PlayerPrefs.GetInt("highscore", 1) > 1)
                choosenLevel = PlayerPrefs.GetInt("highscore")+1;
			
		} 
        
        */
    }

	public void LoadDelayed()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//Hide the main menu UI element
		showPanels.HideMenu ();
        showPanels.HideOptionsPanel();
        showPanels.HidePausePanel();
	}

    public void SetInMainMenu()
    {
        inMainMenu = true;
    }
}
