using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;

namespace NextflowCamera
{
	public partial class NextflowCameraPage : ContentPage
	{
		public NextflowCameraPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { 
				Directory = "MyPhoto",
				Name = "Nextflow.jpg",
				SaveToAlbum = true
			});

			if (file == null)
				return;

			image.Source = ImageSource.FromStream(() => {
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});
		}
	}
}
