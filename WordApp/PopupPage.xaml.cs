using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Text;

namespace WordApp;

public partial class PopupPage : Popup
{
	public PopupPage( ref ItemModel item)
	{
		InitializeComponent();
        this.item = item;
        if(item.data != null && item.typeData == TypeData.Text)
        {
            isText.IsChecked= true;
            EditrText.Text = item.data;
        }
        else if(item.data != null && item.typeData == TypeData.Image)
        {
            isImage.IsChecked = true;
            
            LablePath.Text = item.data;
        }
	}
    ItemModel item;
    private async void PickImage(object sender, System.EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Выберите картинку",
            FileTypes = FilePickerFileType.Images

        });
        if (result != null)
        {
            LablePath.Text = result.FullPath;
            item.DisplaiImage = result.FullPath;
            item.data = result.FullPath;
            item.typeData = TypeData.Image;
            
        }
    }

    private void OnButtonClicked(object sender, System.EventArgs e)
    {
        if (isImage.IsChecked == true)
        {
            item.typeData = TypeData.Image;
            item.data = LablePath.Text;
            item.DisplaiData = string.Empty;
            item.DisplaiImage = LablePath.Text;
        }
        else if (isText.IsChecked == true)
        {
            item.data = EditrText.Text;
            item.typeData = TypeData.Text;
            if (EditrText.Text != null &&EditrText.Text.Length >19)
            {
                char[] chars = EditrText.Text.ToCharArray();
                StringBuilder stringBuilder = new StringBuilder(25);
                for (int i = 0; i < 20; i++)
                {
                    stringBuilder.Append(chars[i]);
                }
                stringBuilder.Append("...");
                item.DisplaiData = stringBuilder.ToString();
            }
            else
            {
                item.DisplaiData = EditrText.Text;
            }
            
            item.DisplaiImage = string.Empty;
        }
        else 
        {
            item.data = null;
        }
        if(item.data is not null)
        {
        }
        this.Close();
     
       

    }
}