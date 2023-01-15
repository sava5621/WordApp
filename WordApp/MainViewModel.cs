using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
namespace WordApp
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<ModelTask> TaskWord { get; set; } = new();
        [RelayCommand]
        public async Task AddTaskWord()
        {
            TaskWord.Add(new());
        }
        [RelayCommand]
        public async Task DellTaskWord(ModelTask item)
        {

            TaskWord.Remove(item);
        }
        [RelayCommand]
        public async Task OpenPopup(ItemModel item)
        {
            var popup = new PopupPage(ref item);
            App.Current.MainPage.ShowPopup(popup);
        }
        [RelayCommand]
        public async Task AddItemTaskWord(ModelTask item)
        {
           
            item.DataList.Add(new("", TypeData.Text, item.id));
        }
        [RelayCommand]
        public async Task DellItemTaskWord(ItemModel item)
        {
            foreach (var i in TaskWord)
            {
                if(i.id== item.idTaskWord)
                {
                    TaskWord[TaskWord.IndexOf(i)].DataList.Remove(item);
                }
            }

        }
    }


    public partial class ModelTask : ObservableObject
    {
        public ObservableCollection<ItemModel> DataList { get; set; } = new ();
        public Guid id = new Guid();
        [ObservableProperty]
        bool isSingl;
        [ObservableProperty]
        bool isDouble;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DoubleLine))]
        bool singlLine;
        public bool DoubleLine => !SinglLine;

    }
    public partial class ItemModel : ObservableObject
    {   
        public ItemModel(string data, TypeData typeData, Guid guid) 
        {
            this.typeData = typeData;
            this.data = data;
            this.idTaskWord = guid;
            displaiData = data;
        }
        [ObservableProperty]
        string displaiData;
        [ObservableProperty]
        string displaiImage;
        public Guid idTaskWord;
        public Guid idItem = new Guid();
        public string data;
        public TypeData typeData;
    }
    public enum TypeTask
    {
        Default,
        BigPicture
    }
    public enum TypeData
    {
        Image,
        Text
    }
}
