using UnityEngine;
using UnityEngine.UI;

namespace VNP.Commons
{
	public class BuildVersion : MonoBehaviour 
	{
		[SerializeField, HideInInspector]
		private Text _textBuilVersion = null;

		[SerializeField]
		private string _preTextVersion = "Build";

		[SerializeField]
		private string _textVersion;

		[SerializeField]
		private Color _textColor = Color.yellow;

		[SerializeField, Range(8,64)]
		private int _fontSize = 14;

		[SerializeField]
		private AlignBuildVersion _screenPosition = AlignBuildVersion.TopLeft;

        [SerializeField]
        private bool _dontDestroy = true;

		private void Awake()
		{
            if (_dontDestroy)
                DontDestroyOnLoad(gameObject);

			UpdateValues();
		}

		private void OnValidate()
		{
			UpdateValues();
		}

		private void UpdateValues()
		{
			if (_textBuilVersion)
			{
				_textBuilVersion.text = GetTextVersion();
				_textBuilVersion.color = _textColor;
				_textBuilVersion.fontSize = _fontSize;
				SetTextPosition();
			}
		}

		private string GetTextVersion()
		{
			string strVersion;

			if (_textVersion.Trim() != "")
				strVersion = _textVersion;
			else
				strVersion = Application.version;

			return string.Format("{0} {1}", _preTextVersion.Trim(), strVersion);
		}

		private void SetTextPosition()
		{
			RectTransform rectTransform = _textBuilVersion.gameObject.GetComponent<RectTransform>();
			switch (_screenPosition)
			{
				case AlignBuildVersion.TopLeft:
					_textBuilVersion.alignment = TextAnchor.UpperLeft;
					SetTextAnchor( new Vector2(0, 1));
					break;

				case AlignBuildVersion.TopRigt:
					_textBuilVersion.alignment = TextAnchor.UpperRight;
					SetTextAnchor(new Vector2(1, 1));
					break;

				case AlignBuildVersion.BottomLeft:
					_textBuilVersion.alignment = TextAnchor.LowerLeft;
					SetTextAnchor(new Vector2(0, 0));
					break;

				case AlignBuildVersion.BottomRight:
					_textBuilVersion.alignment = TextAnchor.LowerRight;
					SetTextAnchor(new Vector2(1, 0));
					break;
			}
		}

		private void SetTextAnchor(Vector2 anchorPosition)
		{
			RectTransform rectTransform = _textBuilVersion.gameObject.GetComponent<RectTransform>();

			rectTransform.anchorMin = anchorPosition;
			rectTransform.anchorMax = anchorPosition;
			rectTransform.pivot = anchorPosition;

		}
	}
}
