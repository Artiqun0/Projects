
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Message;
using TrendYol.Services.Interfaces;

namespace TrendYol.Services.Classes;
    public class DataService : IDataService
{
    public readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NewSendData(object[] data)
    {
        _messenger.Send(new DataMessages()
        {
            Datas = data
        });
    }
    public void SendData(object data)
    {
        _messenger.Send(new DataMessage()
        {
            Data = data
        });
    }
}
