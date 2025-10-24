#pragma once

#include "MainWindow.g.h"

namespace winrt::WinUI3_cppWinRT_consumeSample::implementation
{
    struct MainWindow : MainWindowT<MainWindow>
    {
        MainWindow();
    };
}

namespace winrt::WinUI3_cppWinRT_consumeSample::factory_implementation
{
    struct MainWindow : MainWindowT<MainWindow, implementation::MainWindow>
    {
    };
}
