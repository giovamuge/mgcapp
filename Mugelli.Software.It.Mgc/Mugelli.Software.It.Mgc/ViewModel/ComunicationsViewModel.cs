using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ComunicationsViewModel : ViewModelBase
    {
        public ComunicationsViewModel()
        {
            CommunicationsList = new List<Communication>()
            {
                new Communication()
                {
                    Title = "sdv id jdvldlkvmsdlkvmsdlvm",
                    Content = "disv odi vjosdivj dov jds vdvvlksdvmsdlòkv",
                    Date = DateTime.Now,
                    Type = EventType.Ammi
                },
                new Communication()
                {
                    Title = "sdiv òoivjòsd òvlk",
                    Content = "apg jràgj roiòoafivneaofijcrnòkl fò",
                    Date = DateTime.Now,
                    Type = EventType.Mgc
                },
                new Communication()
                {
                    Title = "ag jioj eròaov òakvln d.m,v ",
                    Content = "oi òdavh òdkvn erlòvkn vòr òpahv ròvh aeròv r",
                    Date = DateTime.Now,
                    Type = EventType.Giovanissimi
                },
                new Communication()
                {
                    Title = "r vòerhahverjkvklervnalkerv klvljkv ",
                    Content = "aoeirv òav òr òrev aòvn aòjvn anvkarnvòarh vòoravj òaroivj òoarijv òoiv ",
                    Date = DateTime.Now,
                    Type = EventType.Ammi
                },
                new Communication()
                {
                    Title = "sd vòdk vdkjvn ",
                    Content = "apd vjdoàjv àweriopvgjà ervopj efàvbkf àbvlkf bàfb ",
                    Date = DateTime.Now,
                    Type = EventType.Giovanissimi
                },
                new Communication()
                {
                    Title = "dòlvk òdlv",
                    Content = "disv odi vjosdivj dov jds vdvvlksdvmsdlòkv",
                    Date = DateTime.Now,
                    Type = EventType.Oblati
                },
                new Communication()
                {
                    Title = "dsvjldkn dlk",
                    Content = "aj bvòfoh àsbhlòbhj òkbjg blòkjsbn lkjbfn lkjn òoh aòoeivh òaeoji roò",
                    Date = DateTime.Now,
                    Type = EventType.Ammi
                },
                new Communication()
                {
                    Title = "divjdovijdsovj",
                    Content = "<dvj òdosi<vj òodivj ò<doivj dòso<vj òvj dò<vj òdj vòjòlkdv j",
                    Date = DateTime.Now,
                    Type = EventType.Mgc
                }
            };
        }

        public List<Communication> CommunicationsList { get; set; }

        public string Title { get; set; } = "Avvisi";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Advertising_50px.png");
    }
}