#include "pch.h"
#include "MainWindow.xaml.h"
#if __has_include("MainWindow.g.cpp")
#include "MainWindow.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::WinUI3_cppWinRT_consumeSample::implementation
{
	MainWindow::MainWindow()
	{
		InitializeComponent();

		// CommunityDataGrid().
        // use C# component defined Model class
        using WinUI3_Csharp_RuntimeComponent_Sample::CommunityUserControl;
        using WinUI3_Csharp_RuntimeComponent_Sample::Models::Person;

        // create observable vector IObservableVector<Person>
        auto items = single_threaded_observable_vector<Person>();

        {
            Person p{};
            p.Name(L"Alice");
            p.Age(30);
            p.Email(L"alice@example.com");
            items.Append(p);
        }
        {
            Person p{};
            p.Name(L"Bob");
            p.Age(28);
            p.Email(L"bob@example.com");
            items.Append(p);
        }
        {
            Person p{};
            p.Name(L"Carol");
            p.Age(35);
            p.Email(L"carol@example.com");
            items.Append(p);
        }

        // C++ send IObservableVector<T>，C# use IEnumerable 
        CommunityDataGrid().ItemsSource(items);
    }
}
