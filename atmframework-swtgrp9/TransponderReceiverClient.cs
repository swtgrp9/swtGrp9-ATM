using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using TransponderReceiver;

namespace atmframework_swtgrp9
{
    class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;
        private readonly Action<List<string>> _action;

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(Action<List<string>> onAction,  ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;


            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
 
            //Callback
            _action = onAction;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            _action(e.TransponderData);
        }
    }
}
