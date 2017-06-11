using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class ConnectionController
    {
        private AccountProvider _accountProvider;

        public bool TestConnection()
        {
            try
            {
                _accountProvider = new AccountProvider();
                if (_accountProvider.getAll() == null) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void InstallDatabase()
        {
            ProcessStartInfo processSI = new ProcessStartInfo(App.BaseDirectory + "InstallDatabase\\InstallDatabase.exe");
            Process process = Process.Start(processSI);
            process.WaitForExit();
        }
    }
}
