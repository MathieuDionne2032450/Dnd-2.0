using DojonEtWiki.Api;
using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.ViewModel
{
    public class MainPageVM
    {
        //constructeur
        public MainPageVM()
        {
            
        }

        //methode
        public bool CheckKey(string key)
        {
            return KeyProcessor.CheckKey(key).Result;
        }

    }
}
