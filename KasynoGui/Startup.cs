using KasynoGui.Models;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Web.Services.Description;
using System.Web;
using Microsoft.AspNetCore.Http;

[assembly: OwinStartupAttribute(typeof(KasynoGui.Startup))]
namespace KasynoGui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MyDataStorage.AddToMyDataList("2");
            MyDataStorage.AddToMyDataList("23");
            MyDataStorage.AddToMyDataList("36");
            MyDataStorage.AddToMyDataList("4");
            MyDataStorage.AddToMyDataList("15");
            MyDataStorage.AddToMyDataList("21");
            MyDataStorage.AddToMyDataList("18");
            MyDataStorage.AddToMyDataList("25");
            MyDataStorage.AddToMyDataList("28");
            MyDataStorage.AddToMyDataList("32");
            
        }

    }
}
