﻿using UploadImageApp.Services;

namespace UploadImageApp.Views;

public partial class MainPage : ContentPage
{
	UploadImage uploadImage { get; set; }

	public MainPage()
	{
		InitializeComponent();
		uploadImage = new UploadImage();
	}

	private async void UploadImage_Clicked(object sender, EventArgs e)
	{
		var img = await uploadImage.OpenMediaPickerAsync();
		var imagefile = await uploadImage.Upload(img);

		// Display the uploaded image path
		string imagePath = imagefile.Path;
        ImagePathLable.Text = "Image Path: " + imagefile.Path;
        //DisplayAlert("Image Upload Path", imagePath, "OK");
		

        Image_Upload.Source = ImageSource.FromStream(() =>
			uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64))
		);

    }

}

