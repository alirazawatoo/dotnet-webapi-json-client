using dotnet_test_project.Api;
using dotnet_test_project.View;
using System;

namespace dotnet_test_project
{
    class Program
    {
        static void Main()
        {
            ApiHelper.InitializeClient();
            PeopleView.DisplayOptions();
        }
    }
}
