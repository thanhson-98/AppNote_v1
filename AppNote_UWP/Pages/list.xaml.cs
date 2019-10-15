using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppNote_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class list : Page
    {
        public ObservableCollection<string> notes = new ObservableCollection<string>();
        IReadOnlyList<StorageFile> files = new List<StorageFile>();

        public list()
        {
            this.InitializeComponent();
            GetListNoteAsync();
        }

        private async System.Threading.Tasks.Task GetListNoteAsync()
        {
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            files = await storageFolder.GetFilesAsync();
            foreach(var file in files)
            {
                Debug.WriteLine(file.Name);
                notes.Add(file.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(form));
        }

        //chon
        private void NoteList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedIndex = NoteList.SelectedIndex;
            var fileName = notes[selectedIndex];
            foreach (var file in files)
            {
                if (file.Name == fileName)
                {
                    var content = Windows.Storage.FileIO.ReadTextAsync(file).GetAwaiter().GetResult();
                    Note.Text = content;
                }
            }
        }
    }
}
