﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mugelli.Software.It.Mgc.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}