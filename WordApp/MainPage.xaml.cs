namespace WordApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
	List<ModelTask> tasks = new List<ModelTask>();
        tasks.Add(new ModelTask());

	}
    public class ModelTask
    {
         List<string> data = new List<string>();
         List<TypeData> typeData = new List<TypeData>();
        public void AddElemrntTask(string dataText, TypeData typeDataText)
        {
            this.data.Add(dataText);
            this.typeData.Add(typeDataText);
        }
    }
    public enum TypeData
    {
        Image,
        Text
    }
}

