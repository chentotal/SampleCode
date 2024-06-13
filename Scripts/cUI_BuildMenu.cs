namespace Sample
{
	public class cUI_TowerBuildMenu : MonoBehaviour
	{
		[SerializeField] List<cUI_BuildMenuButton> _buildBtns;
		[SerializeField] Animation _animation;

		public Action<BuildingType> TypeSelected = null;

		void Start()
		{
			foreach (var buildBtn in _buildBtns)
			{
				buildBtn.ButtonClicked = OnTypeSelected;
			}
		}

		void OnTypeSelected(BuildingType buildType)
		{
			if (_animation.isPlaying)
			{
				return;
			}
			TypeSelected?.Invoke(buildType);
		}

		public void OpenMenu()
		{
			_animation.Stop();
			gameObject.SetActive(true);
			_animation.Play("BuildMenuOpen");
		}

		public void CloseMenu()
		{
			_animation.Play("BuildMenuClose");
		}

		public void CloseCompleted()
		{
			gameObject.SetActive(false);
		}
	}
}