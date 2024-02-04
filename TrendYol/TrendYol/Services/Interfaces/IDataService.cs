using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendYol.Services.Interfaces;
    public interface IDataService
    {
        public void NewSendData(object[] data);
        public void SendData(object data);

    }

