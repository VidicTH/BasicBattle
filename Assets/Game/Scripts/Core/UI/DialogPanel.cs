using UnityEngine;
using System.Collections;

public class DialogPanel : AnimatedPanel {

	public static DialogPanel instance {
		get {
			return _instance;
		}
	}

	[SerializeField] UILabel nameLabelLeft;
	[SerializeField] UILabel nameLabelRight;
	[SerializeField] UILabel textLabel;
	[SerializeField] TypewriterEffect typeEffect;

	[SerializeField] GameObject leftCharacter;
	[SerializeField] GameObject rightCharacter;
	[SerializeField] GameObject handObj;

	[SerializeField] UI2DSprite[] sprites;
	
	[SerializeField] UISprite white;
	[SerializeField] UISprite black;
	
	[SerializeField] GameObject[] backgrounds;
	
	[SerializeField] AnimatedPanel textPanel;
	
	static DialogPanel _instance;
	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		if ( this.gameObject.activeSelf ) {
			this.gameObject.SetActive(false);
			this.alpha = 0f;
		}
	}
	
	void Update()
	{
	}
	
	public static void Display(string name, string text, bool enemySide = false)
	{
		
		if ( !_instance.textPanel.IsShowing )
		{
			_instance.textPanel.Show();
			//Debug.LogError("Text giníh");
		}
	
		_instance.nameLabelLeft.text = name;
		_instance.nameLabelRight.text = name;
		_instance.textLabel.text = text;
		_instance.typeEffect.ResetToBeginning();
		
		_instance.leftCharacter.SetActive(false);
		_instance.rightCharacter.SetActive(false);
		
		if ( enemySide )
		{
			_instance.rightCharacter.SetActive(true);
		}
		else
		{
			_instance.leftCharacter.SetActive(true);
		}
		
		_instance.Show();
	}
	
	public static Coroutine WaitDisplay(string name, string text, bool enemySide = false)
	{
		_instance.gameObject.SetActive(true);
		return _instance.StartCoroutine(_instance._WaitDisplay(name,text,enemySide));

	}
	
	bool waitingForTextDismiss = false;
	IEnumerator _WaitDisplay(string name, string text, bool enemySide) {
		
		//RandomCharacter();
		typeEffect.Finish();
		handObj.SetActive (false);
		_instance.nameLabelLeft.text = name;
		_instance.nameLabelRight.text = name;
		_instance.textLabel.text = text;
		typeEffect.ResetToBeginning();
		
		_instance.leftCharacter.SetActive(false);
		_instance.rightCharacter.SetActive(false);
		
		if ( enemySide )
		{
			_instance.rightCharacter.SetActive(true);
		}
		else
		{
			_instance.leftCharacter.SetActive(true);
		}
		
		//_instance.Show();
		_instance.textPanel.Show();
		
		waitingForTextDismiss = true;
		while ( waitingForTextDismiss )
		{
			yield return null;
		}

	}
	
	void RandomCharacter()
	{
		int index = Random.Range(0,sprites.Length);
		for ( int i = 0; i < sprites.Length; i++ )
		{
			sprites[i].gameObject.SetActive(i==index);
		}
	}
	
	public static Coroutine Whiteout(float duration, float alpha)
	{
		var tween = TweenAlpha.Begin(_instance.white.gameObject,duration,alpha);
		tween.AddOnFinished(()=>{ _instance.waitingForTween = false; });
		_instance.gameObject.SetActive(true);
		_instance.waitingForTween = true;
		return _instance.StartCoroutine(_instance.WaitForTween());	
	}
	
	bool waitingForTween = false;
	IEnumerator WaitForTween()
	{
		waitingForTween = true;
		while( waitingForTween )
		{
			yield return null;
		}
	}
	
	public static void HideName()
	{
		_instance.nameLabelLeft.transform.parent.gameObject.SetActive(false);
		_instance.nameLabelRight.transform.parent.gameObject.SetActive(false);
	}
	
	public static void ShowName()
	{
		_instance.nameLabelLeft.transform.parent.gameObject.SetActive(true);
		_instance.nameLabelLeft.transform.parent.gameObject.SetActive(true);
	}
	
	public static void ShowCharacter(bool right)
	{
		_instance.leftCharacter.gameObject.SetActive(!right);
		_instance.rightCharacter.gameObject.SetActive(right);
	}
	
	public static void HideCharacters()
	{
		_instance.leftCharacter.gameObject.SetActive(false);
		_instance.rightCharacter.gameObject.SetActive(false);
	}
	
	public static void HideText()
	{
		_instance.textPanel.Hide();
	}
	
	public static void SetBackground(int index)
	{
		_instance._SetBackground(index);
	}
	
	void _SetBackground(int index)
	{
		for ( int i = 0; i < backgrounds.Length; i++ )
		{
			backgrounds[i].SetActive(i == index);
		}
	}
	
	protected override void PanelWillShow ()
	{
		textPanel.alpha = 0f;
		_SetBackground(-1);
		HideCharacters();
		base.PanelWillShow();
	}
	
	protected override void PanelDidShow ()
	{
		base.PanelDidShow();
		//Chronos.Timekeeper.instance.Clock("Root").localTimeScale = 0f;
	}
	
	protected override void PanelDidHide ()
	{
		base.PanelDidHide();

	}
	
	public void Dismiss()
	{
		if ( typeEffect.isActive ) 
		{
			typeEffect.Finish();
		
		}
		else
		{
			waitingForTextDismiss = false;

		}
	}
	public void Onfinish(){
		handObj.SetActive(true);
	}
}
